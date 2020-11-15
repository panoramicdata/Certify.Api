using Certify.Api.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	/// <summary>
	/// An ExpenseReport Global Ledger Dimension interface
	/// </summary>
	public interface IExpenseReportGlds : ISupportsPaging
	{
		/// <summary>
		/// This method will return a list of one or more expense report GLD records for the current company.
		/// </summary>
		/// <param name="index">Expense report GLD index</param>
		/// <param name="name">Name of expense report GLD	</param>
		/// <param name="code">Expense report GLD code</param>
		/// <param name="active">Active status (1 for active records, 0 for inactive, NULL for all)</param>
		/// <param name="page">Page, if not specified, page 1 will be retrieved.</param>
		/// <returns></returns>
		[Get("/exprptglds/{index}")]
		Task<ExpenseReportGldPage> GetPageAsync(
			[AliasAs("index")] uint index,
			[AliasAs("name")] string? name = null,
			[AliasAs("code")] string? code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint page = 1,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// For each expense report GLD element in the POST body, this method will update
		/// expense report GLD records for the current company corresponding to the IDs supplied.
		/// Any elements where new values were not provided will retain their current value.
		/// </summary>
		/// <param name="expenseReportGld"></param>
		/// <returns></returns>
		[Post("/exprptglds/{index}")]
		Task<List<UpdateResult>> UpdateAsync(
			[AliasAs("index")] uint index,
			[Body] ExpenseReportGld expenseReportGld,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// This method creates a new expense report GLD record for the current company.
		/// </summary>
		/// <param name="index"></param>
		/// <param name="expenseReportGld"></param>
		/// <returns>If successful, this method should return the ID of the new expense report GLD.</returns>
		[Put("/exprptglds/{index}")]
		Task<CreateResult> CreateAsync(
			[AliasAs("index")] uint index,
			[Body] ExpenseReportGld expenseReportGld,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// This method returns an expense report GLD record associated with the supplied ID value.
		/// </summary>
		/// <param name="index">Expense report GLD index</param>
		/// <param name="id">Expense report GLD ID</param>
		/// <returns></returns>
		[Get("/exprptglds/{index}/{id}")]
		Task<ExpenseReportGldPage> GetAsync(
			[AliasAs("index")] uint index,
			[AliasAs("id")] Guid id,
			CancellationToken cancellationToken = default
			);
	}
}
