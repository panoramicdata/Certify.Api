using Certify.Api.Models;
using Refit;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	/// <summary>
	/// A Custom Per Diem List interface
	/// </summary>
	public interface ICpdLists
	{
		/// <summary>
		/// This method should return a custom per-diem list associated with the supplied ID value, returning the same elements as the GET /cpdlists method.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[Get("/cpdlists/{id}")]
		Task<CpdList> GetAsync(int id);

		/// <summary>
		/// This method will return a list of one or more custom per-diem lists for the current company.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="active"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		[Get("/cpdlists")]
		Task<CpdListContainer> GetPageAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null);
	}
}
