using System.Linq;
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
		public async Task GetPage_Succeeds()
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
			Assert.NotNull(refetch.ExpenseCategories);
			Assert.Single(refetch.ExpenseCategories);
			var firstItem = refetch.ExpenseCategories.First();
			Assert.Equal(pageFirstItem.Id, firstItem.Id);
			Assert.Equal(pageFirstItem.Name, firstItem.Name);
		}
	}
}
