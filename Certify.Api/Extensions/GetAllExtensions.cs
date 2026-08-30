using Certify.Api.Interfaces;
using Certify.Api.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Extensions;

/// <summary>
/// Extension methods for retrieving all paged results.
/// </summary>
public static class Extensions
{
	/// <summary>
	/// Gets all expense report GLDs across all pages.
	/// </summary>
	/// <param name="expenseReportGlds">The expense report GLDs API.</param>
	/// <param name="index">The GLD index.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all expense report GLDs.</returns>
	public static Task<List<ExpenseReportGld>> GetAllAsync(
		this IExpenseReportGlds expenseReportGlds,
		uint index,
		CancellationToken cancellationToken)
	=>
		expenseReportGlds.GetAllAsync(index, new ExpenseReportGldFilter(), cancellationToken);

	/// <summary>
	/// Gets all expense report GLDs matching a filter, across all pages.
	/// </summary>
	/// <param name="expenseReportGlds">The expense report GLDs API.</param>
	/// <param name="index">The GLD index.</param>
	/// <param name="filter">The filter to apply.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all matching expense report GLDs.</returns>
	public static Task<List<ExpenseReportGld>> GetAllAsync(
		this IExpenseReportGlds expenseReportGlds,
		uint index,
		ExpenseReportGldFilter filter,
		CancellationToken cancellationToken)
	=>
		CertifyClient.GetAllAsync(async (pageNumber) =>
		{
			var actualPage = await expenseReportGlds
			.GetPageAsync(
				index,
				filter.Name,
				filter.Code,
				filter.Active,
				pageNumber,
				cancellationToken)
			.ConfigureAwait(false);
			return new GenericPage<ExpenseReportGld>
			{
				TotalPageCount = actualPage.TotalPageCount,
				TotalRecordCount = actualPage.TotalRecordCount,
				Items = actualPage.ExpenseReportGlds
			};
		});

	/// <summary>
	/// Gets all expenses across all pages.
	/// </summary>
	/// <param name="expenses">The expenses API.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all expenses.</returns>
	public static Task<List<Expense>> GetAllAsync(
		this IExpenses expenses,
		CancellationToken cancellationToken)
	=>
		expenses.GetAllAsync(new ExpenseFilter(), cancellationToken);

	/// <summary>
	/// Gets all expenses matching a filter, across all pages.
	/// </summary>
	/// <param name="expenses">The expenses API.</param>
	/// <param name="filter">The filter to apply.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all matching expenses.</returns>
	public static Task<List<Expense>> GetAllAsync(
		this IExpenses expenses,
		ExpenseFilter filter,
		CancellationToken cancellationToken)
	=>
		CertifyClient.GetAllAsync(async (pageNumber) =>
		{
			var actualPage = await expenses
				.GetPageAsync(
					filter.StartDate,
					filter.EndDate,
					filter.BatchId,
					filter.Processed,
					pageNumber,
					filter.IncludeDisapproved,
					cancellationToken)
				.ConfigureAwait(false);
			return new GenericPage<Expense>
			{
				TotalPageCount = actualPage.TotalPageCount,
				TotalRecordCount = actualPage.TotalRecordCount,
				Items = actualPage.Expenses
			};
		});

	/// <summary>
	/// Gets all expense reports across all pages.
	/// </summary>
	/// <param name="expenseReports">The expense reports API.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all expense reports.</returns>
	public static Task<List<ExpenseReport>> GetAllAsync(
		this IExpenseReports expenseReports,
		CancellationToken cancellationToken)
	=>
		expenseReports.GetAllAsync(new ExpenseReportFilter(), cancellationToken);

	/// <summary>
	/// Gets all expense reports matching a filter, across all pages.
	/// </summary>
	/// <param name="expenseReports">The expense reports API.</param>
	/// <param name="filter">The filter to apply.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all matching expense reports.</returns>
	public static Task<List<ExpenseReport>> GetAllAsync(
		this IExpenseReports expenseReports,
		ExpenseReportFilter filter,
		CancellationToken cancellationToken)
	=>
		CertifyClient.GetAllAsync(async (pageNumber) =>
		{
			var actualPage = await expenseReports
			.GetPageAsync(
				filter.ApprovalCode,
				filter.StartDate,
				filter.EndDate,
				filter.BatchId,
				pageNumber,
				filter.Processed,
				filter.Reimbursed,
				filter.ReimbursedStartDate,
				filter.ReimbursedEndDate,
				cancellationToken)
			.ConfigureAwait(false);
			return new GenericPage<ExpenseReport>
			{
				TotalPageCount = actualPage.TotalPageCount,
				TotalRecordCount = actualPage.TotalRecordCount,
				Items = actualPage.ExpenseReports
			};
		});

	/// <summary>
	/// Gets all users across all pages.
	/// </summary>
	/// <param name="users">The users API.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all users.</returns>
	public static Task<List<User>> GetAllAsync(
		this IUsers users,
		CancellationToken cancellationToken)
	=>
		users.GetAllAsync(new UserFilter(), cancellationToken);

	/// <summary>
	/// Gets all users matching a filter, across all pages.
	/// </summary>
	/// <param name="users">The users API.</param>
	/// <param name="filter">The filter to apply.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all matching users.</returns>
	public static Task<List<User>> GetAllAsync(
		this IUsers users,
		UserFilter filter,
		CancellationToken cancellationToken)
	=>
		CertifyClient.GetAllAsync(async (pageNumber) =>
		{
			var actualPage = await users
			.GetPageAsync(
				filter.Username,
				filter.Active,
				filter.Role,
				pageNumber,
				cancellationToken)
			.ConfigureAwait(false);
			return new GenericPage<User>
			{
				TotalPageCount = actualPage.TotalPageCount,
				TotalRecordCount = actualPage.TotalRecordCount,
				Items = actualPage.Users
			};
		});
}
