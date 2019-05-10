using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IExpenseReportGlds
	{
		[Post("/expensereportsglds")]
		Task PostAsync([Body] ExpenseReportGld cpd);

		[Get("/expensereportsglds/{id}")]
		Task<ExpenseReportGld> GetAsync(int id);

		[Get("/expensereportsglds")]
		Task<ExpenseReportGldContainer> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/expensereportsglds")]
		Task PutAsync([Body] ExpenseReportGld cpd);

		[Delete("/expensereportsglds/{id}")]
		Task DeleteAsync(int id);
	}
}
