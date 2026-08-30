using AwesomeAssertions;
using Certify.Api.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using Xunit;

namespace Certify.Api.Test;

public abstract class CertifyTest : IDisposable
{
	private bool disposedValue;

	protected static CancellationToken CancellationToken => TestContext.Current.CancellationToken;

	protected CertifyClient CertifyClient { get; }

	public ILogger Logger { get; }

	protected CertifyTest(ITestOutputHelper iTestOutputHelper)
	{
		Logger = new XunitLogger(iTestOutputHelper, GetType().Name);

		var testConfig = new TestConfig(Logger);
		CertifyClient = testConfig.CertifyClient;
	}

	/// <summary>
	/// Asserts the paging metadata common to every page that returned at least one record.
	/// </summary>
	protected static void AssertPopulatedPage(Page page)
	{
		page.Should().NotBeNull();
		page.TotalRecordCount.Should().BePositive();
		page.TotalPageCount.Should().BePositive();
		page.PageNumber.Should().BePositive();
		page.PageRecordCount.Should().BePositive();
	}

	/// <summary>
	/// Asserts the paging metadata of a page fetched for a single, known item.
	/// </summary>
	protected static void AssertSingleRecordPage(Page page)
	{
		page.Should().NotBeNull();
		page.TotalRecordCount.Should().Be(1);
		page.TotalPageCount.Should().Be(1);
		page.PageNumber.Should().Be(1);
		page.PageRecordCount.Should().Be(1);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				CertifyClient.Dispose();
			}

			disposedValue = true;
		}
	}

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
