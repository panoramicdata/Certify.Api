using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models
{
	/// <summary>
	/// An Expenses page
	/// </summary>
	[DataContract]
	public class ExpensePage : Page
	{
		[DataMember(Name = "Expense")]
		public List<Expense> Expenses { get; set; }
	}
}