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
	/// <param name="name">Optional name filter.</param>
	/// <param name="code">Optional code filter.</param>
	/// <param name="active">Optional active status filter.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all expense report GLDs.</returns>
	public static Task<List<ExpenseReportGld>> GetAllAsync(this IExpenseReportGlds expenseReportGlds,
		uint index,
		string? name = null,
		string? code = null,
		uint? active = null,
		CancellationToken cancellationToken = default)
	=>
		CertifyClient.GetAllAsync(async (pageNumber) =>
		{
			var actualPage = await expenseReportGlds
			.GetPageAsync(
				index,
				name,
				code,
				active,
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
	/// <param name="startDate">Optional start date filter.</param>
	/// <param name="endDate">Optional end date filter.</param>
	/// <param name="batchId">Optional batch ID filter.</param>
	/// <param name="processed">Optional processed status filter.</param>
	/// <param name="includeDisapproved">Optional include disapproved filter.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all expenses.</returns>
	public static Task<List<Expense>> GetAllAsync(this IExpenses expenses,
		string? startDate = null,
		string? endDate = null,
		string? batchId = null,
		uint? processed = null,
		uint? includeDisapproved = null,
		CancellationToken cancellationToken = default
		)
	=>
		CertifyClient.GetAllAsync(async (pageNumber) =>
		{
			var actualPage = await expenses
				.GetPageAsync(
					startDate,
					endDate,
					batchId,
					processed,
					pageNumber,
					includeDisapproved,
					cancellationToken: cancellationToken)
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
	/// <param name="approvalCode">Optional approval code filter.</param>
	/// <param name="startDate">Optional start date filter.</param>
	/// <param name="endDate">Optional end date filter.</param>
	/// <param name="batchId">Optional batch ID filter.</param>
	/// <param name="processed">Optional processed status filter.</param>
	/// <param name="reimbursed">Optional reimbursed status filter.</param>
	/// <param name="reimbursedstartdate">Optional reimbursed start date filter.</param>
	/// <param name="reimbursedenddate">Optional reimbursed end date filter.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all expense reports.</returns>
	public static Task<List<ExpenseReport>> GetAllAsync(this IExpenseReports expenseReports,
		string? approvalCode = null,
		string? startDate = null,
		string? endDate = null,
		string? batchId = null,
		uint? processed = null,
		string? reimbursed = null,
		string? reimbursedstartdate = null,
		string? reimbursedenddate = null,
		CancellationToken cancellationToken = default)
	=>
		CertifyClient.GetAllAsync(async (pageNumber) =>
		{
			var actualPage = await expenseReports
			.GetPageAsync(
				approvalCode,
				startDate,
				endDate,
				batchId,
				pageNumber,
				processed,
				reimbursed,
				reimbursedstartdate,
				reimbursedenddate,
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
	/// <param name="username">Optional username filter.</param>
	/// <param name="active">Optional active status filter.</param>
	/// <param name="role">Optional role filter.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A list of all users.</returns>
	public static Task<List<User>> GetAllAsync(this IUsers users,
		string? username = null,
		uint? active = null,
		string? role = null,
		CancellationToken cancellationToken = default)
	=>
		CertifyClient.GetAllAsync(async (pageNumber) =>
		{
			var actualPage = await users
			.GetPageAsync(
				username,
				active,
				role,
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
