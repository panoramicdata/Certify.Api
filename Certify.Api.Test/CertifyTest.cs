using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace Certify.Api.Test;

public abstract class CertifyTest : IDisposable
{
	private bool disposedValue;

	protected CertifyClient CertifyClient { get; }
	public ILogger Logger { get; }

	protected CertifyTest(ITestOutputHelper iTestOutputHelper)
	{
		Logger = iTestOutputHelper.BuildLogger();
		var testConfig = new TestConfig(Logger);
		CertifyClient = testConfig.CertifyClient;
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
