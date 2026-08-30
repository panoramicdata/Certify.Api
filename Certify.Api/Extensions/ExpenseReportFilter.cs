namespace Certify.Api.Extensions;

/// <summary>
/// Optional filters applied when retrieving all expense reports.
/// </summary>
public class ExpenseReportFilter
{
	/// <summary>
	/// Optional approval code filter.
	/// </summary>
	public string? ApprovalCode { get; set; }

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
	/// Optional reimbursed status filter.
	/// </summary>
	public string? Reimbursed { get; set; }

	/// <summary>
	/// Optional reimbursed start date filter. (YYYY-MM-DD)
	/// </summary>
	public string? ReimbursedStartDate { get; set; }

	/// <summary>
	/// Optional reimbursed end date filter. (YYYY-MM-DD)
	/// </summary>
	public string? ReimbursedEndDate { get; set; }
}
