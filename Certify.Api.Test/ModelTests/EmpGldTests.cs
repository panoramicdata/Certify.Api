using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests
{
	public class EmpGldTests : CertifyTest
	{
		public EmpGldTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetEmployeeGldsAtFirstIndex()
		{
			var result = await CertifyClient
				.EmpGlds
				.GetAsync(1)
				.ConfigureAwait(false);
			result.Should().NotBeNull();
			result.TotalRecordCount.Should().BeGreaterThan(0);
			result.TotalPageCount.Should().BeGreaterThan(0);
			result.PageNumber.Should().BeGreaterThan(0);
			result.PageRecordCount.Should().BeGreaterThan(0);
		}
	}
}
