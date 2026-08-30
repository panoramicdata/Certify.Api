namespace Certify.Api.Extensions;

/// <summary>
/// Optional filters applied when retrieving all expenses.
/// </summary>
public class ExpenseFilter
{
	/// <summary>
	/// Optional start date filter. (YYYY-MM-DD)
	/// </summary>
	public string? StartDate { get; set; }

	/// <summary>
	/// Optional end date filter. (YYYY-MM-DD)
	/// </summary>
	public string? EndDate { get; set; }

	/// <summary>
	/// Optional batch ID filter.
	/// </summary>
	public string? BatchId { get; set; }

	/// <summary>
	/// Optional processed status filter.
	/// </summary>
	public uint? Processed { get; set; }

	/// <summary>
	/// Optional include disapproved filter.
	/// </summary>
	public uint? IncludeDisapproved { get; set; }
}
