namespace Certify.Api.Extensions;

/// <summary>
/// Optional filters applied when retrieving all expense report GLDs.
/// </summary>
public class ExpenseReportGldFilter
{
	/// <summary>
	/// Optional name filter.
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Optional code filter.
	/// </summary>
	public string? Code { get; set; }

	/// <summary>
	/// Optional active status filter.
	/// </summary>
	public uint? Active { get; set; }
}
