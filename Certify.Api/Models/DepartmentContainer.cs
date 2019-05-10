using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of CpdLists
	/// </summary>
	[DataContract]
	public class DepartmentContainer
	{
		[DataMember(Name ="Departments")]
		public List<Department> Departments { get; set; }
	}
}