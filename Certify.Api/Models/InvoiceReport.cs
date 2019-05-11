using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	///  Invoice category
	/// </summary>
	[DataContract]
	public class InvoiceReport : IdentifiedItem
	{
		/// <summary>
		///  EmployeeDepartment
		/// </summary>
		[DataMember(Name = "EmployeeDepartment")]
		public string EmployeeDepartment { get; set; }

		/// <summary>
		///  FirstName
		/// </summary>
		[DataMember(Name = "FirstName")]
		public string FirstName { get; set; }

		/// <summary>
		///  LastName
		/// </summary>
		[DataMember(Name = "LastName")]
		public string LastName { get; set; }

		/// <summary>
		///  EmployeeID
		/// </summary>
		[DataMember(Name = "EmployeeID")]
		public string EmployeeId { get; set; }

		/// <summary>
		///  TotalAmount
		/// </summary>
		[DataMember(Name = "TotalAmount")]
		public float TotalAmount { get; set; }

		/// <summary>
		///  Currency
		/// </summary>
		[DataMember(Name = "Currency")]
		public string Currency { get; set; }

		/// <summary>
		///  ProcessedDate
		/// </summary>
		[DataMember(Name = "ProcessedDate")]
		public string ProcessedDate { get; set; }

		/// <summary>
		///  ApprovalCode
		/// </summary>
		[DataMember(Name = "ApprovalCode")]
		public int ApprovalCode { get; set; }

		/// <summary>
		///  StartDate
		/// </summary>
		[DataMember(Name = "StartDate")]
		public string StartDate { get; set; }

		/// <summary>
		///  EndDate
		/// </summary>
		[DataMember(Name = "EndDate")]
		public string EndDate { get; set; }

		/// <summary>
		///  InvoiceReportName
		/// </summary>
		[DataMember(Name = "InvoiceReportName")]
		public string InvoiceReportName { get; set; }

		/// <summary>
		///  APSyncComplete
		/// </summary>
		[DataMember(Name = "APSyncComplete")]
		public bool APSyncComplete { get; set; }

		/// <summary>
		///  Reimbursed
		/// </summary>
		[DataMember(Name = "Reimbursed")]
		public bool Reimbursed { get; set; }

		/// <summary>
		///  ReimbursedDate
		/// </summary>
		[DataMember(Name = "ReimbursedDate")]
		public string ReimbursedDate { get; set; }

		/// <summary>
		///  ReimbursementTransactionID
		/// </summary>
		[DataMember(Name = "ReimbursementTransactionID")]
		public string ReimbursementTransactionId { get; set; }
	}
}
