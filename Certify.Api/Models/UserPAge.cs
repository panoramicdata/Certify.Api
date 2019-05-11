using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A Users page
	/// </summary>
	[DataContract]
	public class UserPage : Page
	{
		[DataMember(Name = "Users")]
		public List<User> Users { get; set; }
	}
}