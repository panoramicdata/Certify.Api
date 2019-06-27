using Certify.Api.Models;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.ModelTests
{
	public class ExpenseReportGldTests : CertifyTest
	{
		public ExpenseReportGldTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetPage_Succeeds()
		{
			var results = new List<ExpenseReportGldPage>();

			for (uint i = 1; i <= 5; i++)
			{
				var result = await CertifyClient
					.ExpenseReportGlds
					.GetPageAsync(i)
					.ConfigureAwait(false);

				result.Should().NotBeNull();
				result.ExpenseReportGlds.Should().NotBeNullOrEmpty();

				results.Add(result);
			}
		}

		//[Fact]
		//public async Task Create_Succeeds()
		//{
		//	var result = await CertifyClient
		//		.ExpenseReportGlds
		//		.CreateAsync(3, new ExpenseReportGld
		//		{
		//			Name = "PDL-Test01-Name",
		//			Code = "PDL-Test01-Code",
		//			Description = "PDL-Test01-Description",
		//			Active = 1
		//		})
		//		.ConfigureAwait(false);
		//	Assert.NotNull(result);
		//}
	}
}
