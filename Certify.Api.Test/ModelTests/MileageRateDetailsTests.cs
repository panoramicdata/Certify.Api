using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests
{
	public class MileageRateDetailsTests : CertifyTest
	{
		public MileageRateDetailsTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetPage_Succeeds()
		{
			var page = await CertifyClient
				.MileageRateDetails
				.GetPageAsync()
				.ConfigureAwait(false);
			page.Should().NotBeNull();
			// TODO - Enable below once expenses are in a test system
			//page.MileageRates.Should().NotBeNullOrEmpty();
			//page.TotalRecordCount.Should().BeGreaterThan(0);
			//page.TotalPageCount.Should().BeGreaterThan(0);
			//page.PageNumber.Should().BeGreaterThan(0);
			//page.PageRecordCount.Should().BeGreaterThan(0);
		}
	}
}
