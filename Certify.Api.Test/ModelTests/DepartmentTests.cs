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
			var page = await CertifyClient
				.Departments
				.GetPageAsync()
				.ConfigureAwait(false);
			page.Should().NotBeNull();

			var firstDepartment = page
				.Departments
				.FirstOrDefault();
			if (firstDepartment != null)
			{
				// There was at least one entry so none of these should be zero
				page.TotalRecordCount.Should().BeGreaterThan(0);
				page.TotalPageCount.Should().BeGreaterThan(0);
				page.PageNumber.Should().BeGreaterThan(0);
				page.PageRecordCount.Should().BeGreaterThan(0);

				var refetchSingle = await CertifyClient
					.Departments
					.GetAsync(firstDepartment.Id)
					.ConfigureAwait(false);

				refetchSingle.Should().NotBeNull();
				refetchSingle.TotalRecordCount.Should().Be(1);
				refetchSingle.Departments[0].Id.Should().Be(firstDepartment.Id);
			}
		}
	}
}
