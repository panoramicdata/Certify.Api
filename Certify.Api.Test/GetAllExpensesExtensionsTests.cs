using AwesomeAssertions;
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

public class GetAllExpensesExtensionsTests
{
	private const int _pageIndex = 4;

	private static IExpenseReports Fake(List<object?[]> calls, Func<uint?, ExpenseReportPage> pages)
		=> FakeProxy.RecordPages<IExpenseReports>(calls, args => Task.FromResult(pages(FakeProxy.Number(args, _pageIndex))));

	private static ExpenseReportPage Page(uint totalPageCount, uint totalRecordCount, params ExpenseReport[] items)
		=> new() { ExpenseReports = [.. items], TotalPageCount = totalPageCount, TotalRecordCount = totalRecordCount };

	private static ExpenseReportPage OneReport() => Page(1, 1, new ExpenseReport { Id = Guid.NewGuid() });

	[Fact]
	public async Task ExpenseReports_GetAll_UsesEmptyFilterWhenNoneGiven()
	{
		var calls = new List<object?[]>();

		var result = await Fake(calls, _ => OneReport()).GetAllAsync(CancellationToken.None);

		result.Should().HaveCount(1);
		FakeProxy.Filters(calls.Single(), _pageIndex).Should().AllSatisfy(value => value.Should().BeNull());
	}

	[Fact]
	public async Task ExpenseReports_GetAllWithFilter_ForwardsFilterValues()
	{
		var calls = new List<object?[]>();
		var filter = new ExpenseReportFilter
		{
			ApprovalCode = "ac-1",
			StartDate = "2024-01-01",
			EndDate = "2024-12-31",
			BatchId = "batch-1",
			Processed = 2,
			Reimbursed = "1",
			ReimbursedStartDate = "2024-02-01",
			ReimbursedEndDate = "2024-12-31"
		};

		await Fake(calls, _ => OneReport()).GetAllAsync(filter, CancellationToken.None);

		FakeProxy.Filters(calls.Single(), _pageIndex).Should().Equal(
			"ac-1", "2024-01-01", "2024-12-31", "batch-1", 2u, "1", "2024-02-01", "2024-12-31");
	}

	[Fact]
	public async Task ExpenseReports_GetAllAcrossPages_ReturnsEveryRecord()
	{
		var ids = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
		var api = Fake([], page => page == 1
			? Page(2, 2, new ExpenseReport { Id = ids[0] }, new ExpenseReport { Id = ids[1] })
			: Page(2, 3, new ExpenseReport { Id = ids[2] }));

		var result = await api.GetAllAsync(CancellationToken.None);

		result.Select(x => x.Id).Should().Equal(ids);
	}
}
