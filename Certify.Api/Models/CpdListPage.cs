using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// A CpdLists page
/// </summary>
[DataContract]
public class CpdListPage : Page
{
	/// <summary>
	/// The CPD Lists
	/// </summary>
	[DataMember(Name = "CPDLists")]
	public List<CpdList> CpdLists { get; set; } = new();
}