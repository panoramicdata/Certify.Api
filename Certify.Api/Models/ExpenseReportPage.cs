using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// An ExpenseReport page
/// </summary>
[DataContract]
public class ExpenseReportPage : Page
{
	/// <summary>
	/// The ExpenseReports
	/// </summary>
	[DataMember(Name = "ExpenseReports")]
	public List<ExpenseReport> ExpenseReports { get; set; } = new();
}