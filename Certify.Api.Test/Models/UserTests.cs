using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Cpd
{
	public class UserTests : CertifyTest
	{
		public UserTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient.Users.GetAllAsync();
			Assert.NotNull(result);
		}
	}
}
