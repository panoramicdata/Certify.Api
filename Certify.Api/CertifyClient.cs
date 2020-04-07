using Certify.Api.Exceptions;
using Certify.Api.Http;
using Certify.Api.Interfaces;
using Certify.Api.Models;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Certify.Api
{
	/// <summary>
	/// The main Certify Client
	/// </summary>
	public class CertifyClient : IDisposable
	{
		private readonly HttpClient _httpClient;

		public CertifyClient(
			string apiKey,
			string apiSecret,
			CertifyClientOptions options = default)
		{
			options ??= new CertifyClientOptions();

			var refitSettings = new RefitSettings
			{
				ContentSerializer = new JsonContentSerializer(
					new JsonSerializerSettings
					{
						MissingMemberHandling = MissingMemberHandling.Ignore,
					}),
			};

			_httpClient = new HttpClient(
				new AuthenticatedHttpClientHandler(
					apiKey ?? throw new ArgumentNullException(nameof(apiKey)),
					apiSecret ?? throw new ArgumentNullException(nameof(apiSecret))
					))
			{
				// This address should NOT end in "/" as the interface method paths are added to the end of this and Refit requires they start with "/"
				BaseAddress = new Uri("https://api.certify.com/v1"),
				Timeout = options.Timeout
			};

			CpdLists = RestService.For<ICpdLists>(_httpClient, refitSettings);
			Departments = RestService.For<IDepartments>(_httpClient, refitSettings);
			EmpGlds = RestService.For<IEmpGlds>(_httpClient, refitSettings);
			ExpenseCategories = RestService.For<IExpenseCategories>(_httpClient, refitSettings);
			ExpenseReports = RestService.For<IExpenseReports>(_httpClient, refitSettings);
			Expenses = RestService.For<IExpenses>(_httpClient, refitSettings);
			ExpenseReportGlds = RestService.For<IExpenseReportGlds>(_httpClient, refitSettings);
			InvoiceReports = RestService.For<IInvoiceReports>(_httpClient, refitSettings);
			Invoices = RestService.For<IInvoices>(_httpClient, refitSettings);
			MileageRates = RestService.For<IMileageRates>(_httpClient, refitSettings);
			MileageRateDetails = RestService.For<IMileageRateDetails>(_httpClient, refitSettings);
			Receipts = RestService.For<IReceipts>(_httpClient, refitSettings);
			Users = RestService.For<IUsers>(_httpClient, refitSettings);
		}

		public ICpdLists CpdLists { get; }

		public IDepartments Departments { get; }

		public IEmpGlds EmpGlds { get; }

		public IExpenseCategories ExpenseCategories { get; }

		public IExpenseReports ExpenseReports { get; }

		public IExpenses Expenses { get; }

		public IExpenseReportGlds ExpenseReportGlds { get; }

		public IInvoiceReports InvoiceReports { get; }

		public IInvoices Invoices { get; }

		public IMileageRates MileageRates { get; }

		public IMileageRateDetails MileageRateDetails { get; }

		public IReceipts Receipts { get; }

		public IUsers Users { get; }

		/// <summary>
		/// This is used by extension methods to get all pages for those types that support it
		/// </summary>
		/// <typeparam name="T">Something that supports paging in Certify</typeparam>
		/// <param name="getPageFuncAsync">The function that will return a GenericPage of the type</param>
		/// <returns>A final list of all results</returns>
		internal static async Task<List<T>> GetAllAsync<T>(Func<uint, Task<GenericPage<T>>> getPageFuncAsync) where T : ISupportsPaging
		{
			// Test getting the first 5 indexes
			var results = new List<T>();

			uint pageNumber = 1;
			GenericPage<T> page;
			do
			{
				page = await getPageFuncAsync(pageNumber).ConfigureAwait(false);

				// Did we get any?
				if (page.Items.Count > 0)
				{
					// YES - Add to the list of results
					results.AddRange(page.Items);
				}
			} while (pageNumber++ < page.TotalPageCount);

			if (results.Count != page.TotalRecordCount)
			{
				// TODO - Could do a retry a few times, it just might be that the contents changed during paging
				throw new PageCountMismatchException("Number of records retrieved does not match page TotalRecordCount");
			}

			return results;
		}

		public void Dispose()
			=> _httpClient.Dispose();
	}
}
