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
		[DataMember(Name = "expenses")]
		public List<Expense> Expenses { get; set; }
	}
}