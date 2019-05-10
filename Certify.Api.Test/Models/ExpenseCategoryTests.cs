using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Cpd
{
	public class ExpenseCategoryTests : CertifyTest
	{
		public ExpenseCategoryTests(ITestOutputHelper iTestOutputHelper) : base (iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient.ExpenseCategories.GetAllAsync();
			Assert.NotNull(result);
		}
	}
}
