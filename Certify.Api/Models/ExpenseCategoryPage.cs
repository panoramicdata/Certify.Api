using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Certify.Api.Models;

/// <summary>
/// A container for a list of ExpenseCategories
/// </summary>
[DataContract]
public class ExpenseCategoryPage : Page
{
	/// <summary>
	/// Gets or sets the expense categories.
	/// </summary>
	[DataMember(Name = "ExpenseCategories")]
	public List<ExpenseCategory> ExpenseCategories { get; set; } = new();
}