using Certify.Api.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	/// <summary>
	/// An employee General Ledger Dimension interface
	/// </summary>
	public interface IEmpGlds
	{
		/// <summary>
		/// This method will return a list of one or more employee GLD records for the current company.
		/// </summary>
		/// <param name="index">Employee GLD index</param>
		/// <param name="name">Name of employee GLD</param>
		/// <param name="code">Employee GLD code</param>
		/// <param name="active">Active status</param>
		/// <returns></returns>
		[Get("/empglds/{index}")]
		Task<EmpGld> GetAsync(
			[AliasAs("index")] uint index,
			[AliasAs("name")] string name = null,
			[AliasAs("code")] string code = null,
			[AliasAs("active")] uint? active = null
			);

		/// <summary>
		/// For each employee GLD element in the POST body, this method will update employee
		/// GLD records for the current company corresponding to the IDs supplied.
		/// Any elements where new values were not provided will retain their current value.
		/// </summary>
		/// <param name="index">Employee GLD index</param>
		/// <returns>A separate status should be returned for each record, either "Updated" or "Error" with a detailed error message.</returns>
		[Post("/empglds/{index}")]
		Task<List<UpdateResult>> UpdateAsync(
			[AliasAs("index")] uint index
			);

		/// <summary>
		/// This method returns an employee GLD record associated with the supplied ID value.
		/// </summary>
		/// <param name="index">Employee GLD index</param>
		/// <param name="id">Employee GLD ID</param>
		/// <returns></returns>
		[Get("/empglds/{index}/{id}")]
		Task<EmpGld> GetAsync(
			[AliasAs("index")] uint index,
			[AliasAs("id")] Guid Id
			);

		[Put("/empglds")]
		Task PutAsync([Body] EmpGld empGld);
	}
}
