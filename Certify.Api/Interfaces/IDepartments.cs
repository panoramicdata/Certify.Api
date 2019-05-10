using Certify.Api.Models;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	public interface IDepartments
	{
		[Post("/departments")]
		Task PostAsync(
			[Body] Department cpd,
			CancellationToken cancellationToken = default
			);

		[Get("/departments/{id}")]
		Task<Department> GetAsync(
			int id,
			CancellationToken cancellationToken = default
			);

		[Get("/departments")]
		Task<DepartmentContainer> GetAllAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null,
			CancellationToken cancellationToken = default
			);

		[Put("/departments")]
		Task PutAsync(
			[Body] Department cpd,
			CancellationToken cancellationToken = default
			);

		[Delete("/departments/{id}")]
		Task DeleteAsync(
			int id,
			CancellationToken cancellationToken = default
			);
	}
}
