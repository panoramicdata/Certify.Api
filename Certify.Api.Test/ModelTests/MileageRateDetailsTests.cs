using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests;

public class MileageRateDetailsTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.MileageRateDetails
			.GetPageAsync()
			.ConfigureAwait(false);
		page.Should().NotBeNull();
		// TODO - Enable below once expenses are in a test system
	}
}
