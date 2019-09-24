using Certify.Api.Extensions;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests
{
	public class ExpenseTests : CertifyTest
	{
		public ExpenseTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

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
				1
				)
				.ConfigureAwait(false);
			list.Should().NotBeNullOrEmpty();
			list.Count.Should().BeGreaterThan(0);
		}
	}
}
