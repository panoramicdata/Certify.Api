using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// MileageRate
/// </summary>
[DataContract]
public class MileageRate : IdentifiedItem
{
	/// <summary>
	/// Name
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Indicates the standard United States Federal mileage rate type (0 = None, 1 = Business, 2 = Medical and Moving, 3 = Charitable)
	/// </summary>
	public int FederalMileageRateType { get; set; }

	/// <summary>
	/// The expense category ID
	/// </summary>
	public string? ExpenseCategoryId { get; set; }
}
