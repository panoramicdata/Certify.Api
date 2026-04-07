using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// An Expenses page
/// </summary>
[DataContract]
public class ExpensePage : Page
{
	/// <summary>
	/// Gets or sets the expenses.
	/// </summary>
	[DataMember(Name = "expenses")]
	public List<Expense> Expenses { get; set; } = new();
}