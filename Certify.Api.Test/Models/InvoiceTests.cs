using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Cpd
{
	public class InvoiceTests : CertifyTest
	{
		public InvoiceTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient.Invoices.GetAllAsync();
			Assert.NotNull(result);
		}
	}
}
