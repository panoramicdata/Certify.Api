using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// A container for a list of Expenses
	/// </summary>
	[DataContract]
	public class ExpenseContainer : Container
	{
		[DataMember(Name = "Expense")]
		public List<Expense> Expenses { get; set; }
	}
}