﻿using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test.Cpd
{
	public class ExpenseReportGldTests : CertifyTest
	{
		public ExpenseReportGldTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		[Fact]
		public async Task GetAll()
		{
			var result = await CertifyClient.ExpenseReportGlds.GetAllAsync();
			Assert.NotNull(result);
		}
	}
}
