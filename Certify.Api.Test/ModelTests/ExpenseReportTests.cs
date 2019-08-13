using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Certify.Api.Extensions;

namespace Certify.Api.Test.ModelTests
{
	public class ExpenseReportTests : CertifyTest
	{
		public ExpenseReportTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetPage_Succeeds()
		{
			var page = await CertifyClient
				.ExpenseReports
				.GetPageAsync()
				.ConfigureAwait(false);

			page.Should().NotBeNull();
			page.ExpenseReports.Should().NotBeNullOrEmpty();
			page.TotalRecordCount.Should().BeGreaterThan(0);
			page.TotalPageCount.Should().BeGreaterThan(0);
			page.PageNumber.Should().BeGreaterThan(0);
			page.PageRecordCount.Should().BeGreaterThan(0);
		}

		[Fact]
		public async Task GetAll_Succeeds()
		{
			var list = await CertifyClient
				.ExpenseReports
				.GetAllAsync()
				.ConfigureAwait(false);

			list.Should().NotBeNullOrEmpty();
		}
	}
}
