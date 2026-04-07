using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// A MileageRatesDetails page
/// </summary>
[DataContract]
public class MileageRateDetailsPage : Page
{
	/// <summary>
	/// Gets or sets the mileage rates.
	/// </summary>
	[DataMember(Name = "MileageRates")]
	public List<MileageRateDetails> MileageRates { get; set; } = new();
}