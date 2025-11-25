using Certify.Api.Interfaces;
using Certify.Api.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Extensions;

public static class Extensions
{
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
