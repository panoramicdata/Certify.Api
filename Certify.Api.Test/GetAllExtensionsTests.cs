using AwesomeAssertions;
using Certify.Api.Exceptions;
using Certify.Api.Extensions;
using Certify.Api.Interfaces;
using Certify.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test;

public class GetAllExtensionsTests
{
	private sealed class RecordingExpenses : IExpenses
	{
		public List<string?> StartDates { get; } = new();
		public List<string?> EndDates { get; } = new();
		public List<string?> BatchIds { get; } = new();
		public List<uint?> Processed { get; } = new();
		public List<uint?> Pages { get; } = new();
		public List<uint?> IncludeDisapproved { get; } = new();
		public Func<uint?, Task<ExpensePage>> PageFactory { get; set; } = _ => Task.FromResult(EmptyPage());

		public Task<ExpensePage> GetPageAsync(
			string? startDate,
			string? endDate,
			string? batchId,
			uint? processed,
			uint? page,
			uint? includeDisapproved,
			CancellationToken cancellationToken = default)
		{
			StartDates.Add(startDate);
			EndDates.Add(endDate);
			BatchIds.Add(batchId);
			Processed.Add(processed);
			Pages.Add(page);
			IncludeDisapproved.Add(includeDisapproved);
			return PageFactory(page);
		}

		public Task<ExpensePage> GetAsync(Guid id, string? batchId, CancellationToken cancellationToken = default)
			=> Task.FromResult(EmptyPage());
	}

	private static ExpensePage EmptyPage()
	{
		var page = new ExpensePage();
		page.TotalPageCount = 1;
		page.TotalRecordCount = 0;
		return page;
	}

	[Fact]
	public async Task Expenses_GetAll_UsesEmptyFilterWhenNoneGiven()
	{
		var expenses = new RecordingExpenses { PageFactory = _ => Task.FromResult(Page(1, 1, new[] { new Expense { Id = Guid.NewGuid() } })) };

		var result = await expenses.GetAllAsync(CancellationToken.None);

		result.Should().HaveCount(1);
		expenses.StartDates.Should().ContainSingle().Which.Should().BeNull();
		expenses.EndDates.Should().ContainSingle().Which.Should().BeNull();
		expenses.BatchIds.Should().ContainSingle().Which.Should().BeNull();
		expenses.Processed.Should().ContainSingle().Which.Should().BeNull();
		expenses.IncludeDisapproved.Should().ContainSingle().Which.Should().BeNull();
	}

	[Fact]
	public async Task Expenses_GetAllWithFilter_ForwardsFilterValues()
	{
		var expenses = new RecordingExpenses { PageFactory = _ => Task.FromResult(Page(1, 1, new[] { new Expense { Id = Guid.NewGuid() } })) };

		var filter = new ExpenseFilter
		{
			StartDate = "2024-01-01",
			EndDate = "2024-12-31",
			BatchId = "batch-1",
			Processed = 1,
			IncludeDisapproved = 0
		};

		await expenses.GetAllAsync(filter, CancellationToken.None);

		expenses.StartDates.Should().ContainSingle().Which.Should().Be("2024-01-01");
		expenses.EndDates.Should().ContainSingle().Which.Should().Be("2024-12-31");
		expenses.BatchIds.Should().ContainSingle().Which.Should().Be("batch-1");
		expenses.Processed.Should().ContainSingle().Which.Should().Be(1);
		expenses.IncludeDisapproved.Should().ContainSingle().Which.Should().Be(0);
	}

	[Fact]
	public async Task Expenses_GetAllAcrossPages_ReturnsEveryRecordInOrder()
	{
		var ids = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

		RecordingExpenses expenses = new()
		{
			PageFactory = page => page switch
			{
				1 => Task.FromResult(Page(2, 2, ids.Take(2).Select(x => new Expense { Id = x }))),
				_ => Task.FromResult(Page(2, 3, new[] { new Expense { Id = ids[2] } }))
			}
		};

		var result = await expenses.GetAllAsync(CancellationToken.None);

		result.Select(x => x.Id).Should().Equal(ids);
		expenses.Pages.Should().Equal(1u, 2u);
	}

	[Fact]
	public async Task Expenses_GetAllWhenPageCountsMismatch_Throws()
	{
		var expenses = new RecordingExpenses { PageFactory = _ => Task.FromResult(Page(1, 99, new[] { new Expense { Id = Guid.NewGuid() } })) };

		var act = () => expenses.GetAllAsync(CancellationToken.None);

		await act.Should().ThrowAsync<PageCountMismatchException>();
	}

	private static ExpensePage Page(uint totalPageCount, uint totalRecordCount, IEnumerable<Expense> items)
	{
		var page = new ExpensePage { Expenses = items.ToList() };
		page.TotalPageCount = totalPageCount;
		page.TotalRecordCount = totalRecordCount;
		return page;
	}
}
