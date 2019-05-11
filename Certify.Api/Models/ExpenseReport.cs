using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	///  Expense category
	/// </summary>
	[DataContract]
	public class ExpenseReport : IdentifiedItem
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
		///  NonReimAmount
		/// </summary>
		[DataMember(Name = "NonReimAmount")]
		public decimal NonReimAmount { get; set; }

		/// <summary>
		///  ReimAmount
		/// </summary>
		[DataMember(Name = "ReimAmount")]
		public decimal ReimAmount { get; set; }

		/// <summary>
		///  TotalAmount
		/// </summary>
		[DataMember(Name = "TotalAmount")]
		public decimal TotalAmount { get; set; }

		/// <summary>
		///  Currency
		/// </summary>
		[DataMember(Name = "Currency")]
		public string Currency { get; set; }

		/// <summary>
		///  SubmittedDate
		/// </summary>
		[DataMember(Name = "SubmittedDate")]
		public string SubmittedDate { get; set; }

		/// <summary>
		///  InitialApprovalDate
		/// </summary>
		[DataMember(Name = "InitialApprovalDate")]
		public string InitialApprovalDate { get; set; }

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
		///  InitialApproverEmail
		/// </summary>
		[DataMember(Name = "InitialApproverEmail")]
		public string InitialApproverEmail { get; set; }

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
		///  ExpenseReportName
		/// </summary>
		[DataMember(Name = "ExpenseReportName")]
		public string ExpenseReportName { get; set; }

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

		/// <summary>
		///  EmpGLD1Name
		/// </summary>
		[DataMember(Name = "EmpGLD1Name")]
		public string EmpGld1Name { get; set; }

		/// <summary>
		///  EmpGLD1Code
		/// </summary>
		[DataMember(Name = "EmpGLD1Code")]
		public string EmpGld1Code { get; set; }

		/// <summary>
		///  EmpGLD2Name
		/// </summary>
		[DataMember(Name = "EmpGLD2Name")]
		public string EmpGld2Name { get; set; }

		/// <summary>
		///  EmpGLD2Code
		/// </summary>
		[DataMember(Name = "EmpGLD2Code")]
		public string EmpGld2Code { get; set; }

		/// <summary>
		///  EmpGLD3Name
		/// </summary>
		[DataMember(Name = "EmpGLD3Name")]
		public string EmpGld3Name { get; set; }

		/// <summary>
		///  EmpGLD3Code
		/// </summary>
		[DataMember(Name = "EmpGLD3Code")]
		public string EmpGld3Code { get; set; }

		/// <summary>
		///  EmpGLD4Name
		/// </summary>
		[DataMember(Name = "EmpGLD4Name")]
		public string EmpGld4Name { get; set; }

		/// <summary>
		///  EmpGLD4Code
		/// </summary>
		[DataMember(Name = "EmpGLD4Code")]
		public string EmpGld4Code { get; set; }

		/// <summary>
		///  EmpGLD5Name
		/// </summary>
		[DataMember(Name = "EmpGLD5Name")]
		public string EmpGld5Name { get; set; }

		/// <summary>
		///  EmpGLD5Code
		/// </summary>
		[DataMember(Name = "EmpGLD5Code")]
		public string EmpGld5Code { get; set; }
	}

}
