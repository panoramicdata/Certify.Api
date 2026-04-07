using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// A container for a list of ExpenseReport general ledger dimensions
/// </summary>
[DataContract]
public class ExpenseReportGldPage : Page
{
	/// <summary>
	/// Gets or sets the expense report GLDs.
	/// </summary>
	[DataMember(Name = "ExpRptGLDs")]
	public List<ExpenseReportGld> ExpenseReportGlds { get; set; } = new();
}