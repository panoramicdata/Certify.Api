using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// Expense
	/// </summary>
	[DataContract]
	public class Invoice : IdentifiedItem
	{
		/// <summary>
		///  InvoiceReportID
		/// </summary>
		[DataMember(Name = "InvoiceReportID")]
		public string InvoiceReportID { get; set; }

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
		///  EmployeeEmail
		/// </summary>
		[DataMember(Name = "EmployeeEmail")]
		public string EmployeeEmail { get; set; }

		/// <summary>
		///  EmployeeID
		/// </summary>
		[DataMember(Name = "EmployeeID")]
		public string EmployeeID { get; set; }

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
		///  Category
		/// </summary>
		[DataMember(Name = "Category")]
		public string Category { get; set; }

		/// <summary>
		///  CategoryGLCode
		/// </summary>
		[DataMember(Name = "CategoryGLCode")]
		public string CategoryGLCode { get; set; }

		/// <summary>
		///  InvoiceTextGLD1Label
		/// </summary>
		[DataMember(Name = "InvoiceTextGLD1Label")]
		public string InvoiceTextGLD1Label { get; set; }

		/// <summary>
		///  InvoiceTextGLD1
		/// </summary>
		[DataMember(Name = "InvoiceTextGLD1")]
		public string InvoiceTextGLD1 { get; set; }

		/// <summary>
		///  InvoiceTextGLD2Label
		/// </summary>
		[DataMember(Name = "InvoiceTextGLD2Label")]
		public string InvoiceTextGLD2Label { get; set; }

		/// <summary>
		///  InvoiceTextGLD2
		/// </summary>
		[DataMember(Name = "InvoiceTextGLD2")]
		public string InvoiceTextGLD2 { get; set; }

		/// <summary>
		///  InvoiceReportGLD1Label
		/// </summary>
		[DataMember(Name = "InvoiceReportGLD1Label")]
		public string InvoiceReportGLD1Label { get; set; }

		/// <summary>
		///  InvoiceReportGLD1Name
		/// </summary>
		[DataMember(Name = "InvoiceReportGLD1Name")]
		public string InvoiceReportGLD1Name { get; set; }

		/// <summary>
		///  InvoiceReportGLD1Code
		/// </summary>
		[DataMember(Name = "InvoiceReportGLD1Code")]
		public string InvoiceReportGLD1Code { get; set; }

		/// <summary>
		///  Amount
		/// </summary>
		[DataMember(Name = "Amount")]
		public float Amount { get; set; }

		/// <summary>
		///  Currency
		/// </summary>
		[DataMember(Name = "Currency")]
		public string Currency { get; set; }

		/// <summary>
		///  Reason
		/// </summary>
		[DataMember(Name = "Reason")]
		public string Reason { get; set; }

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
		///  InvoiceDate
		/// </summary>
		[DataMember(Name = "InvoiceDate")]
		public string InvoiceDate { get; set; }

		/// <summary>
		///  InvoiceReportName
		/// </summary>
		[DataMember(Name = "InvoiceReportName")]
		public string InvoiceReportName { get; set; }

		/// <summary>
		///  InvoiceNumber
		/// </summary>
		[DataMember(Name = "InvoiceNumber")]
		public string InvoiceNumber { get; set; }

		/// <summary>
		///  VendorName
		/// </summary>
		[DataMember(Name = "VendorName")]
		public string VendorName { get; set; }

		/// <summary>
		///  VendorID
		/// </summary>
		[DataMember(Name = "VendorID")]
		public string VendorID { get; set; }

		/// <summary>
		///  VendorCode
		/// </summary>
		[DataMember(Name = "VendorCode")]
		public string VendorCode { get; set; }

		/// <summary>
		///  VendorAddress1
		/// </summary>
		[DataMember(Name = "VendorAddress1")]
		public string VendorAddress1 { get; set; }

		/// <summary>
		///  VendorAddress2
		/// </summary>
		[DataMember(Name = "VendorAddress2")]
		public string VendorAddress2 { get; set; }

		/// <summary>
		///  VendorCity
		/// </summary>
		[DataMember(Name = "VendorCity")]
		public string VendorCity { get; set; }

		/// <summary>
		///  VendorStateProvince
		/// </summary>
		[DataMember(Name = "VendorStateProvince")]
		public string VendorStateProvince { get; set; }

		/// <summary>
		///  VendorPostalCode
		/// </summary>
		[DataMember(Name = "VendorPostalCode")]
		public string VendorPostalCode { get; set; }

		/// <summary>
		///  VendorContactName
		/// </summary>
		[DataMember(Name = "VendorContactName")]
		public string VendorContactName { get; set; }

		/// <summary>
		///  VendorCustomerAccountNumber
		/// </summary>
		[DataMember(Name = "VendorCustomerAccountNumber")]
		public string VendorCustomerAccountNumber { get; set; }

		/// <summary>
		///  VendorTaxpayerID
		/// </summary>
		[DataMember(Name = "VendorTaxpayerID")]
		public string VendorTaxpayerID { get; set; }

		/// <summary>
		///  Vendor1099
		/// </summary>
		[DataMember(Name = "Vendor1099")]
		public bool Vendor1099 { get; set; }

		/// <summary>
		///  DueDate
		/// </summary>
		[DataMember(Name = "DueDate")]
		public string DueDate { get; set; }

		/// <summary>
		///  PONumber
		/// </summary>
		[DataMember(Name = "PONumber")]
		public string PONumber { get; set; }

		/// <summary>
		///  POName
		/// </summary>
		[DataMember(Name = "POName")]
		public string POName { get; set; }

		/// <summary>
		///  InvoiceImageLink
		/// </summary>
		[DataMember(Name = "InvoiceImageLink")]
		public string InvoiceImageLink { get; set; }
	}
}
