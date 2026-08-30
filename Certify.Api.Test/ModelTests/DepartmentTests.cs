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
			AssertPopulatedPage(page);

			var refetchSingle = await CertifyClient
				.Departments
				.GetAsync(firstDepartment.Id, cancellationToken: CancellationToken);

			AssertSingleRecordPage(refetchSingle);
			refetchSingle.Departments[0].Id.Should().Be(firstDepartment.Id);
		}
	}
}
