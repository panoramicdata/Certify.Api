using Certify.Api.Interfaces;
using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
///  Expense category
/// </summary>
[DataContract]
public class ExpenseReport : IdentifiedItem, ISupportsPaging
{
	/// <summary>
	///  Department of the employee who the expense report belongs to.
	/// </summary>
	[DataMember(Name = "EmployeeDepartment")]
	public string? EmployeeDepartment { get; set; }

	/// <summary>
	///  First name of the employee who the expense report belongs to.
	/// </summary>
	[DataMember(Name = "FirstName")]
	public string? FirstName { get; set; }

	/// <summary>
	///  Last name of the employee who the expense report belongs to.
	/// </summary>
	[DataMember(Name = "LastName")]
	public string? LastName { get; set; }

	/// <summary>
	///  EmployeeID of the employee who the expense report belongs to.
	/// </summary>
	[DataMember(Name = "EmployeeID")]
	public string? EmployeeId { get; set; }

	/// <summary>
	///  Total non-reimbursable amount of the expense report.
	/// </summary>
	[DataMember(Name = "NonReimAmount")]
	public decimal NonReimAmount { get; set; }

	/// <summary>
	///  Total reimbursable amount of the expense report.
	/// </summary>
	[DataMember(Name = "ReimAmount")]
	public decimal ReimAmount { get; set; }

	/// <summary>
	///  Total amount, non-reimbursable + non-reimbursable amounts.
	/// </summary>
	[DataMember(Name = "TotalAmount")]
	public decimal TotalAmount { get; set; }

	/// <summary>
	///  	Three letter code of the currency of the expense report. ISO 4217 format.
	/// </summary>
	[DataMember(Name = "Currency")]
	public string? Currency { get; set; }

	/// <summary>
	///  	The date the expense report was submitted for approval (yyyy-MM-dd).
	/// </summary>
	[DataMember(Name = "SubmittedDate")]
	public string? SubmittedDate { get; set; }

	/// <summary>
	///  	Date the first user approved the expense report.
	/// </summary>
	[DataMember(Name = "InitialApprovalDate")]
	public string? InitialApprovalDate { get; set; }

	/// <summary>
	/// Indicates whether the expense report has been processed. (true/false)
	/// </summary>
	[DataMember(Name = "Processed")]
	public bool Processed { get; set; }

	/// <summary>
	///  Date on which the expense report was processed. (YYYY-MM-DD)
	/// </summary>
	[DataMember(Name = "ProcessedDate")]
	public string? ProcessedDate { get; set; }

	/// <summary>
	///  	Email address of the first user to approve the expense report.
	/// </summary>
	[DataMember(Name = "ApprovalCode")]
	public int ApprovalCode { get; set; }

	/// <summary>
	///  	Approval code of the expense report.
	/// </summary>
	[DataMember(Name = "InitialApproverEmail")]
	public string? InitialApproverEmail { get; set; }

	/// <summary>
	///	Start date of the expense report. (YYYY-MM-DD)
	/// </summary>
	[DataMember(Name = "StartDate")]
	public string? StartDate { get; set; }

	/// <summary>
	///  End date of the expense report. (YYYY-MM-DD)
	/// </summary>
	[DataMember(Name = "EndDate")]
	public string? EndDate { get; set; }

	/// <summary>
	///  	Name of the expense report.
	/// </summary>
	[DataMember(Name = "ExpenseReportName")]
	public string? Name { get; set; }

	/// <summary>
	///  Indicates whether the expense report has been synchronized with a third party AP system. (true/false)
	/// </summary>
	[DataMember(Name = "APSyncComplete")]
	public bool APSyncComplete { get; set; }

	/// <summary>
	///  	Indicates whether the expense report has been reimbursed. (true/false)
	/// </summary>
	[DataMember(Name = "Reimbursed")]
	public bool Reimbursed { get; set; }

	/// <summary>
	///  Indicates date the expense report was reimbursed. (YYYY-MM-DD)
	/// </summary>
	[DataMember(Name = "ReimbursedDate")]
	public string? ReimbursedDate { get; set; }

	/// <summary>
	///  The numeric ACH transaction ID or 'Manual Pay'.
	/// </summary>
	[DataMember(Name = "ReimbursementTransactionID")]
	public string? ReimbursementTransactionId { get; set; }

	/// <summary>
	///  	The name of the value of the Employee General Ledger Dimension 1.
	/// </summary>
	[DataMember(Name = "EmpGLD1Name")]
	public string? EmpGld1Name { get; set; }

	/// <summary>
	///  The code of the value of the Employee General Ledger Dimension 1.
	/// </summary>
	[DataMember(Name = "EmpGLD1Code")]
	public string? EmpGld1Code { get; set; }

	/// <summary>
	///  The name of the value of the Employee General Ledger Dimension 2.
	/// </summary>
	[DataMember(Name = "EmpGLD2Name")]
	public string? EmpGld2Name { get; set; }

	/// <summary>
	///  The code of the value of the Employee General Ledger Dimension 2.
	/// </summary>
	[DataMember(Name = "EmpGLD2Code")]
	public string? EmpGld2Code { get; set; }

	/// <summary>
	///  The name of the value of the Employee General Ledger Dimension 3.
	/// </summary>
	[DataMember(Name = "EmpGLD3Name")]
	public string? EmpGld3Name { get; set; }

	/// <summary>
	///  The code of the value of the Employee General Ledger Dimension 3.
	/// </summary>
	[DataMember(Name = "EmpGLD3Code")]
	public string? EmpGld3Code { get; set; }

	/// <summary>
	///  The name of the value of the Employee General Ledger Dimension 4.
	/// </summary>
	[DataMember(Name = "EmpGLD4Name")]
	public string? EmpGld4Name { get; set; }

	/// <summary>
	///  The code of the value of the Employee General Ledger Dimension 4.
	/// </summary>
	[DataMember(Name = "EmpGLD4Code")]
	public string? EmpGld4Code { get; set; }

	/// <summary>
	///  The name of the value of the Employee General Ledger Dimension 5.
	/// </summary>
	[DataMember(Name = "EmpGLD5Name")]
	public string? EmpGld5Name { get; set; }

	/// <summary>
	///  The code of the value of the Employee General Ledger Dimension 5.
	/// </summary>
	[DataMember(Name = "EmpGLD5Code")]
	public string? EmpGld5Code { get; set; }
}
