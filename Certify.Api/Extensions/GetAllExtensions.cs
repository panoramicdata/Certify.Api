using Certify.Api.Interfaces;
using Certify.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Certify.Api.Extensions
{
	public static class Extensions
	{
		public static Task<List<ExpenseReportGld>> GetAllAsync(this IExpenseReportGlds expenseReportGlds,
			uint index,
			string name = null,
			string code = null,
			uint? active = null)
		=>
			CertifyClient.GetAllAsync(async (pageNumber) =>
			{
				var actualPage = await expenseReportGlds
				.GetPageAsync(
					index,
					name,
					code,
					active,
					pageNumber)
				.ConfigureAwait(false);
				return new GenericPage<ExpenseReportGld>
				{
					TotalPageCount = actualPage.TotalPageCount,
					TotalRecordCount = actualPage.TotalRecordCount,
					Items = actualPage.ExpenseReportGlds
				};
			});

		public static Task<List<Expense>> GetAllAsync(this IExpenses expenses,
			string startDate = null,
			string endDate = null,
			string batchId = null,
			uint? processed = null,
			uint? page = null,
			uint? includeDisapproved = null
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
						page,
						includeDisapproved)
					.ConfigureAwait(false);
				return new GenericPage<Expense>
				{
					TotalPageCount = actualPage.TotalPageCount,
					TotalRecordCount = actualPage.TotalRecordCount,
					Items = actualPage.Expenses
				};
			});
	}
}
