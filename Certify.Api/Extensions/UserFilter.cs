namespace Certify.Api.Extensions;

/// <summary>
/// Optional filters applied when retrieving all users.
/// </summary>
public class UserFilter
{
	/// <summary>
	/// Optional username filter.
	/// </summary>
	public string? Username { get; set; }

	/// <summary>
	/// Optional active status filter.
	/// </summary>
	public uint? Active { get; set; }

	/// <summary>
	/// Optional role filter.
	/// </summary>
	public string? Role { get; set; }
}
