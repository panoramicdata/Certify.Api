using Certify.Api.Exceptions;
using Certify.Api.Http;
using Certify.Api.Interfaces;
using Certify.Api.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Certify.Api;

/// <summary>
/// The main Certify Client
/// </summary>
public class CertifyClient : IDisposable
{
	private readonly HttpClient _httpClient;

	/// <summary>
	/// Initializes a new instance of the <see cref="CertifyClient"/> class with default options.
	/// </summary>
	/// <param name="apiKey">The Certify API key.</param>
	/// <param name="apiSecret">The Certify API secret.</param>
	public CertifyClient(string apiKey, string apiSecret)
		: this(apiKey, apiSecret, new CertifyClientOptions())
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="CertifyClient"/> class.
	/// </summary>
	/// <param name="apiKey">The Certify API key.</param>
	/// <param name="apiSecret">The Certify API secret.</param>
	/// <param name="options">The client options.</param>
	public CertifyClient(
		string apiKey,
		string apiSecret,
		CertifyClientOptions options)
	{
		ArgumentNullException.ThrowIfNull(options);

		var jsonSerializerOptions = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		};

		var refitSettings = new RefitSettings
		{
			ContentSerializer = new SystemTextJsonContentSerializer(jsonSerializerOptions)
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

	/// <summary>
	/// Gets the CPD lists API.
	/// </summary>
	public ICpdLists CpdLists { get; }

	/// <summary>
	/// Gets the departments API.
	/// </summary>
	public IDepartments Departments { get; }

	/// <summary>
	/// Gets the employee GLDs API.
	/// </summary>
	public IEmpGlds EmpGlds { get; }

	/// <summary>
	/// Gets the expense categories API.
	/// </summary>
	public IExpenseCategories ExpenseCategories { get; }

	/// <summary>
	/// Gets the expense reports API.
	/// </summary>
	public IExpenseReports ExpenseReports { get; }

	/// <summary>
	/// Gets the expenses API.
	/// </summary>
	public IExpenses Expenses { get; }

	/// <summary>
	/// Gets the expense report GLDs API.
	/// </summary>
	public IExpenseReportGlds ExpenseReportGlds { get; }

	/// <summary>
	/// Gets the invoice reports API.
	/// </summary>
	public IInvoiceReports InvoiceReports { get; }

	/// <summary>
	/// Gets the invoices API.
	/// </summary>
	public IInvoices Invoices { get; }

	/// <summary>
	/// Gets the mileage rates API.
	/// </summary>
	public IMileageRates MileageRates { get; }

	/// <summary>
	/// Gets the mileage rate details API.
	/// </summary>
	public IMileageRateDetails MileageRateDetails { get; }

	/// <summary>
	/// Gets the receipts API.
	/// </summary>
	public IReceipts Receipts { get; }

	/// <summary>
	/// Gets the users API.
	/// </summary>
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

	/// <inheritdoc />
	public void Dispose()
	{
		_httpClient.Dispose();

		GC.SuppressFinalize(this);
	}
}
