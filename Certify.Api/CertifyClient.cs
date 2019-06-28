﻿using Certify.Api.Exceptions;
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
				BaseAddress = new Uri("https://api.certify.com/v1")
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
	}
}
