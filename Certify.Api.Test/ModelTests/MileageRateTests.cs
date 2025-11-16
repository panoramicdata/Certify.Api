using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests;

public class MileageRateTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.MileageRates
			.GetPageAsync(cancellationToken: CancellationToken);
		page.Should().NotBeNull();
		page.MileageRates.Should().NotBeNullOrEmpty();
		page.TotalRecordCount.Should().BePositive();
		page.TotalPageCount.Should().BePositive();
		page.PageNumber.Should().BePositive();
		page.PageRecordCount.Should().BePositive();
	}
}
