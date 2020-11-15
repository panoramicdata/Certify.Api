using Certify.Api.Interfaces;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	///  Expense report general ledger dimension
	/// </summary>
	[DataContract]
	[DebuggerDisplay("{" + nameof(Name) + "} {" + nameof(Code) + "} {" + nameof(Id) + "}")]
	public class ExpenseReportGld : NamedDescribedIdentifiedItem, ISupportsPaging
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
		public string? ExpRptGldLabel { get; set; }

		/// <summary>
		/// 	The internal code used to identify the expense report GLD in your organization.
		/// </summary>
		[DataMember(Name = "Code")]
		public string? Code { get; set; }
	}
}
