using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests;

public class ExpenseCategoryTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.ExpenseCategories
			.GetPageAsync(cancellationToken: CancellationToken);

		_ = page.Should().NotBeNull();
		_ = page.TotalRecordCount.Should().BePositive();
		_ = page.TotalPageCount.Should().BePositive();
		_ = page.PageNumber.Should().BePositive();
		_ = page.PageRecordCount.Should().BePositive();
		_ = page.ExpenseCategories.Should().NotBeEmpty();

		var pageFirstItem = page.ExpenseCategories[0];

		var refetch = await CertifyClient
			.ExpenseCategories
			.GetAsync(pageFirstItem.Id, cancellationToken: CancellationToken);
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
