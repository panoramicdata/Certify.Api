using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IExpenseCategories
	{
		[Post("/expensecategories")]
		Task PostAsync([Body] ExpenseCategory cpd);

		[Get("/expensecategories/{id}")]
		Task<ExpenseCategory> GetAsync(int id);

		[Get("/expensecategories")]
		Task<ExpenseCategoryContainer> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/expensecategories")]
		Task PutAsync([Body] ExpenseCategory cpd);

		[Delete("/expensecategories/{id}")]
		Task DeleteAsync(int id);
	}
}
