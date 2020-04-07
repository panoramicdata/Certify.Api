using Certify.Api.Models;
using Refit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	/// <summary>
	/// A Receipt interface
	/// </summary>
	public interface IReceipts
	{
		/// <summary>
		/// This method returns a list of metadata from one or more receipts from a processed expense report.
		/// </summary>
		/// <param name="expenseId">Filter receipts returned to a specific Expense ID</param>
		/// <param name="expenseReportId">Filter receipts returned to a specific Expense Report ID</param>
		/// <param name="startDate">Starting point for the expense date range.</param>
		/// <param name="endDate">Ending point for the expense date range.</param>
		/// <param name="batchId">Filter receipts returned to a specific Batch ID</param>
		/// <param name="page">Desired page of result (1 for page 1, 2 for page 2, n for page n)</param>
		/// <returns></returns>
		[Get("/receipts")]
		Task<ReceiptPage> GetPageAsync(
			[AliasAs("expid")] Guid? expenseId = null,
			[AliasAs("exprptid")] Guid? expenseReportId = null,
			[AliasAs("startdate")] string startDate = null,
			[AliasAs("enddate")] string endDate = null,
			[AliasAs("batchid")] string batchId = null,
			[AliasAs("page")] uint? page = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// This method returns one receipt from a processed expense report.
		/// </summary>
		/// <param name="id">The receipt Id</param>
		/// <returns></returns>
		[Get("/receipts/{id}")]
		Task<ReceiptPage> GetAsync(
			Guid id,
			CancellationToken cancellationToken = default
			);
	}
}
