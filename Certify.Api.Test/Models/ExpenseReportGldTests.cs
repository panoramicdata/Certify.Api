using Certify.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Models
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

			for(uint i = 1; i <= 5; i++)
			{
				var result = await CertifyClient
					.ExpenseReportGlds
					.GetPageAsync(i)
					.ConfigureAwait(false);
				Assert.NotNull(result);
				Assert.NotNull(result.ExpenseReportGlds);
				Assert.NotEmpty(result.ExpenseReportGlds);
				results.Add(result);
			}
		}

		//[Fact]
		//public async Task Create_Succeeds()
		//{
		//	var result = await CertifyClient
		//		.ExpenseReportGlds
		//		.CreateAsync(1, new ExpenseReportGld
		//		{
		//			Name = "Ticket",
		//			Code = "Ticket",
		//			Description = "Ticket",
		//			Active = 1
		//		})
		//		.ConfigureAwait(false);
		//	Assert.NotNull(result);
		//}
	}
}
