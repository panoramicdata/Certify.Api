using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests;

public class ReceiptTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.Receipts
			.GetPageAsync(cancellationToken: CancellationToken);
		page.Should().NotBeNull();
		page.Receipts.Should().NotBeNullOrEmpty();
		page.TotalRecordCount.Should().BePositive();
		page.TotalPageCount.Should().BePositive();
		page.PageNumber.Should().BePositive();
		page.PageRecordCount.Should().BePositive();
	}
}
