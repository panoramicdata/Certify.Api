using Microsoft.Extensions.Logging;
using System;
using System.IO;
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

		try
		{
			var testConfig = new TestConfig(Logger);
			CertifyClient = testConfig.CertifyClient;
		}
		catch (InvalidDataException ex)
		{
			throw Xunit.Sdk.SkipException.ForSkip(ex.Message);
		}
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
