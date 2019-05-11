using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Models
{
	public class ExpenseReportGldTests : CertifyTest
	{
		public ExpenseReportGldTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetPage_Succeeds()
		{
			var result = await CertifyClient
				.ExpenseReportGlds
				.GetPageAsync(1)
				.ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
