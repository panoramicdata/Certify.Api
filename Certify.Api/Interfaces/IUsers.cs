using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IUsers
	{
		[Post("/users")]
		Task PostAsync([Body] User user);

		[Get("/users/{id}")]
		Task<User> GetAsync(int id);

		[Get("/users")]
		Task<MileageRateContainer> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/users")]
		Task PutAsync([Body] User user);

		[Delete("/users/{id}")]
		Task DeleteAsync(int id);
	}
}
