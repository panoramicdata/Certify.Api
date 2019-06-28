using Certify.Api.Models;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
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

		[Fact(Skip = "Only run manually")]
		public async Task CRUD_Succeeds()
		{
			const string Name = "PDL-Test01-Name";
			const string Code = "PDL-Test01-Code";
			const string Description = "PDL-Test01-Description";

			// CREATE
			var created = await CertifyClient
				.ExpenseReportGlds
				.CreateAsync(3, new ExpenseReportGld
				{
					Name = Name,
					Code = Code,
					Description = Description,
					Active = 1
				})
				.ConfigureAwait(false);
			created.Should().NotBeNull();

			// Get created and compare
			var createdRetrievedPage = await CertifyClient
				.ExpenseReportGlds
				.GetAsync(3, created.Id)
				.ConfigureAwait(false);

			createdRetrievedPage.Should().NotBeNull();
			createdRetrievedPage.PageNumber.Should().Be(1);
			createdRetrievedPage.TotalRecordCount.Should().Be(1);
			createdRetrievedPage.TotalPageCount.Should().Be(1);
			createdRetrievedPage.PageNumber.Should().Be(1);
			createdRetrievedPage.PageRecordCount.Should().Be(1);
			createdRetrievedPage.ExpenseReportGlds.Should().ContainSingle();

			var createdRetrieved = createdRetrievedPage.ExpenseReportGlds[0];
			createdRetrieved.Name.Should().Be(Name);
			createdRetrieved.Description.Should().Be(Description);
			createdRetrieved.Code.Should().Be(Code);
			createdRetrieved.Data.Should().BeEmpty();
			createdRetrieved.ExpRptGldIndex.Should().Be(3);
			createdRetrieved.ExpRptGldLabel.Should().Be("Ticket");

			// Get the active entries and confirm the newly created result exists
			var expenseReportGldsPage = await CertifyClient
				.ExpenseReportGlds
				.GetPageAsync(3, active: 1)
				.ConfigureAwait(false);
			expenseReportGldsPage.Should().NotBeNull();
			expenseReportGldsPage.ExpenseReportGlds.Should().NotBeNullOrEmpty();
			var singleEntry = expenseReportGldsPage.ExpenseReportGlds.SingleOrDefault(erg => erg.Id == created.Id);
			singleEntry.Should().NotBeNull();

			// Get the inactive entries and confirm the newly created result does NOT exist
			expenseReportGldsPage = await CertifyClient
				.ExpenseReportGlds
				.GetPageAsync(3, active: 0)
				.ConfigureAwait(false);
			singleEntry = expenseReportGldsPage.ExpenseReportGlds.SingleOrDefault(erg => erg.Id == created.Id);
			singleEntry.Should().BeNull();

			// UPDATE
			// Set the active flag to 0
			var updateResult = await CertifyClient
				.ExpenseReportGlds
				.UpdateAsync(3, new ExpenseReportGld
				{
					Id = created.Id,
					Active = 0
				})
				.ConfigureAwait(false);

			// Get the active entries and confirm the updated result does NOT exist
			expenseReportGldsPage = await CertifyClient
				.ExpenseReportGlds
				.GetPageAsync(3, active: 1)
				.ConfigureAwait(false);
			singleEntry = expenseReportGldsPage.ExpenseReportGlds.SingleOrDefault(erg => erg.Id == created.Id);
			singleEntry.Should().BeNull();

			// Get the inactive entries and confirm the newly created result DOES exist
			expenseReportGldsPage = await CertifyClient
				.ExpenseReportGlds
				.GetPageAsync(3, active: 0)
				.ConfigureAwait(false);
			expenseReportGldsPage.Should().NotBeNull();
			expenseReportGldsPage.ExpenseReportGlds.Should().NotBeNullOrEmpty();
			singleEntry = expenseReportGldsPage.ExpenseReportGlds.SingleOrDefault(erg => erg.Id == created.Id);
			singleEntry.Should().NotBeNull();

			// DELETE
			// There is no real delete, the above update also tests delete by setting active to 0
		}

		/// <summary>
		/// This is a helper script for making all entries starting with PDL inactive
		/// </summary>
		internal async Task MakeCertainEntriesInactiveAsync()
		{
			var page = await CertifyClient
				.ExpenseReportGlds
				.GetPageAsync(3, active: 1)
				.ConfigureAwait(false);

			var targets = page.ExpenseReportGlds.Where(e => e.Name.StartsWith("PDL")).ToList();
			foreach (var item in targets)
			{
				item.Active = 0;
				await CertifyClient.ExpenseReportGlds.UpdateAsync(3, item).ConfigureAwait(false);
			}
		}
	}
}
