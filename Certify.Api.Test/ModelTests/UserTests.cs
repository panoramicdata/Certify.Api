using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests
{
	public class UserTests : CertifyTest
	{
		public UserTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetPage_Succeeds()
		{
			var page = await CertifyClient
				.Users
				.GetPageAsync()
				.ConfigureAwait(false);
			page.Should().NotBeNull();
			page.Users.Should().NotBeNullOrEmpty();
			page.TotalRecordCount.Should().BeGreaterThan(0);
			page.TotalPageCount.Should().BeGreaterThan(0);
			page.PageNumber.Should().BeGreaterThan(0);
			page.PageRecordCount.Should().BeGreaterThan(0);
		}
	}
}
