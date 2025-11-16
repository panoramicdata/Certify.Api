using Certify.Api.Extensions;
using Certify.Api.Models;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests;

public class ExpenseReportGldTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		// Test getting the first 5 indexes
		var results = new List<ExpenseReportGldPage>();

		for (uint index = 1; index <= 5; index++)
		{
			var result = await CertifyClient
				.ExpenseReportGlds
				.GetPageAsync(index)
				.ConfigureAwait(false);

			result.Should().NotBeNull();
			result.ExpenseReportGlds.Should().NotBeNullOrEmpty();

			results.Add(result);
		}
	}

	[Fact]
	public async Task GetAll_Succeeds()
	{
		var results2 = await CertifyClient
			.ExpenseReportGlds
			.GetAllAsync(2)
			.ConfigureAwait(false);
		results2.Should().NotBeNullOrEmpty();
	}

	/// <summary>
	/// This is a helper script for making all entries starting with PDL inactive
	/// </summary>
	internal async Task MakeCertainEntriesInactiveAsync()
	{
		var page = await CertifyClient
			.ExpenseReportGlds
			.GetPageAsync(3, active: 1)
			.ConfigureAwait(false);

		var targets = page.ExpenseReportGlds.Where(e => e.Name?.StartsWith("PDL") == true).ToList();
		foreach (var item in targets)
		{
			item.Active = 0;
			await CertifyClient.ExpenseReportGlds.UpdateAsync(3, item).ConfigureAwait(false);
		}
	}
}
