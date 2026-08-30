using AwesomeAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test.ModelTests;

public class MileageRateTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.MileageRates
			.GetPageAsync(cancellationToken: CancellationToken);

		AssertPopulatedPage(page);
		page.MileageRates.Should().NotBeNullOrEmpty();
	}
}
