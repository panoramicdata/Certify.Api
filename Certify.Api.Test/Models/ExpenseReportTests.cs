using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Models
{
	public class ExpenseReportTests : CertifyTest
	{
		public ExpenseReportTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient
				.ExpenseReports
				.GetPageAsync()
				.ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
