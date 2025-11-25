using AwesomeAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test.ModelTests;

public class ExpenseCategoryTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.ExpenseCategories
			.GetPageAsync(cancellationToken: CancellationToken);

		page.Should().NotBeNull();
		page.TotalRecordCount.Should().BePositive();
		page.TotalPageCount.Should().BePositive();
		page.PageNumber.Should().BePositive();
		page.PageRecordCount.Should().BePositive();
		page.ExpenseCategories.Should().NotBeEmpty();

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
