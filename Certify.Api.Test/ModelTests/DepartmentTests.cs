using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests
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
			result.Should().NotBeNull();

			var firstDepartment = result
				.Departments
				.FirstOrDefault();
			if (firstDepartment != null)
			{
				// There was at least one entry so none of these should be zero
				result.TotalRecordCount.Should().BeGreaterThan(0);
				result.TotalPageCount.Should().BeGreaterThan(0);
				result.PageNumber.Should().BeGreaterThan(0);
				result.PageRecordCount.Should().BeGreaterThan(0);

				var refetch = await CertifyClient
					.Departments
					.GetAsync(firstDepartment.Id)
					.ConfigureAwait(false);

				refetch.Should().NotBeNull();
				refetch.TotalRecordCount.Should().Be(1);
				refetch.Departments[0].Id.Should().Be(firstDepartment.Id);
			}
		}
	}
}
