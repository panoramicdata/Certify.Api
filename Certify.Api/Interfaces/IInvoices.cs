using Certify.Api.Models;
using Refit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces;

/// <summary>
/// An Invoice interface
/// </summary>
public interface IInvoices
{
	/// <summary>
	/// This method returns a list of one or more invoices from a processed invoice report.
	/// </summary>
	/// <param name="startDate">Starting point for the processed date range. (YYYY-MM-DD)</param>
	/// <param name="endDate">Ending point for the processed date range. (YYYY-MM-DD)</param>
	/// <param name="page">Desired page of result</param>
	/// <param name="processed">Invoice report has been processed</param>
	/// <returns></returns>
	[Get("/invoices")]
	Task<InvoicePage> GetPageAsync(
		[AliasAs("startdate")] string? startDate = null,
		[AliasAs("enddate")] string? endDate = null,
		[AliasAs("page")] uint? page = null,
		[AliasAs("processed")] uint? processed = null,
		CancellationToken cancellationToken = default
		);

	/// <summary>
	/// This method returns a specific invoice associated with the supplied ID value.
	/// </summary>
	/// <param name="id">Invoice Report/Invoice ID	</param>
	/// <returns></returns>
	[Get("/invoices/{id}")]
	Task<InvoicePage> GetAsync(
		[AliasAs("id")] Guid id,
		CancellationToken cancellationToken = default
		);
}
