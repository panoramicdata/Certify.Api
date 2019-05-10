using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// An item with an ID, Name and Description
	/// </summary>
	public abstract class NamedDescribedIdentifiedItem : IdentifiedItem
	{
		/// <summary>
		/// The name
		/// </summary>
		[DataMember(Name = "Name")]
		public string Name { get; set; }

		/// <summary>
		/// The internal description
		/// </summary>
		[DataMember(Name = "Description")]

		public string Description { get; set; }
		/// <summary>
		/// Used to store various internal code values.
		/// </summary>
		[DataMember(Name = "Data")]
		public string Data { get; set; }

		/// <summary>
		/// The active status (1 = active, 0 = inactive)
		/// </summary>
		[DataMember(Name = "Active")]
		public int Active { get; set; }
	}
}