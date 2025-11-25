using AwesomeAssertions;
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
		result.Should().NotBeNull();
		result.TotalRecordCount.Should().BePositive();
		result.TotalPageCount.Should().BePositive();
		result.PageNumber.Should().BePositive();
		result.PageRecordCount.Should().BePositive();
	}
}
