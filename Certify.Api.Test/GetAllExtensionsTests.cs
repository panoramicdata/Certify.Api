using AwesomeAssertions;
using Certify.Api.Exceptions;
using Certify.Api.Extensions;
using Certify.Api.Interfaces;
using Certify.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test;

public class GetAllExtensionsTests
{
	private const int _pageIndex = 4;

	private static IExpenses Fake(List<object?[]> calls, Func<uint?, ExpensePage> pages)
		=> FakeProxy.RecordPages<IExpenses>(calls, args => Task.FromResult(pages(FakeProxy.Number(args, _pageIndex))));

	private static ExpensePage Page(uint totalPageCount, uint totalRecordCount, params Expense[] items)
		=> new() { Expenses = [.. items], TotalPageCount = totalPageCount, TotalRecordCount = totalRecordCount };

	private static ExpensePage OneExpense() => Page(1, 1, new Expense { Id = Guid.NewGuid() });

	[Fact]
	public async Task Expenses_GetAll_UsesEmptyFilterWhenNoneGiven()
	{
		var calls = new List<object?[]>();

		var result = await Fake(calls, _ => OneExpense()).GetAllAsync(CancellationToken.None);

		result.Should().HaveCount(1);
		FakeProxy.Filters(calls.Single(), _pageIndex).Should().AllSatisfy(value => value.Should().BeNull());
	}

	[Fact]
	public async Task Expenses_GetAllWithFilter_ForwardsFilterValues()
	{
		var calls = new List<object?[]>();
		var filter = new ExpenseFilter
		{
			StartDate = "2024-01-01",
			EndDate = "2024-12-31",
			BatchId = "batch-1",
			Processed = 1,
			IncludeDisapproved = 0
		};

		await Fake(calls, _ => OneExpense()).GetAllAsync(filter, CancellationToken.None);

		FakeProxy.Filters(calls.Single(), _pageIndex).Should().Equal("2024-01-01", "2024-12-31", "batch-1", 1u, 0u);
	}

	[Fact]
	public async Task Expenses_GetAllAcrossPages_ReturnsEveryRecordInOrder()
	{
		var ids = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
		var calls = new List<object?[]>();
		var api = Fake(calls, page => page == 1
			? Page(2, 2, [.. ids.Take(2).Select(id => new Expense { Id = id })])
			: Page(2, 3, new Expense { Id = ids[2] }));

		var result = await api.GetAllAsync(CancellationToken.None);

		result.Select(x => x.Id).Should().Equal(ids);
		calls.Select(call => FakeProxy.Number(call, _pageIndex)).Should().Equal(1u, 2u);
	}

	[Fact]
	public async Task Expenses_GetAllWhenPageCountsMismatch_Throws()
	{
		var api = Fake([], _ => Page(1, 99, new Expense { Id = Guid.NewGuid() }));

		var act = () => api.GetAllAsync(CancellationToken.None);

		await act.Should().ThrowAsync<PageCountMismatchException>();
	}
}
