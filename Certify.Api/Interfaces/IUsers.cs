using Certify.Api.Models;
using Refit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	/// <summary>
	/// A User interface
	/// </summary>
	public interface IUsers
	{
		/// <summary>
		/// This method will return a list of one or more users.
		/// </summary>
		/// <param name="username"></param>
		/// <param name="active"></param>
		/// <param name="role"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		[Get("/users")]
		Task<UserPage> GetPageAsync(
			[AliasAs("username")] string? username = null,
			[AliasAs("active")] uint? active = null,
			[AliasAs("role")] string? role = null,
			[AliasAs("page")] uint? page = null,
			CancellationToken cancellationToken = default
			);

		/// <summary>
		/// This method should return a specific user associated with the supplied ID value.
		/// </summary>
		/// <param name="id">The User ID</param>
		/// <returns></returns>
		[Get("/users/{id}")]
		Task<UserPage> GetAsync(
			Guid id,
			CancellationToken cancellationToken = default
			);
	}
}
