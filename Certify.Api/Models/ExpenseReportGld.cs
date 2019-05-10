using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	///  Expense report general ledger dimension
	/// </summary>
	[DataContract]
	public class ExpenseReportGld : IdentifiedItem
	{
		/// <summary>
		/// The index
		/// </summary>
		[DataMember(Name = "ExpRptGLDIndex")]
		public int ExpRptGldIndex { get; set; }

		/// <summary>
		/// The label assigned the GLD by the client in Configuration.
		/// </summary>
		[DataMember(Name = "ExpRptGLDLabel")]
		public string ExpRptGldLabel { get; set; }

		/// <summary>
		/// 	The internal code used to identify the expense report GLD in your organization.
		/// </summary>
		[DataMember(Name = "Code")]
		public string Code { get; set; }
	}
}
