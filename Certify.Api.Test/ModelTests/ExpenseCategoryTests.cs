using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests
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

			page.Should().NotBeNull();
			page.TotalRecordCount.Should().BeGreaterThan(0);
			page.TotalPageCount.Should().BeGreaterThan(0);
			page.PageNumber.Should().BeGreaterThan(0);
			page.PageRecordCount.Should().BeGreaterThan(0);
			page.ExpenseCategories.Should().NotBeEmpty();

			var pageFirstItem = page.ExpenseCategories[0];

			var refetch = await CertifyClient
				.ExpenseCategories
				.GetAsync(pageFirstItem.Id)
				.ConfigureAwait(false);
			refetch.Should().NotBeNull();
			refetch.ExpenseCategories.Should().NotBeNull();
			refetch.ExpenseCategories.Should().ContainSingle();
			refetch.TotalRecordCount.Should().Be(1);
			refetch.TotalPageCount.Should().Be(1);
			refetch.PageNumber.Should().Be(1);
			refetch.PageRecordCount.Should().Be(1);

			var firstItem = refetch.ExpenseCategories[0];
			firstItem.Id.Should().Be(pageFirstItem.Id);
			firstItem.Name.Should().Be(pageFirstItem.Name);
		}
	}
}
