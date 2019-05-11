using Certify.Api.Models;
using Refit;
using System;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	/// <summary>
	/// An InvoiceReport interface
	/// </summary>
	public interface IInvoiceReports
	{
		/// <summary>
		/// This method returns a list of one or more processed invoice reports.
		/// </summary>
		/// <param name="approvalCode">Approval code of single invoice report.</param>
		/// <param name="startDate">Starting point for the processed date range. Excludes unprocessed reports. (YYYY-MM-DD)</param>
		/// <param name="endDate">Ending point for the processed date range. Excludes unprocessed reports. (YYYY-MM-DD)</param>
		/// <param name="page">	Desired page of result</param>
		/// <param name="processed">Invoice report has been processed</param>
		/// <param name="reimbursed">Invoice report has been reimbursed</param>
		/// <param name="reimbursedStartDate">Starting point for the report reimbursement process. (YYYY-MM-DD)</param>
		/// <param name="reimbursedEndDate">Ending point for the report reimbursement process. (YYYY-MM-DD)</param>
		/// <returns></returns>
		[Get("/invoicereports")]
		Task<InvoiceReportPage> GetPageAsync(
			[AliasAs("approvalcode")] string approvalCode = null,
			[AliasAs("startdate")] string startDate = null,
			[AliasAs("enddate")] string endDate = null,
			[AliasAs("page")] uint? page = null,
			[AliasAs("processed")] uint? processed = null,
			[AliasAs("reimbursed")] uint? reimbursed = null,
			[AliasAs("reimbursedstartdate")] string reimbursedStartDate = null,
			[AliasAs("reimbursedenddate")] string reimbursedEndDate = null
			);

		/// <summary>
		/// This method returns a specific processed invoice report associated with the supplied ID value.
		/// </summary>
		/// <param name="id">	Invoice Report/Invoice ID</param>
		/// <returns>The invoice report</returns>
		[Get("/invoicereports/{id}")]
		Task<InvoiceReportPage> GetAsync(
			[AliasAs("id")] Guid id
			);
	}
}
