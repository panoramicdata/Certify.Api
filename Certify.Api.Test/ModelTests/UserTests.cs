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
		page.Should().NotBeNull();
		page.Users.Should().NotBeNullOrEmpty();
		page.TotalRecordCount.Should().BePositive();
		page.TotalPageCount.Should().BePositive();
		page.PageNumber.Should().BePositive();
		page.PageRecordCount.Should().BePositive();
	}

	[Fact]
	public async Task GetAll_Succeeds()
	{
		var users = await CertifyClient
			.Users
			.GetAllAsync(cancellationToken: CancellationToken);
		users.Should().NotBeNull();
		users.Should().NotBeNullOrEmpty();
	}
}
