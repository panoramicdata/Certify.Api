using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// A page container
/// </summary>
[DataContract]
public class GenericPage<T>
{
	/// <summary>
	/// Total number of pages.
	/// </summary>
	[DataMember(Name = "PageCount")]
	public uint TotalPageCount { get; set; }

	/// <summary>
	/// Total number or records.
	/// </summary>
	[DataMember(Name = "RecordCount")]
	public uint TotalRecordCount { get; set; }

	/// <summary>
	/// Gets or sets the items.
	/// </summary>
	[DataMember(Name = "Items")]
	public List<T> Items { get; set; } = new();
}
