using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IExpenseReports
	{
		[Post("/expensereports")]
		Task PostAsync([Body] ExpenseReport cpd);

		[Get("/expensereports/{id}")]
		Task<ExpenseReport> GetAsync(int id);

		[Get("/expensereports")]
		Task<ExpenseReportContainer> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/expensereports")]
		Task PutAsync([Body] ExpenseReport cpd);

		[Delete("/expensereports/{id}")]
		Task DeleteAsync(int id);
	}
}
