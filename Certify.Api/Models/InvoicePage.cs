using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A page of Invoices
	/// </summary>
	[DataContract]
	public class InvoicePage : Page
	{
		[DataMember(Name = "Invoices")]
		public List<Invoice> Invoices { get; set; }
	}
}