using Certify.Api.Interfaces;
using Certify.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Certify.Api.Extensions
{
	public static class Blah
	{
		public static Task<List<ExpenseReportGld>> GetAllAsync(this IExpenseReportGlds expenseReportGlds,
			uint index,
			string name = null,
			string code = null,
			uint? active = null)
		=>
			CertifyClient.GetAllAsync(async (pageNumber) =>
			{
				var actualPage = await expenseReportGlds.GetPageAsync(index, name, code, active, pageNumber).ConfigureAwait(false);
				return new GenericPage<ExpenseReportGld>
				{
					TotalPageCount = actualPage.TotalPageCount,
					TotalRecordCount = actualPage.TotalRecordCount,
					Items = actualPage.ExpenseReportGlds
				};
			});
	}
}
