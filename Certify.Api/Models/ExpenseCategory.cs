using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	///  Expense category
	/// </summary>
	[DataContract]
	public class ExpenseCategory : NamedDescribedIdentifiedItem
	{
		/// <summary>
		///  The expense type ID (1 = Cash Expense, 2 = Mileage, 3 = Lodging, 4 = Meals, 5 = Rentals, 6 = Travel, 7 = Per-Diem, 8 = Hourly, 9 = Invoice)
		/// </summary>
		[DataMember(Name = "ExpenseTypeID")]
		public int ExpenseTypeId { get; set; }

		/// <summary>
		///  The maximum expense amount permitted for this expense category.
		/// </summary>
		[DataMember(Name = "MaxAmount")]
		public decimal MaxAmount { get; set; }

		/// <summary>
		///  The currency code for the maximum amount (i.e. ‘GBP’, ‘USD’).
		/// </summary>
		[DataMember(Name = "MaxAmountCurrencyType")]
		public string MaxAmountCurrencyType { get; set; }

		/// <summary>
		///  The general ledger code associated with this expense category.
		/// </summary>
		[DataMember(Name = "GLCode")]
		public string GeneralLedgerCode { get; set; }

		/// <summary>
		///  The ID of the department associated with this expense category.
		/// </summary>
		[DataMember(Name = "FilterDepartmentID")]
		public string FilterDepartmentId { get; set; }

		/// <summary>
		///  The prepaid code associated with this expense category (cash expense types only).
		/// </summary>
		[DataMember(Name = "PrepaidCode")]
		public string PrepaidCode { get; set; }

		/// <summary>
		///  Determines whether this category will use the standard receipt requirement threshold amount, or override it (0 = Inherit From Policy, 1 = Use Threshold Amount).
		/// </summary>
		[DataMember(Name = "RequireReceiptOverride")]
		public int RequireReceiptOverride { get; set; }

		/// <summary>
		///  Sets the override threshold amount for this category.
		/// </summary>
		[DataMember(Name = "RequireReceiptThresholdAmount")]
		public decimal RequireReceiptThresholdAmount { get; set; }

		/// <summary>
		///  Require detailed meal attendees (1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "DetailedMealAttendees")]
		public int DetailedMealAttendees { get; set; }

		/// <summary>
		///  Designates the category as pertaining to personal expenses (1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "PersonalExpenses")]
		public int PersonalExpenses { get; set; }

		/// <summary>
		///  Require a reason for expenses in this category (1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "RequireReason")]
		public int RequireReason { get; set; }

		/// <summary>
		///  Setting strict filtering exception to true will make this category available for all departments, regardless of other filtering settings (companies using strict filtering only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "StrictFilteringException")]
		public int StrictFilteringException { get; set; }

		/// <summary>
		///  Hide the billable option for this category (1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "SupressBillable")]
		public int SupressBillable { get; set; }

		/// <summary>
		///  For categories where SuppressBillable = 1, sets the default billable status for the category (1 = billable, 0 = non-billable).
		/// </summary>
		[DataMember(Name = "SupressBillableDefaultValue")]
		public int SupressBillableDefaultValue { get; set; }

		/// <summary>
		///  	If set to one, a user’s commute will be excluded from mileage expenses within this category (mileage expenses only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "DeductCommuteUnits")]
		public int DeductCommuteUnits { get; set; }

		/// <summary>
		///  If set to 1, all expenses in this expense category are treated as cash advances (1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "CashAdvances")]
		public int CashAdvances { get; set; }

		/// <summary>
		///  If set to 1, all expenses in this category will be included in a user’s daily meal limit (1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "DailyMealLimit")]
		public int DailyMealLimit { get; set; }

		/// <summary>
		///  Show Physician (companies using NPI only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "UseNPI")]
		public int UseNPI { get; set; }

		/// <summary>
		///  Require Physician (companies using NPI only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "RequireNPI")]
		public int RequireNPI { get; set; }

		/// <summary>
		///  Expense category used for CPD breakfast expenses (meal expense types for companies using CPD only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "CPDBreakfast")]
		public int CpdBreakfast { get; set; }

		/// <summary>
		///  Expense category used for CPD lunch expenses (meal expense types for companies using CPD only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "CPDLunch")]
		public int CpdLunch { get; set; }

		/// <summary>
		///  Expense category used for CPD dinner expenses (meal expense types for companies using CPD only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "CPDDinner")]
		public int CpdDinner { get; set; }

		/// <summary>
		///  Expense category used for CPD incidental expenses (cash expense types for companies using CPD only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "CPDIncidentals")]
		public int CpdIncidentals { get; set; }

		/// <summary>
		///  Expense category used for CPD lodging expenses (companies using CPD only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "CPDLodging")]
		public int CpdLodging { get; set; }

		/// <summary>
		///  CPD reimbursement method (companies using CPD only; 0 = Expense Amount Capped, 1 = CPD Amount, 2 = CPD Amount No Expense Amount).
		/// </summary>
		[DataMember(Name = "CPDReimbursementMethodID")]
		public int CpdReimbursementMethodId { get; set; }

		/// <summary>
		///  The unique ID of the Custom Per Diem List.
		/// </summary>
		[DataMember(Name = "CPDListID")]
		public string CpdListId { get; set; }

		/// <summary>
		///  Expense category uses GSA (companies using GSA only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "UseGSA")]
		public int UseGsa { get; set; }

		/// <summary>
		///  	Expense category used for GSA breakfast expenses (meal expense types for companies using GSA only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "GSABreakfast")]
		public int GsaBreakfast { get; set; }

		/// <summary>
		///  Expense category used for GSA lunch expenses (meal expense types for companies using GSA only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "GSALunch")]
		public int GsaLunch { get; set; }

		/// <summary>
		///  Expense category used for GSA dinner expenses (meal expense types for companies using GSA only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "GSADinner")]
		public int GsaDinner { get; set; }

		/// <summary>
		///  Expense category used for GSA incidental expenses (cash expense types for companies using GSA only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "GSAIncidentals")]
		public int GsaIncidentals { get; set; }

		/// <summary>
		///  Expense category used for GSA lodging expenses (companies using GSA only; 1 = true, 0 = false).
		/// </summary>
		[DataMember(Name = "GSALodging")]
		public int GsaLodging { get; set; }

		/// <summary>
		///  GSA reimbursement method (companies using GSA only; 0 = Expense Amount Capped, 1 = GSA Amount, 2 = GSA Amount No Expense Amount).
		/// </summary>
		[DataMember(Name = "GSAReimbursementMethodID")]
		public int GSAReimbursementMethodId { get; set; }
	}
}
