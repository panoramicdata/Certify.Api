using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IEmpGlds
	{
		[Post("/empglds")]
		Task PostAsync([Body] EmpGld cpd);

		[Get("/empglds/{id}")]
		Task<EmpGld> GetAsync(int id);

		[Get("/empglds")]
		Task<EmpGldContainer> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);

		[Put("/empglds")]
		Task PutAsync([Body] EmpGld cpd);

		[Delete("/empglds/{id}")]
		Task DeleteAsync(int id);
	}
}
