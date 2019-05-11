using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A Department page
	/// </summary>
	[DataContract]
	public class DepartmentPage : Page
	{
		[DataMember(Name ="Departments")]
		public List<Department> Departments { get; set; }
	}
}