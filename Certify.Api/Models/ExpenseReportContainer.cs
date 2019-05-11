using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of ExpenseReports
	/// </summary>
	[DataContract]
	public class ExpenseReportContainer : Container
	{
		[DataMember(Name = "ExpenseReports")]
		public List<ExpenseReport> ExpenseReports { get; set; }
	}
}