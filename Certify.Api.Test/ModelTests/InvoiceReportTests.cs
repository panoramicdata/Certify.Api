using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests
{
	public class InvoiceReportTests : CertifyTest
	{
		public InvoiceReportTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetPage_Succeeds()
		{
			var page = await CertifyClient
				.InvoiceReports
				.GetPageAsync()
				.ConfigureAwait(false);
			page.Should().NotBeNull();
			// TODO - Enable below once expenses are in a test system
			//page.InvoiceReports.Should().NotBeNullOrEmpty();
			//page.TotalRecordCount.Should().BeGreaterThan(0);
			//page.TotalPageCount.Should().BeGreaterThan(0);
			//page.PageNumber.Should().BeGreaterThan(0);
			//page.PageRecordCount.Should().BeGreaterThan(0);
		}
	}
}
