using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Cpd
{
	public class CpdListTests : CertifyTest
	{
		public CpdListTests(ITestOutputHelper iTestOutputHelper) : base (iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient.CpdLists.GetAllAsync();
			Assert.NotNull(result);
		}
	}
}
