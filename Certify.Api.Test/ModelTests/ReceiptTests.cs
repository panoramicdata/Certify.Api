using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests;

public class ReceiptTests : CertifyTest
{
	public ReceiptTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
	{
	}

	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.Receipts
			.GetPageAsync()
			.ConfigureAwait(false);
		page.Should().NotBeNull();
		page.Receipts.Should().NotBeNullOrEmpty();
		page.TotalRecordCount.Should().BeGreaterThan(0);
		page.TotalPageCount.Should().BeGreaterThan(0);
		page.PageNumber.Should().BeGreaterThan(0);
		page.PageRecordCount.Should().BeGreaterThan(0);
	}
}
