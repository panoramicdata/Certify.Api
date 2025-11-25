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
			"2019-07-30",
			null,
			null,
			1,
			1,
			cancellationToken: CancellationToken);
		list.Should().NotBeNullOrEmpty();
		list.Count.Should().BePositive();
	}
}
