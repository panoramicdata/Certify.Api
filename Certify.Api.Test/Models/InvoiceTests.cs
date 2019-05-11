using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Models
{
	public class InvoiceTests : CertifyTest
	{
		public InvoiceTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient
				.Invoices
				.GetAllAsync()
				.ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
