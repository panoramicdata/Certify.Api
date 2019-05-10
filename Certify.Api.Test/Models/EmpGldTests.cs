using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Cpd
{
	public class EmpGldTests : CertifyTest
	{
		public EmpGldTests(ITestOutputHelper iTestOutputHelper) : base (iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient.EmpGlds.GetAllAsync();
			Assert.NotNull(result);
		}
	}
}
