using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IMileageRateDetails
	{
		[Post("/mileageratedetails")]
		Task PostAsync([Body] MileageRateDetails cpd);

		[Get("/mileageratedetails/{id}")]
		Task<MileageRateDetails> GetAsync(int id);

		[Get("/mileageratedetails")]
		Task<MileageRateDetailsPage> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/mileageratedetails")]
		Task PutAsync([Body] MileageRateDetails cpd);

		[Delete("/mileageratedetails/{id}")]
		Task DeleteAsync(int id);
	}
}
