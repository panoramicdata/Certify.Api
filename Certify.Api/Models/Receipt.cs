using System;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	///  Receipt
	/// </summary>
	[DataContract]
	public class Receipt : IdentifiedItem
	{
		/// <summary>
		/// Filename of the receipt.
		/// </summary>
		public string Filename { get; set; }

		/// <summary>
		/// Date the receipt was uploaded to the wallet.
		/// </summary>
		public DateTimeOffset UploadDate { get; set; }
	}
}
