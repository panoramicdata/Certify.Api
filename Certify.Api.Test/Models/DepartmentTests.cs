using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Models
{
	public class DepartmentTests : CertifyTest
	{
		public DepartmentTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetPage()
		{
			var result = await CertifyClient
				.Departments
				.GetPageAsync()
				.ConfigureAwait(false);
			Assert.NotNull(result);

			var firstDepartment = result
				.Departments
				.FirstOrDefault();
			if (firstDepartment != null)
			{
				var refetch = await CertifyClient
				.Departments
				.GetAsync(firstDepartment.Id)
				.ConfigureAwait(false);
				Assert.NotNull(refetch);
			}
		}
	}
}
