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
		/// The internal code used to identify the department in your organization.
		/// </summary>
		[DataMember(Name = "Code")]
		public string Code { get; set; }

		/// <summary>
		/// Indicates that second level approval is required for all expenses in this department (1 = yes, 0 = no)
		/// </summary>
		[DataMember(Name = "ObtainSecondLevelApproval")]
		public int ObtainSecondLevelApproval { get; set; }

		/// <summary>
		/// Indicates that this department will only display those expense categories linked with it (1 = yes, 0 = no)
		/// </summary>
		[DataMember(Name = "UseStrictFiltering")]
		public int UseStrictFiltering { get; set; }

		/// <summary>
		/// Indicates that users in this department don’t need to select a department (1 = yes, 0 = no)
		/// </summary>
		[DataMember(Name = "HideDepartment")]
		public int HideDepartment { get; set; }

		/// <summary>
		/// Indicates that users in this department always select either billable or non-billable expenses (1 = yes, 0 = no)
		/// </summary>
		[DataMember(Name = "HideBillable")]
		public int HideBillable { get; set; }

		/// <summary>
		/// Indicates the default billable value to use for this department (1 = billable, 0 = non-billable)
		/// </summary>
		[DataMember(Name = "HideBillableDefaultValue")]
		public int HideBillableDefaultValue { get; set; }

		/// <summary>
		/// Indicates that users in this department always select either reimbursable or non-reimbursable expenses (1 = yes, 0 = no)
		/// </summary>
		[DataMember(Name = "HideReimbursable")]
		public int HideReimbursable { get; set; }

		/// <summary>
		/// Indicates the default reimbursable value to use for this department (1 = reimbursable, 0 = non-reimbursable)
		/// </summary>
		[DataMember(Name = "HideReimbursableDefaultValue")]
		public int HideReimbursableDefaultValue { get; set; }

		/// <summary>
		/// Indicates the initial page presented to users in this department upon login (Home = 0, CertifyTravel = 1, NewExpenseReport = 2, MyDraftExpenseReports = 3, MyApprovalRequests = 4, MyProcessingRequests = 5, MyCertifyWallet = 6, MyInquiries = 7)
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
