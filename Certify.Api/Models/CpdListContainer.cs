using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of CpdLists
	/// </summary>
	[DataContract]
	public class CpdListContainer
	{
		[DataMember(Name ="CPDLists")]
		public List<CpdList> CpdLists { get; set; }
	}
}