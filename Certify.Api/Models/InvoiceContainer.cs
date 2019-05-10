﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of Invoices
	/// </summary>
	[DataContract]
	public class InvoiceContainer
	{
		[DataMember(Name = "Invoices")]
		public List<Invoice> Invoices { get; set; }
	}
}