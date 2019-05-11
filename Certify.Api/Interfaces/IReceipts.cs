using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IReceipts
	{
		[Post("/receipts")]
		Task PostAsync([Body] Receipt receipt);

		[Get("/receipts/{id}")]
		Task<Receipt> GetAsync(int id);

		[Get("/receipts")]
		Task<MileageRateContainer> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/receipts")]
		Task PutAsync([Body] Receipt receipt);

		[Delete("/receipts/{id}")]
		Task DeleteAsync(int id);
	}
}
