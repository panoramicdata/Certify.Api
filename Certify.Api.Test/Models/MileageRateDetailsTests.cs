using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Models
{
	public class MileageRateDetailsTests : CertifyTest
	{
		public MileageRateDetailsTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient
				.MileageRateDetails
				.GetAllAsync()
				.ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
