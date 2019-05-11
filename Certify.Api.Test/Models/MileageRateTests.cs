using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Models
{
	public class MileageRateTests : CertifyTest
	{
		public MileageRateTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient
				.MileageRates
				.GetPageAsync()
				.ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
