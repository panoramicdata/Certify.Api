using Certify.Api.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces;

/// <summary>
/// An expense category interface
/// </summary>
public interface IExpenseCategories
{
	/// <summary>
	/// This method returns a list of one or more expense categories for the current company.
	/// </summary>
	/// <param name="name">Name of expense category</param>
	/// <param name="glCode">Expense category GL code</param>
	/// <param name="expenseTypeId">The identifier for the expense type (1 = Cash Expense, 2 = Mileage, 3 = Lodging, 4 = Meals, 5 = Rentals, 6 = Travel, 7 = Per-Diem, 8 = Hourly, 9 = Invoice)</param>
	/// <param name="departmentFilterId">Associated Department ID</param>
	/// <param name="active">Active status</param>
	/// <param name="page">Desired page of result</param>
	/// <returns></returns>
	[Get("/expensecategories")]
	Task<ExpenseCategoryPage> GetPageAsync(
		[AliasAs("name")] string? name = null,
		[AliasAs("glcode")] string? glCode = null,
		[AliasAs("expensetypeid")] string? expenseTypeId = null,
		[AliasAs("departmentfilterid")] string? departmentFilterId = null,
		[AliasAs("active")] uint? active = null,
		[AliasAs("page")] uint? page = null,
		CancellationToken cancellationToken = default
		);

	/// <summary>
	/// For each expense category element in the POST body, this method will update expense
	/// category records for the user’s company corresponding to the IDs supplied.
	/// Any elements where new values were not provided will retain their current value.
	/// </summary>
	/// <param name="expenseCategories">The ExpenseCategories to update.</param>
	/// <returns>A separate status should be returned for each record, either "Updated" or "Error" with a detailed error message.</returns>
	[Post("/expensecategories")]
	Task<UpdateResult> UpdateAsync(
		[Body] List<ExpenseCategory> expenseCategories,
		CancellationToken cancellationToken = default
		);

	/// <summary>
	/// This method creates a new expense category record for the user’s company.
	/// </summary>
	/// <param name="expenseCategory">The ExpenseCategory to create.</param>
	/// <returns>The ID of the new expense category</returns>
	[Put("/expensecategories")]
	Task<CreateResult> CreateAsync([Body] ExpenseCategory expenseCategory,
		CancellationToken cancellationToken = default
		);

	/// <summary>
	/// This method returns an expense categories for the current company.
	/// </summary>
	/// <param name="id">Expense category ID</param>
	/// <returns>an expense categories for the current company.</returns>
	[Get("/expensecategories/{id}")]
	Task<ExpenseCategoryPage> GetAsync(Guid id,
		CancellationToken cancellationToken = default
		);
}
