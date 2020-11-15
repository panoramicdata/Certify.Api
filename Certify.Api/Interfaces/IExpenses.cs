using Certify.Api.Models;
using Refit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	/// <summary>
	/// An Expense interface
	/// </summary>
	public interface IExpenses : ISupportsPaging
	{
		/// <summary>
		/// This method returns a list of one or more expenses from a processed expense report.
		/// </summary>
		/// <param name="startDate">Starting point for the processed date range. (YYYY-MM-DD)</param>
		/// <param name="endDate">Ending point for the processed date range. (YYYY-MM-DD)</param>
		/// <param name="batchId">A unique ID provided by Certify, specifying a batched group of expenses for export.</param>
		/// <param name="processed">Expense report has been processed</param>
		/// <param name="page">Desired page of result</param>
		/// <returns></returns>
		[Get("/expenses")]
		Task<ExpensePage> GetPageAsync(
			[AliasAs("startdate")] string? startDate = null,
			[AliasAs("enddate")] string? endDate = null,
			[AliasAs("batchid")] string? batchId = null,
			[AliasAs("processed")] uint? processed = null,
			[AliasAs("page")] uint? page = null,
			[AliasAs("includedisapproved")] uint? includeDisapproved = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// This method returns a specific expense associated with the supplied ID value. This method only returns results from a processed expense report.
		/// </summary>
		/// <param name="id">Expense Report/Expense ID	</param>
		/// <param name="batchId">A unique ID provided by Certify, specifying a batched group of expenses for export.</param>
		/// <returns></returns>
		[Get("/expenses/{id}")]
		Task<ExpensePage> GetAsync(
			[AliasAs("id")] Guid id,
			[AliasAs("batchid")] string? batchId = null,
			CancellationToken cancellationToken = default
			);
	}
}
