using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of Receipts
	/// </summary>
	[DataContract]
	public class ReceiptContainer : Container
	{
		[DataMember(Name = "Receipts")]
		public List<Receipt> Receipt { get; set; }
	}
}