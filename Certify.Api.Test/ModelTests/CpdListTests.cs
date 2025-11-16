using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests;

public class CpdListTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage_Succeeds()
	{
		var result = await CertifyClient
			.CpdLists
			.GetPageAsync(cancellationToken: CancellationToken);
		result.Should().NotBeNull();

		var firstItem = result.CpdLists.FirstOrDefault();

		if (firstItem != null)
		{
			// There was at least one entry so none of these should be zero
			result.TotalRecordCount.Should().BePositive();
			result.TotalPageCount.Should().BePositive();
			result.PageNumber.Should().BePositive();
			result.PageRecordCount.Should().BePositive();

			var refetch = await CertifyClient
			.CpdLists
			.GetAsync(firstItem.Id, cancellationToken: CancellationToken);

			refetch.Id.Should().Be(firstItem.Id);
		}
	}
}
