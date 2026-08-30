using Certify.Api.Models;
using Refit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces;

/// <summary>
/// A Custom Per Diem List interface
/// </summary>
public interface ICpdLists
{
	/// <summary>
	/// This method will return a list of one or more custom per-diem lists for the current company.
	/// </summary>
	/// <param name="name">Name filter, or null for all names.</param>
	/// <param name="active">Active status filter, or null for any status.</param>
	/// <param name="page">Desired page of results, or null for the first page.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>A page of custom per-diem lists.</returns>
	[Get("/cpdlists")]
	Task<CpdListPage> GetPageAsync(
		[AliasAs("name")] string? name,
		[AliasAs("active")] uint? active,
		[AliasAs("page")] uint? page,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// This method should return a custom per-diem list associated with the supplied ID value, returning the same elements as the GET /cpdlists method.
	/// </summary>
	/// <param name="id">The custom per-diem list ID.</param>
	/// <param name="cancellationToken">A cancellation token.</param>
	/// <returns>The custom per-diem list.</returns>
	[Get("/cpdlists/{id}")]
	Task<CpdList> GetAsync(
		Guid id,
		CancellationToken cancellationToken
		);
}
