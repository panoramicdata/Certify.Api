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
		public float VatAmount { get; set; }

		/// <summary>
		///  HSTAmount
		/// </summary>
		[DataMember(Name = "HSTAmount")]
		public float HstAmount { get; set; }

		/// <summary>
		///  PSTAmount
		/// </summary>
		[DataMember(Name = "PSTAmount")]
		public float PstAmount { get; set; }

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
		///  ExpenseTextGLD2
		/// </summary>
		[DataMember(Name = "ExpenseTextGLD2")]
		public string ExpenseTextGld2 { get; set; }

		/// <summary>
		///  ExpenseTextGLD3Label
		/// </summary>
		[DataMember(Name = "ExpenseTextGLD3Label")]
		public string ExpenseTextGld3Label { get; set; }

		/// <summary>
		///  ExpenseTextGLD3
		/// </summary>
		[DataMember(Name = "ExpenseTextGLD3")]
		public string ExpenseTextGld3 { get; set; }

		/// <summary>
		///  ExpenseTextGLD4Label
		/// </summary>
		[DataMember(Name = "ExpenseTextGLD4Label")]
		public string ExpenseTextGld4Label { get; set; }

		/// <summary>
		///  ExpenseTextGLD4
		/// </summary>
		[DataMember(Name = "ExpenseTextGLD4")]
		public string ExpenseTextGld4 { get; set; }

		/// <summary>
		///  ExpenseTextGLD5Label
		/// </summary>
		[DataMember(Name = "ExpenseTextGLD5Label")]
		public string ExpenseTextGld5Label { get; set; }

		/// <summary>
		///  ExpenseTextGLD5
		/// </summary>
		[DataMember(Name = "ExpenseTextGLD5")]
		public string ExpenseTextGld5 { get; set; }

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
		///  ExpenseReportGLD2Label
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD2Label")]
		public string ExpenseReportGld2Label { get; set; }

		/// <summary>
		///  ExpenseReportGLD2Name
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD2Name")]
		public string ExpenseReportGld2Name { get; set; }

		/// <summary>
		///  ExpenseReportGLD2Code
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD2Code")]
		public string ExpenseReportGld2Code { get; set; }

		/// <summary>
		///  ExpenseReportGLD3Label
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD3Label")]
		public string ExpenseReportGld3Label { get; set; }

		/// <summary>
		///  ExpenseReportGLD3Name
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD3Name")]
		public string ExpenseReportGld3Name { get; set; }

		/// <summary>
		///  ExpenseReportGLD3Code
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD3Code")]
		public string ExpenseReportGld3Code { get; set; }

		/// <summary>
		///  ExpenseReportGLD4Label
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD4Label")]
		public string ExpenseReportGld4Label { get; set; }

		/// <summary>
		///  ExpenseReportGLD4Name
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD4Name")]
		public string ExpenseReportGld4Name { get; set; }

		/// <summary>
		///  ExpenseReportGLD4Code
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD4Code")]
		public string ExpenseReportGld4Code { get; set; }

		/// <summary>
		///  ExpenseReportGLD5Label
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD5Label")]
		public string ExpenseReportGld5Label { get; set; }

		/// <summary>
		///  ExpenseReportGLD5Name
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD5Name")]
		public string ExpenseReportGld5Name { get; set; }

		/// <summary>
		///  ExpenseReportGLD5Code
		/// </summary>
		[DataMember(Name = "ExpenseReportGLD5Code")]
		public string ExpenseReportGld5Code { get; set; }

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

		/// <summary>
		///  Location
		/// </summary>
		[DataMember(Name = "Location")]
		public string Location { get; set; }

		/// <summary>
		///  ExpenseReportName
		/// </summary>
		[DataMember(Name = "ExpenseReportName")]
		public string ExpenseReportName { get; set; }

		/// <summary>
		///  Status
		/// </summary>
		[DataMember(Name = "Status")]
		public string Status { get; set; }

		/// <summary>
		///  LastAction
		/// </summary>
		[DataMember(Name = "LastAction")]
		public string LastAction { get; set; }
	}
}
