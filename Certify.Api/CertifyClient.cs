using Certify.Api.Http;
using Certify.Api.Interfaces;
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
		public CertifyClient(
			string apiKey,
			string apiSecret,
			CertifyClientOptions options = default)
		{
			//var jsonSerializerSettings = new JsonSerializerSettings
			//{
			//	MissingMemberHandling = MissingMemberHandling.Ignore,
			//};
			//var refitSettings = new RefitSettings
			//{
			//	ContentSerializer = new JsonContentSerializer(jsonSerializerSettings),
			//};
			var httpClient = new HttpClient(
				new AuthenticatedHttpClientHandler(
					apiKey ?? throw new ArgumentNullException(nameof(apiKey)),
					apiSecret ?? throw new ArgumentNullException(nameof(apiSecret))
					))
			{
				BaseAddress = new Uri("https://api.certify.com/v1/")
			};

			if (options?.Timeout != null)
			{
				httpClient.Timeout = options.Timeout;
			}

			CpdLists = RestService.For<ICpdLists>(httpClient);
			Departments = RestService.For<IDepartments>(httpClient);
			EmpGlds = RestService.For<IEmpGlds>(httpClient);
			ExpenseCategories = RestService.For<IExpenseCategories>(httpClient);
			ExpenseReports = RestService.For<IExpenseReports>(httpClient);
			Expenses = RestService.For<IExpenses>(httpClient);
			ExpenseReportGlds = RestService.For<IExpenseReportGlds>(httpClient);
			InvoiceReports = RestService.For<IInvoiceReports>(httpClient);
			Invoices = RestService.For<IInvoices>(httpClient);
			MileageRates = RestService.For<IMileageRates>(httpClient);
			MileageRateDetails = RestService.For<IMileageRateDetails>(httpClient);
			Receipts = RestService.For<IReceipts>(httpClient);
			Users = RestService.For<IUsers>(httpClient);
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
