using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests;

public class EmpGldTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetEmployeeGldsAtFirstIndex()
	{
		var result = await CertifyClient
			.EmpGlds
			.GetAsync(1, cancellationToken: CancellationToken);
		_ = result.Should().NotBeNull();
		_ = result.TotalRecordCount.Should().BePositive();
		_ = result.TotalPageCount.Should().BePositive();
		_ = result.PageNumber.Should().BePositive();
		_ = result.PageRecordCount.Should().BePositive();
	}
}
