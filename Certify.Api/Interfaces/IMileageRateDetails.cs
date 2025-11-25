using Certify.Api.Models;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Interfaces;

/// <summary>
/// A MileageRateDetails interface
/// </summary>
public interface IMileageRateDetails
{
	/// <summary>
	/// This method returns a list of one or more mileage rate detail records for the current company.
	/// </summary>
	/// <param name="effectiveDateStart">	Starting point for the mileage rate detail effective date.</param>
	/// <param name="effectiveDateEnd">	Ending point for the mileage rate detail effective date.</param>
	/// <param name="page">Desired page of result (1 for page 1, 2 for page 2, n for page n)</param>
	/// <returns></returns>
	[Get("/mileageratedetails")]
	Task<MileageRateDetailsPage> GetPageAsync(
		[AliasAs("effectivedatestart")] string? effectiveDateStart = null,
		[AliasAs("effectivedateend")] string? effectiveDateEnd = null,
		[AliasAs("page")] uint? page = null,
		CancellationToken cancellationToken = default
		);

	/// <summary>
	/// This method creates a new mileage rate detail record for the user’s company.
	/// Detail records can only be added if the parent mileage rate has a FederalMileageRateType of 0 (None).
	/// Certify automatically updates the United States Federal rates as they change over time.
	/// You may overwrite an existing mileage rate detail record by sending a request with a matching MileageRateID and EffectiveDate.
	/// </summary>
	/// <param name="mileageRateDetails">The MileageRateDetails to create</param>
	/// <returns>If successful, this method should return the ID of the new mileage rate detail record.</returns>
	[Put("/mileageratedetails")]
	Task<CreateResult> CreateAsync(
		[Body] MileageRateDetails mileageRateDetails,
		CancellationToken cancellationToken = default
		);
}
