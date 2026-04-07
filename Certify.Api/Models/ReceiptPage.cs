using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// A Receipts page
/// </summary>
[DataContract]
public class ReceiptPage : Page
{
	/// <summary>
	/// Gets or sets the receipts.
	/// </summary>
	[DataMember(Name = "Receipts")]
	public List<Receipt> Receipts { get; set; } = new();
}