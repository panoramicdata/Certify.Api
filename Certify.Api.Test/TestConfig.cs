﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;

namespace Certify.Api.Test
{
	internal class TestConfig
	{
		public TestConfig(ILogger logger)
		{
			logger.LogDebug("Loading config...");
			var location = typeof(TestConfig).GetTypeInfo().Assembly.Location;
			var dirPath = Path.Combine(Path.GetDirectoryName(location) ?? string.Empty, "../../..");
			var builder = new ConfigurationBuilder()
				.SetBasePath(dirPath)
				.AddJsonFile("appsettings.json");
			var configuration = builder.Build();
			logger.LogDebug("Creating client...");
			CertifyClient = new CertifyClient(configuration["Config:Credentials:ApiKey"], configuration["Config:Credentials:ApiSecret"]);
			Logger = logger;
		}

		public ILogger Logger { get; }

		internal CertifyClient CertifyClient { get; }
	}
}