using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Models
{
	public class CpdListTests : CertifyTest
	{
		public CpdListTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient
				.CpdLists
				.GetPageAsync()
				.ConfigureAwait(false);
			Assert.NotNull(result);

			var firstItem = result.CpdLists.FirstOrDefault();

			if (firstItem != null)
			{
				var refetch = await CertifyClient
				.CpdLists
				.GetAsync(firstItem.Id)
				.ConfigureAwait(false);

				Assert.Equal(firstItem.Id, refetch.Id);
			}
		}
	}
}
