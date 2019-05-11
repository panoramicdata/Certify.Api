using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of Users
	/// </summary>
	[DataContract]
	public class UserContainer : Container
	{
		[DataMember(Name = "Users")]
		public List<User> Users { get; set; }
	}
}