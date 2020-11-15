using Certify.Api.Models;
using Refit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	/// <summary>
	/// An ExpenseReport interface
	/// </summary>
	public interface IExpenseReports
	{
		/// <summary>
		/// This method returns a list of one or more processed expense reports.
		/// </summary>
		/// <param name="approvalCode">Approval code of single expense report.	</param>
		/// <param name="startDate">Starting point for the processed date range. Excludes unprocessed reports. (YYYY-MM-DD)</param>
		/// <param name="endDate">Ending point for the processed date range. Excludes unprocessed reports. (YYYY-MM-DD)</param>
		/// <param name="batchId">A unique ID provided by Certify, specifying a batched group of expenses for export.</param>
		/// <param name="page">Desired page of result (1 for page 1, 2 for page 2, n for page n)</param>
		/// <param name="processed">Expense report has been processed (1 for yes - default, 0 for no, 2 for both)</param>
		/// <param name="reimbursed">Expense report has been reimbursed (1 for yes, 0 for no, 2 for both - default)</param>
		/// <param name="reimbursedstartdate">Starting point for the report reimbursement process. (YYYY-MM-DD)</param>
		/// <param name="reimbursedenddate">	Ending point for the report reimbursement process. (YYYY-MM-DD)</param>
		/// <returns>Page of ExpenseReports</returns>
		[Get("/expensereports")]
		Task<ExpenseReportPage> GetPageAsync(
			[AliasAs("approvalcode")] string? approvalCode = null,
			[AliasAs("startdate")] string? startDate = null,
			[AliasAs("enddate")] string? endDate = null,
			[AliasAs("batchid")] string? batchId = null,
			[AliasAs("page")] uint? page = null,
			[AliasAs("processed")] uint? processed = null,
			[AliasAs("reimbursed")] string? reimbursed = null,
			[AliasAs("reimbursedstartdate")] string? reimbursedstartdate = null,
			[AliasAs("reimbursedenddate")] string? reimbursedenddate = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// This method returns a specific processed expense report associated with the supplied ID value.
		/// </summary>
		/// <param name="id">The ExpenseReport ID</param>
		/// <returns>a specific processed expense report</returns>
		[Get("/expensereports/{id}")]
		Task<ExpenseReportPage> GetAsync(
			[AliasAs("id")] Guid id,
			[AliasAs("batchid")] string? batchId,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// This method returns all expenses for the processed expense report associated with the supplied ID value.
		/// </summary>
		/// <param name="id">The ExpenseReport ID</param>
		/// <param name="approvalCode">Approval code of single expense report.	</param>
		/// <param name="startDate">Starting point for the processed date range.	</param>
		/// <param name="endDate">Ending point for the processed date range.	</param>
		/// <param name="batchId">A unique ID provided by Certify, specifying a batched group of expenses for export.</param>
		/// <returns>all expenses for the processed expense report associated with the supplied ID value</returns>
		[Get("/expensereports/{id}/expenses")]
		Task<ExpensePage> GetExpensesAsync(
			[AliasAs("id")] Guid id,
			[AliasAs("approvalcode")] string? approvalCode,
			[AliasAs("startdate")] string? startDate,
			[AliasAs("enddate")] string? endDate,
			[AliasAs("batchid")] string? batchId,
			CancellationToken cancellationToken = default
			);
	}
}
