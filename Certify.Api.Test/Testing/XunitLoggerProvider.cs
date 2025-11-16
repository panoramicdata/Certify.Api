using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace Certify.Api.Test.Testing;

/// <summary>
/// Logger provider that creates XunitLogger instances
/// </summary>
internal sealed class XunitLoggerProvider(ITestOutputHelper testOutputHelper) : ILoggerProvider
{
	public ILogger CreateLogger(string categoryName) => new XunitLogger(categoryName, testOutputHelper);

	public void Dispose()
	{
		// Nothing to dispose
	}
}
