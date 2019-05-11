using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of MileageRatesDetails
	/// </summary>
	[DataContract]
	public class MileageRateDetailsContainer : Container
	{
		[DataMember(Name = "MileageRates")]
		public List<MileageRateDetails> MileageRates { get; set; }
	}
}