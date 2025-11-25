using AwesomeAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test.ModelTests;

public class DepartmentTests(ITestOutputHelper iTestOutputHelper) : CertifyTest(iTestOutputHelper)
{
	[Fact]
	public async Task GetPage()
	{
		var page = await CertifyClient
			.Departments
			.GetPageAsync(cancellationToken: CancellationToken);
		page.Should().NotBeNull();

		var firstDepartment = page
			.Departments
			.FirstOrDefault();
		if (firstDepartment != null)
		{
			// There was at least one entry so none of these should be zero
			page.TotalRecordCount.Should().BePositive();
			page.TotalPageCount.Should().BePositive();
			page.PageNumber.Should().BePositive();
			page.PageRecordCount.Should().BePositive();

			var refetchSingle = await CertifyClient
				.Departments
				.GetAsync(firstDepartment.Id, cancellationToken: CancellationToken);

			refetchSingle.Should().NotBeNull();
			refetchSingle.TotalRecordCount.Should().Be(1);
			refetchSingle.Departments[0].Id.Should().Be(firstDepartment.Id);
		}
	}
}
