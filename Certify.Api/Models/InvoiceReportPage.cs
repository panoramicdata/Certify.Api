﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of InvoiceReports
	/// </summary>
	[DataContract]
	public class InvoiceReportPage : Page
	{
		/// <summary>
		/// The InvoiceReports
		/// </summary>
		[DataMember(Name = "InvoiceReports")]
		public List<InvoiceReport> InvoiceReports { get; set; } = new();
	}
}