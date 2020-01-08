using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace Certify.Api.Test
{
	public abstract class CertifyTest : IDisposable
	{
		protected CertifyClient CertifyClient { get; }
		public ILogger Logger { get; }

		protected CertifyTest(ITestOutputHelper iTestOutputHelper)
		{
			Logger = iTestOutputHelper.BuildLogger();
			var testConfig = new TestConfig(Logger);
			CertifyClient = testConfig.CertifyClient;
		}

		public void Dispose()
			=> CertifyClient.Dispose();
	}
}
