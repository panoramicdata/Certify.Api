using Certify.Api;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace Certify.Api.Test
{
	public abstract class CertifyTest
	{
		protected CertifyClient CertifyClient { get; }
		public ILogger Logger { get; }

		public CertifyTest(ITestOutputHelper iTestOutputHelper)
		{
			Logger = iTestOutputHelper.BuildLogger();
			var testConfig = new TestConfig(Logger);
			CertifyClient = testConfig.CertifyClient;
		}
	}
}
