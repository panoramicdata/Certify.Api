using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Cpd
{
	public class ExpenseTests : CertifyTest
	{
		public ExpenseTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient
				.Expenses
				.GetAllAsync()
				.ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
