using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test.ModelTests;

public class EmpGldTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetEmployeeGldsAtFirstIndex()
	{
		var result = await CertifyClient
			.EmpGlds
			.GetAsync(1, cancellationToken: CancellationToken);

		AssertPopulatedPage(result);
	}
}
