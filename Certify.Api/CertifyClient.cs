using Certify.Api.Http;
using Certify.Api.Interfaces;
using Newtonsoft.Json;
using Refit;
using System;
using System.Net.Http;

namespace Certify.Api
{
	/// <summary>
	/// The main Certify Client
	/// </summary>
	public class CertifyClient
	{
		public CertifyClient(string apiKey, string apiSecret, CertifyClientOptions options = default)
		{
			var jsonSerializerSettings = new JsonSerializerSettings
			{
				MissingMemberHandling = MissingMemberHandling.Ignore,
			};
			var refitSettings = new RefitSettings
			{
				ContentSerializer = new JsonContentSerializer(jsonSerializerSettings),
			};
			var httpClient = new HttpClient(
				new AuthenticatedHttpClientHandler(
					apiKey ?? throw new ArgumentNullException(nameof(apiKey)),
					apiSecret ?? throw new ArgumentNullException(nameof(apiSecret))
					))
			{
				BaseAddress = new Uri("https://api.certify.com/v1/")
			};

			CpdLists = RestService.For<ICpdLists>(httpClient, refitSettings);
			Departments = RestService.For<IDepartments>(httpClient, refitSettings);
			EmpGlds = RestService.For<IEmpGlds>(httpClient, refitSettings);
			ExpenseCategories = RestService.For<IExpenseCategories>(httpClient, refitSettings);
			ExpenseReports = RestService.For<IExpenseReports>(httpClient, refitSettings);
			Expenses = RestService.For<IExpenses>(httpClient, refitSettings);
			ExpenseReportGlds = RestService.For<IExpenseReportGlds>(httpClient, refitSettings);
			InvoiceReports = RestService.For<IInvoiceReports>(httpClient, refitSettings);
			Invoices = RestService.For<IInvoices>(httpClient, refitSettings);
			MileageRates = RestService.For<IMileageRates>(httpClient, refitSettings);
			MileageRateDetails = RestService.For<IMileageRateDetails>(httpClient, refitSettings);
			Receipts = RestService.For<IReceipts>(httpClient, refitSettings);
			Users = RestService.For<IUsers>(httpClient, refitSettings);
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
	}
}
