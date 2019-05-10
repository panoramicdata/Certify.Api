using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Cpd
{
	public class DepartmentTests : CertifyTest
	{
		public DepartmentTests(ITestOutputHelper iTestOutputHelper) : base (iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient.Departments.GetAllAsync();
			Assert.NotNull(result);
		}
	}
}
