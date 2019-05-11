using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Cpd
{
	public class EmpGldTests : CertifyTest
	{
		public EmpGldTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetFirst()
		{
			var result = await CertifyClient
				.EmpGlds
				.GetAsync(1)
				.ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
