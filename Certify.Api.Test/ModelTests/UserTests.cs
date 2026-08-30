using AwesomeAssertions;
using Certify.Api.Extensions;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test.ModelTests;

public class UserTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.Users
			.GetPageAsync(cancellationToken: CancellationToken);

		AssertPopulatedPage(page);
		page.Users.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task GetAll_Succeeds()
	{
		var users = await CertifyClient
			.Users
			.GetAllAsync(CancellationToken);

		users.Should().NotBeNullOrEmpty();
	}
}
