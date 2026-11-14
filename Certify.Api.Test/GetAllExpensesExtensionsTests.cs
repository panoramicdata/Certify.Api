using AwesomeAssertions;
using Certify.Api.Extensions;
using Certify.Api.Interfaces;
using Certify.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test;

public class GetAllExpensesExtensionsTests
{
	private sealed class RecordingExpenseReports : IExpenseReports
	{
		public List<string?> ApprovalCodes { get; } = new();
		public List<string?> StartDates { get; } = new();
		public List<string?> EndDates { get; } = new();
		public List<string?> BatchIds { get; } = new();
		public List<uint?> Processed { get; } = new();
		public List<string?> Reimbursed { get; } = new();
		public List<string?> ReimbursedStartDates { get; } = new();
		public List<string?> ReimbursedEndDates { get; } = new();
		public Func<uint?, Task<ExpenseReportPage>> PageFactory { get; set; } = _ => Task.FromResult(EmptyPage());

		public Task<ExpenseReportPage> GetPageAsync(
			string? approvalCode,
			string? startDate,
			string? endDate,
			string? batchId,
			uint? page,
			uint? processed,
			string? reimbursed,
			string? reimbursedstartdate,
			string? reimbursedenddate,
			CancellationToken cancellationToken = default)
		{
			ApprovalCodes.Add(approvalCode);
			StartDates.Add(startDate);
			EndDates.Add(endDate);
			BatchIds.Add(batchId);
			Processed.Add(processed);
			Reimbursed.Add(reimbursed);
			ReimbursedStartDates.Add(reimbursedstartdate);
			ReimbursedEndDates.Add(reimbursedenddate);
			return PageFactory(page);
		}

		public Task<ExpenseReportPage> GetAsync(Guid id, string? batchId, CancellationToken cancellationToken = default)
			=> Task.FromResult(EmptyPage());

		public Task<ExpensePage> GetExpensesAsync(Guid id, string? approvalCode, string? startDate, string? endDate, string? batchId, CancellationToken cancellationToken = default)
			=> Task.FromResult(new ExpensePage());
	}

	private static ExpenseReportPage EmptyPage()
	{
		var page = new ExpenseReportPage();
		page.TotalPageCount = 1;
		page.TotalRecordCount = 0;
		return page;
	}

	private static ExpenseReportPage Page(uint totalPageCount, uint totalRecordCount, params ExpenseReport[] items)
	{
		var page = new ExpenseReportPage { ExpenseReports = items.ToList() };
		page.TotalPageCount = totalPageCount;
		page.TotalRecordCount = totalRecordCount;
		return page;
	}

	[Fact]
	public async Task ExpenseReports_GetAll_UsesEmptyFilterWhenNoneGiven()
	{
		var reports = new RecordingExpenseReports
		{
			PageFactory = _ => Task.FromResult(Page(1, 1, new ExpenseReport { Id = Guid.NewGuid() }))
		};

		var result = await reports.GetAllAsync(CancellationToken.None);

		result.Should().HaveCount(1);
		reports.ApprovalCodes.Should().ContainSingle().Which.Should().BeNull();
		reports.StartDates.Should().ContainSingle().Which.Should().BeNull();
		reports.EndDates.Should().ContainSingle().Which.Should().BeNull();
		reports.BatchIds.Should().ContainSingle().Which.Should().BeNull();
		reports.Processed.Should().ContainSingle().Which.Should().BeNull();
		reports.Reimbursed.Should().ContainSingle().Which.Should().BeNull();
		reports.ReimbursedStartDates.Should().ContainSingle().Which.Should().BeNull();
		reports.ReimbursedEndDates.Should().ContainSingle().Which.Should().BeNull();
	}

	[Fact]
	public async Task ExpenseReports_GetAllWithFilter_ForwardsFilterValues()
	{
		var reports = new RecordingExpenseReports
		{
			PageFactory = _ => Task.FromResult(Page(1, 1, new ExpenseReport { Id = Guid.NewGuid() }))
		};

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

		await reports.GetAllAsync(filter, CancellationToken.None);

		reports.ApprovalCodes.Should().ContainSingle().Which.Should().Be("ac-1");
		reports.StartDates.Should().ContainSingle().Which.Should().Be("2024-01-01");
		reports.EndDates.Should().ContainSingle().Which.Should().Be("2024-12-31");
		reports.BatchIds.Should().ContainSingle().Which.Should().Be("batch-1");
		reports.Processed.Should().ContainSingle().Which.Should().Be(2);
		reports.Reimbursed.Should().ContainSingle().Which.Should().Be("1");
		reports.ReimbursedStartDates.Should().ContainSingle().Which.Should().Be("2024-02-01");
		reports.ReimbursedEndDates.Should().ContainSingle().Which.Should().Be("2024-12-31");
	}

	[Fact]
	public async Task ExpenseReports_GetAllAcrossPages_ReturnsEveryRecord()
	{
		var ids = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

		var reports = new RecordingExpenseReports
		{
			PageFactory = page => page == 1
				? Task.FromResult(Page(2, 2, new ExpenseReport { Id = ids[0] }, new ExpenseReport { Id = ids[1] }))
				: Task.FromResult(Page(2, 3, new ExpenseReport { Id = ids[2] }))
		};

		var result = await reports.GetAllAsync(CancellationToken.None);

		result.Select(x => x.Id).Should().Equal(ids);
	}
}
