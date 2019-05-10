using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of EmpGlds
	/// </summary>
	[DataContract]
	public class EmpGldContainer
	{
		[DataMember(Name = "EmpGLDs")]
		public List<EmpGld> EmpGlds { get; set; }
	}
}