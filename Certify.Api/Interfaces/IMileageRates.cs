using Certify.Api.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces
{
	/// <summary>
	/// A MileageRate interface
	/// </summary>
	public interface IMileageRates
	{
		/// <summary>
		/// This method returns a list of one or more mileage rates for the current company.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		[Get("/mileagerates")]
		Task<MileageRatePage> GetPageAsync(
			[AliasAs("name")] string name = null,
			[AliasAs("page")] uint? page = null);

		/// <summary>
		/// For each mileage rate element in the POST body, this method will update mileage
		/// rate records for the user’s company corresponding to the IDs supplied.
		/// Any elements where new values were not provided will retain their current value.
		/// </summary>
		/// <param name="mileageRates">The MileageRates to update</param>
		/// <returns>A separate status should be returned for each record, either "Updated" or "Error" with a detailed error message.</returns>
		[Post("/mileagerates")]
		Task<List<UpdateResult>> UpdateAsync(
			[Body] List<MileageRate> mileageRates
			);

		/// <summary>
		/// This method creates a new mileage rate record for the current company.
		/// </summary>
		/// <param name="mileageRate">The MileageRate</param>
		/// <returns></returns>
		[Put("/mileagerates")]
		Task<CreateResult> CreateAsync(
			[Body] MileageRate mileageRate
			);
	}
}
