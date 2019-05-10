using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface ICpdLists
	{
		[Post("/cpdlists")]
		Task PostAsync([Body] CpdList cpd);

		[Get("/cpdlists/{id}")]
		Task<CpdList> GetAsync(int id);

		[Get("/cpdlists")]
		Task<CpdListContainer> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/cpdlists")]
		Task PutAsync([Body] CpdList cpd);

		[Delete("/cpdlists/{id}")]
		Task DeleteAsync(int id);
	}
}
