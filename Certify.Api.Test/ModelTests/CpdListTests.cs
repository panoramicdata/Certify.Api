using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests
{
	public class CpdListTests : CertifyTest
	{
		public CpdListTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetPage_Succeeds()
		{
			var result = await CertifyClient
				.CpdLists
				.GetPageAsync()
				.ConfigureAwait(false);
			result.Should().NotBeNull();

			var firstItem = result.CpdLists.FirstOrDefault();

			if (firstItem != null)
			{
				// There was at least one entry so none of these should be zero
				//result.TotalRecordCount.Should().BeGreaterThan(0);
				//result.TotalPageCount.Should().BeGreaterThan(0);
				//result.PageNumber.Should().BeGreaterThan(0);
				//result.PageRecordCount.Should().BeGreaterThan(0);

				var refetch = await CertifyClient
				.CpdLists
				.GetAsync(firstItem.Id)
				.ConfigureAwait(false);

				refetch.Id.Should().Be(firstItem.Id);
			}
		}
	}
}
