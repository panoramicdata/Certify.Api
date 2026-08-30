using AwesomeAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test.ModelTests;

public class ReceiptTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.Receipts
			.GetPageAsync(cancellationToken: CancellationToken);

		AssertPopulatedPage(page);
		page.Receipts.Should().NotBeNullOrEmpty();
	}
}
