using Certify.Api.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	/// <summary>
	/// A Department interface
	/// </summary>
	public interface IDepartments
	{
		/// <summary>
		/// This method returns a list of one or more departments for the current company.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="code"></param>
		/// <param name="active"></param>
		/// <param name="page"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[Get("/departments")]
		Task<DepartmentPage> GetPageAsync(
			[AliasAs("name")] string? name = null,
			[AliasAs("code")] string? code = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("page")] uint? page = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// For each department element in the POST body, this method will update department
		/// records for the user’s company corresponding to the IDs supplied.
		/// Any elements where new values were not provided will retain their current value.
		/// </summary>
		/// <param name="department"></param>
		/// <param name="cancellationToken"></param>
		/// <returns>A separate status should be returned for each record, either "Updated" or "Error" with a detailed error message.</returns>
		[Post("/departments")]
		Task<List<UpdateResult>> UpdateAsync(
			[Body] Department department,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// This method creates a new department record for the user’s company.
		/// </summary>
		/// <param name="department">The department to create</param>
		/// <param name="cancellationToken">An optional cancellation token</param>
		/// <returns>If successful, this method should return the ID of the new department.</returns>
		[Put("/departments")]
		Task<CreateResult> CreateAsync(
			[Body] Department department,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// This method returns a single department for the current company.
		/// </summary>
		/// <param name="id">Department ID</param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[Get("/departments/{id}")]
		Task<DepartmentPage> GetAsync(
			Guid id,
			CancellationToken cancellationToken = default
			);
	}
}
