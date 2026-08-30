using AwesomeAssertions;
using Certify.Api.Extensions;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test.ModelTests;

public class ExpenseTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		var list = await CertifyClient
			.Expenses
			.GetAllAsync(
				new ExpenseFilter
				{
					StartDate = "2019-07-30",
					Processed = 1,
					IncludeDisapproved = 1
				},
				CancellationToken);

		list.Should().NotBeNullOrEmpty();
		list.Count.Should().BePositive();
	}
}
