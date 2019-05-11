using System;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// Mileage rate details
	/// </summary>
	[DataContract]
	public class MileageRateDetails : IdentifiedItem
	{
		/// <summary>
		///  Unique ID of the mileage rate detail record
		/// </summary>
		[DataMember(Name = "MileageRateID")]
		public string MileageRateId { get; set; }

		/// <summary>
		///  The date upon which the rate will take effect
		/// </summary>
		[DataMember(Name = "EffectiveDate")]
		public DateTimeOffset EffectiveDate { get; set; }

		/// <summary>
		///  Three letter code of the currency of the invoice report. ISO 4217 format
		/// </summary>
		[DataMember(Name = "MileageRateCurrency")]
		public string MileageRateCurrency { get; set; }

		/// <summary>
		///  The mileage unit of measure (mi or km)
		/// </summary>
		[DataMember(Name = "DistanceUnits")]
		public string DistanceUnits { get; set; }

		/// <summary>
		///  The primary mileage rate
		/// </summary>
		[DataMember(Name = "PrimaryRate")]
		public decimal PrimaryRate { get; set; }

		/// <summary>
		///  The secondary mileage rate
		/// </summary>
		[DataMember(Name = "SecondaryRate")]
		public decimal SecondaryRate { get; set; }

		/// <summary>
		///  The number of miles/kilometers upon which the secondary rate is applied
		/// </summary>
		[DataMember(Name = "SecondaryRateThreshold")]
		public int SecondaryRateThreshold { get; set; }

		/// <summary>
		///  The tertiary mileage rate
		/// </summary>
		[DataMember(Name = "TertiaryRate")]
		public decimal TertiaryRate { get; set; }

		/// <summary>
		///  The number of miles/kilometers upon which the tertiary rate is applied
		/// </summary>
		[DataMember(Name = "TertiaryRateThreshold")]
		public int TertiaryRateThreshold { get; set; }

		/// <summary>
		///  The quaternary mileage rate
		/// </summary>
		[DataMember(Name = "QuaternnaryRate")]
		public decimal QuaternnaryRate { get; set; }

		/// <summary>
		///  The number of miles/kilometers upon which the quaternary rate is applied
		/// </summary>
		[DataMember(Name = "QuaternnaryRateThreshold")]
		public int QuaternnaryRateThreshold { get; set; }
	}
}
