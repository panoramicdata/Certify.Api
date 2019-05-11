using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Models
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
				.GetPageAsync()
				.ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
