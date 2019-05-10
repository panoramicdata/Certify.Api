using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IExpenses
	{
		[Post("/expensecategories")]
		Task PostAsync([Body] Expense cpd);

		[Get("/expensecategories/{id}")]
		Task<Expense> GetAsync(int id);

		[Get("/expensecategories")]
		Task<ExpenseContainer> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/expensecategories")]
		Task PutAsync([Body] Expense cpd);

		[Delete("/expensecategories/{id}")]
		Task DeleteAsync(int id);
	}
}
