using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Models
{
	public class ExpenseCategoryTests : CertifyTest
	{
		public ExpenseCategoryTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetPage()
		{
			var page = await CertifyClient
				.ExpenseCategories
				.GetPageAsync()
				.ConfigureAwait(false);
			Assert.NotNull(page);
			Assert.NotEmpty(page.ExpenseCategories);

			var pageFirstItem = page.ExpenseCategories[0];
			var refetch = await CertifyClient
				.ExpenseCategories
				.GetAsync(pageFirstItem.Id)
				.ConfigureAwait(false);
			Assert.NotNull(refetch);
			Assert.Equal(pageFirstItem.Id, refetch.Id);
			Assert.Equal(pageFirstItem.Name, refetch.Name);
		}
	}
}
