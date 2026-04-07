using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;

namespace Certify.Api.Test;

internal class TestConfig
{
	public TestConfig(ILogger logger)
	{
		logger.LogDebug("Loading config...");
		var location = typeof(TestConfig).GetTypeInfo().Assembly.Location;
		var dirPath = Path.Combine(Path.GetDirectoryName(location) ?? string.Empty, "../../..");
		var builder = new ConfigurationBuilder()
			.SetBasePath(dirPath)
			.AddJsonFile("appsettings.json", optional: true)
			.AddJsonFile("appsettings.example.json", optional: true);
		var configuration = builder.Build();
		var apiKey = configuration["Config:Credentials:ApiKey"];
		var apiSecret = configuration["Config:Credentials:ApiSecret"];

		if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(apiSecret) || apiKey == "XXX" || apiSecret == "XXX")
		{
			throw new InvalidDataException("ApiKey/ApiSecret not configured. Add Certify.Api.Test/appsettings.json with valid credentials to run integration tests.");
		}

		logger.LogDebug("Creating client...");
		CertifyClient = new CertifyClient(
			apiKey,
			apiSecret);
		Logger = logger;
	}

	public ILogger Logger { get; }

	internal CertifyClient CertifyClient { get; }
}