using Certify.Api.Interfaces;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// Expense
	/// </summary>
	[DataContract]
	public class Expense : IdentifiedItem, ISupportsPaging
	{
		/// <summary>
		///  ExpenseReportId
		/// </summary>
		[DataMember(Name = "ExpenseReportID")]
		public string ExpenseReportId { get; set; }

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
		///  Email
		/// </summary>
		[DataMember(Name = "Email")]
		public string Email { get; set; }

		/// <summary>
		///  EmployeeID
		/// </summary>
		[DataMember(Name = "EmployeeID")]
		public string EmployeeId { get; set; }

		/// <summary>
		///  DepartmentName
		/// </summary>
		[DataMember(Name = "DepartmentName")]
		public string DepartmentName { get; set; }

		/// <summary>
		///  DepartmentCode
		/// </summary>
		[DataMember(Name = "DepartmentCode")]
		public string DepartmentCode { get; set; }

		/// <summary>
		///  ExpenseType
		/// </summary>
		[DataMember(Name = "ExpenseType")]
		public string ExpenseType { get; set; }

		/// <summary>
		///  ExpenseCategory
		/// </summary>
		[DataMember(Name = "ExpenseCategory")]
		public string ExpenseCategory { get; set; }

		/// <summary>
		///  ExpenseCategoryGLCode
		/// </summary>
		[DataMember(Name = "ExpenseCategoryGLCode")]
		public string ExpenseCategoryGLCode { get; set; }

		/// <summary>
		///  Amount
		/// </summary>
		[DataMember(Name = "Amount")]
		public float Amount { get; set; }

		/// <summary>
		///  Billable
		/// </summary>
		[DataMember(Name = "Billable")]
		public bool Billable { get; set; }

		/// <summary>
		///  Reimbursable
		/// </summary>
		[DataMember(Name = "Reimbursable")]
		public bool Reimbursable { get; set; }

		/// <summary>
		///  ReimAmount
		/// </summary>
		[DataMember(Name = "ReimAmount")]
		public float ReimAmount { get; set; }

		/// <summary>
		///  SubmittedAmount
		/// </summary>
		[DataMember(Name = "SubmittedAmount")]
		public float SubmittedAmount { get; set; }

		/// <summary>
		///  ExpenseDate
		/// </summary>
		[DataMember(Name = "ExpenseDate")]
		public string ExpenseDate { get; set; }

		/// <summary>
		///  PostingDate
		/// </summary>
		[DataMember(Name = "PostingDate")]
		public string PostingDate { get; set; }

		/// <summary>
		///  Vendor
		/// </summary>
		[DataMember(Name = "Vendor")]
		public string Vendor { get; set; }

		/// <summary>
		///  ProcessedDate
		/// </summary>
		[DataMember(Name = "ProcessedDate")]
		public string ProcessedDate { get; set; }

		/// <summary>
		///  Processed
		/// </summary>
		[DataMember(Name = "Processed")]
		public bool Processed { get; set; }

		/// <summary>
		///  Currency
		/// </summary>
		[DataMember(Name = "Currency")]
		public string Currency { get; set; }

		/// <summary>
		///  SubmittedCurrency
		/// </summary>
		[DataMember(Name = "SubmittedCurrency")]
		public string SubmittedCurrency { get; set; }

		/// <summary>
		///  Reason
		/// </summary>
		[DataMember(Name = "Reason")]
		public string Reason { get; set; }

		/// <summary>
		///  VATAmount
		/// </summary>
		[DataMember(Name = "VATAmount")]
		public float VATAmount { get; set; }

		/// <summary>
		///  HSTAmount
		/// </summary>
		[DataMember(Name = "HSTAmount")]
		public float HstAmount { get; set; }

		/// <summary>
		///  PSTAmount
		/// </summary>
		[DataMember(Name = "PSTAmount")]
		public float PSTAmount { get; set; }

		/// <summary>
		///  ExpenseTextGLD1Label
		/// </summary>
		[DataMember(Name = "ExpenseTextGLD1Label")]
		public string ExpenseTextGld1Label { get; set; }

		/// <summary>
		///  ExpenseTextGLD1
		/// </summary>
		[DataMember(Name = "ExpenseTextGLD1")]
		public string ExpenseTextGld1 { get; set; }

		/// <summary>
		///  ExpenseTextGLD2Label
		/// </summary>
		[DataMember(Name = "ExpenseTextGLD2Label")]
		public string ExpenseTextGld2Label { get; set; }

		/// <summary>
		///  ExpenseReportGLD1Label
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD1Label")]
		public string ExpenseReportGld1Label { get; set; }

		/// <summary>
		///  ExpenseReportGLD1Name
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD1Name")]
		public string ExpenseReportGld1Name { get; set; }

		/// <summary>
		///  ExpenseReportGLD1Code
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD1Code")]
		public string ExpenseReportGld1Code { get; set; }

		/// <summary>
		///  TravelFrom
		/// </summary>
		[DataMember(Name = "TravelFrom")]
		public string TravelFrom { get; set; }

		/// <summary>
		///  TravelTo
		/// </summary>
		[DataMember(Name = "TravelTo")]
		public string TravelTo { get; set; }

		/// <summary>
		///  ReceiptImageLink
		/// </summary>
		[DataMember(Name = "ReceiptImageLink")]
		public string ReceiptImageLink { get; set; }

		/// <summary>
		///  ReceiptID
		/// </summary>
		[DataMember(Name = "ReceiptID")]
		public string ReceiptId { get; set; }

		/// <summary>
		///  PaymentCardName
		/// </summary>
		[DataMember(Name = "PaymentCardName")]
		public string PaymentCardName { get; set; }

		/// <summary>
		///  CCLast
		/// </summary>
		[DataMember(Name = "CCLast")]
		public string CcLast { get; set; }
	}
}
