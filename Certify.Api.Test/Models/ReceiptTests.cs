using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Cpd
{
	public class ReceiptTests : CertifyTest
	{
		public ReceiptTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient
				.Receipts
				.GetAllAsync()
				.ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
