﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of ExpenseReport general ledger dimensions
	/// </summary>
	[DataContract]
	public class ExpenseReportGldContainer : Container
	{
		[DataMember(Name = "ExpenseReportGLDs")]
		public List<ExpenseReportGld> ExpenseReportGlds { get; set; }
	}
}