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

		page.Should().NotBeNull();
		page.ExpenseReports.Should().NotBeNullOrEmpty();
		page.TotalRecordCount.Should().BePositive();
		page.TotalPageCount.Should().BePositive();
		page.PageNumber.Should().BePositive();
		page.PageRecordCount.Should().BePositive();
	}

	[Fact]
	public async Task GetAll_Succeeds()
	{
		var list = await CertifyClient
			.ExpenseReports
			.GetAllAsync(cancellationToken: CancellationToken);

		list.Should().NotBeNullOrEmpty();
	}
}
