using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests;

public class InvoiceTests : CertifyTest
{
	public InvoiceTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
	{
	}

	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.Invoices
			.GetPageAsync()
			.ConfigureAwait(false);
		page.Should().NotBeNull();
		// TODO - Enable below once expenses are in a test system
	}
}
