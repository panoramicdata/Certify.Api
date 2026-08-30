using AwesomeAssertions;
using Certify.Api.Extensions;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test.ModelTests;

public class ExpenseReportTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.ExpenseReports
			.GetPageAsync(cancellationToken: CancellationToken);

		AssertPopulatedPage(page);
		page.ExpenseReports.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task GetAll_Succeeds()
	{
		var list = await CertifyClient
			.ExpenseReports
			.GetAllAsync(CancellationToken);

		list.Should().NotBeNullOrEmpty();
	}
}
