using System;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	///  Department
	/// </summary>
	[DataContract]
	public class Department : NamedDescribedIdentifiedItem
	{
		/// <summary>
		/// The code
		/// </summary>
		[DataMember(Name = "Code")]
		public string Code { get; set; }

		/// <summary>
		/// Whether second level approval has been obtained
		/// </summary>
		[DataMember(Name = "ObtainSecondLevelApproval")]
		public int ObtainSecondLevelApproval { get; set; }

		/// <summary>
		/// Whether to use strict filtering
		/// </summary>
		[DataMember(Name = "UseStrictFiltering")]
		public int UseStrictFiltering { get; set; }

		/// <summary>
		/// Whether the department is hidden
		/// </summary>
		[DataMember(Name = "HideDepartment")]
		public int HideDepartment { get; set; }

		/// <summary>
		/// Whether to hide the form billable option
		/// </summary>
		[DataMember(Name = "HideBillable")]
		public int HideBillable { get; set; }

		/// <summary>
		/// Whether to hide the billable default value
		/// </summary>
		[DataMember(Name = "HideBillableDefaultValue")]
		public int HideBillableDefaultValue { get; set; }

		/// <summary>
		/// Whether to hide the form Reimbursable option
		/// </summary>
		[DataMember(Name = "HideReimbursable")]
		public int HideReimbursable { get; set; }

		/// <summary>
		/// Whether to hide the Reimbursable default value
		/// </summary>
		[DataMember(Name = "HideReimbursableDefaultValue")]
		public int HideReimbursableDefaultValue { get; set; }

		/// <summary>
		/// The initial page
		/// </summary>
		[DataMember(Name = "InitialPage")]
		public int InitialPage { get; set; }

		/// <summary>
		/// The last modified date
		/// </summary>
		[DataMember(Name = "LastModifiedDate")]
		public DateTimeOffset LastModifiedDate { get; set; }
	}
}
