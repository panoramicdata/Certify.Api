using AwesomeAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test.Models;

public class ExpenseCategoryTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		var page = await CertifyClient
			.ExpenseCategories
			.GetPageAsync(cancellationToken: CancellationToken);
		page.Should().NotBeNull();
		page.ExpenseCategories.Should().NotBeEmpty();

		var pageFirstItem = page.ExpenseCategories[0];
		var refetch = await CertifyClient
			.ExpenseCategories
			.GetAsync(pageFirstItem.Id, cancellationToken: CancellationToken);
		refetch.Should().NotBeNull();
		refetch.ExpenseCategories.Should().NotBeNull();
		refetch.ExpenseCategories.Should().ContainSingle();
		var firstItem = refetch.ExpenseCategories[0];
		firstItem.Id.Should().Be(pageFirstItem.Id);
		firstItem.Name.Should().Be(pageFirstItem.Name);
	}
}
