using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// A container for a list of EmpGlds
/// </summary>
[DataContract]
public class EmpGldPage : Page
{
	/// <summary>
	/// The Employee GLDs
	/// </summary>
	[DataMember(Name = "EmpGLDs")]
	public List<EmpGld> EmployeeGlds { get; set; } = new();
}