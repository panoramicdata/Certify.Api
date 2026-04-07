using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// A Users page
/// </summary>
[DataContract]
public class UserPage : Page
{
	/// <summary>
	/// Gets or sets the users.
	/// </summary>
	[DataMember(Name = "Users")]
	public List<User> Users { get; set; } = new();
}