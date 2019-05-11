using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Certify.Api.Models
{
	/// <summary>
	/// A page container
	/// </summary>
	[DataContract]
	public abstract class Page : Container
	{
		/// <summary>
		/// Current page being returned.
		/// </summary>
		[DataMember(Name = "Page")]
		public uint PageNumber { get; set; }

		/// <summary>
		/// Total number of pages.
		/// </summary>
		[DataMember(Name = "PageCount")]
		public uint TotalPageCount { get; set; }

		/// <summary>
		/// Number of records on current page.
		/// </summary>
		[DataMember(Name= "Records")]
		public uint PageRecordCount { get; set; }

		/// <summary>
		/// Total number or records.
		/// </summary>
		[DataMember(Name = "RecordCount")]
		public uint TotalRecordCount { get; set; }
	}
}
