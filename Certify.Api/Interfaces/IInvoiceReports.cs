using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IInvoiceReports
	{
		[Post("/invoicereports")]
		Task PostAsync([Body] ExpenseReport cpd);

		[Get("/invoicereports/{id}")]
		Task<ExpenseReport> GetAsync(int id);

		[Get("/invoicereports")]
		Task<InvoiceReportPage> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/invoicereports")]
		Task PutAsync([Body] ExpenseReport cpd);

		[Delete("/invoicereports/{id}")]
		Task DeleteAsync(int id);
	}
}
