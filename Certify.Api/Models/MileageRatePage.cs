using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of MileageRates
	/// </summary>
	[DataContract]
	public class MileageRatePage : Page
	{
		/// <summary>
		/// The mileage rates
		/// </summary>
		[DataMember(Name = "MileageRates")]
		public List<MileageRate> MileageRates { get; set; }
	}
}