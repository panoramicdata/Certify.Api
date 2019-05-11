using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A Receipts page
	/// </summary>
	[DataContract]
	public class ReceiptPage : Page
	{
		[DataMember(Name = "Receipts")]
		public List<Receipt> Receipt { get; set; }
	}
}