using System;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// An item with an ID
	/// </summary>
	[DataContract]
	public class IdentifiedItem
	{
		/// <summary>
		/// The unique ID
		/// </summary>
		[DataMember(Name ="ID")]
		public Guid Id { get; set; }
	}
}