using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// A response to an update request
/// </summary>
[DataContract]
public class UpdateResult : IdentifiedItem
{
	/// <summary>
	/// Returns status of "Updated" or "Error".
	/// </summary>
	[DataMember(Name = "Status")]
	public string? Status { get; set; }

	/// <summary>
	/// Detailed message when Status returns an "Error".
	/// </summary>
	[DataMember(Name = "Message")]
	public string? Message { get; set; }
}
