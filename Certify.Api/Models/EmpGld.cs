using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
///  Employee General Ledger Dimension
/// </summary>
[DataContract]
public class EmpGld : NamedDescribedIdentifiedItem
{
	/// <summary>
	/// The index
	/// </summary>
	[DataMember(Name = "EmpGLDIndex")]
	public int EmployeeGldIndex { get; set; }

	/// <summary>
	/// The label assigned the GLD by the client in Configuration.
	/// </summary>
	[DataMember(Name = "EmpGLDLabel")]
	public string? EmployeeGldLabel { get; set; }

	/// <summary>
	/// 	The internal code used to identify the expense report GLD in your organization.
	/// </summary>
	[DataMember(Name = "Code")]
	public string? Code { get; set; }
}
