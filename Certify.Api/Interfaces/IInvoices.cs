using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IInvoices
	{
		[Post("/invoices")]
		Task PostAsync([Body] Expense cpd);

		[Get("/invoices/{id}")]
		Task<Expense> GetAsync(int id);

		[Get("/invoices")]
		Task<ExpenseContainer> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/invoices")]
		Task PutAsync([Body] Expense cpd);

		[Delete("/invoices/{id}")]
		Task DeleteAsync(int id);
	}
}
