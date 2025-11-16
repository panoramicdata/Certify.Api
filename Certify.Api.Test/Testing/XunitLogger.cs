using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace Certify.Api.Test.Testing;

/// <summary>
/// Logger implementation that writes to xUnit's ITestOutputHelper
/// </summary>
internal sealed class XunitLogger(string categoryName, ITestOutputHelper testOutputHelper) : ILogger
{
	public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default;

	public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

	public void Log<TState>(
		LogLevel logLevel,
		EventId eventId,
		TState state,
		Exception? exception,
		Func<TState, Exception?, string> formatter)
	{
		if (!IsEnabled(logLevel))
		{
			return;
		}

		var message = formatter(state, exception);
		
		if (string.IsNullOrEmpty(message) && exception == null)
		{
			return;
		}

		var logMessage = $"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss.fff}] [{logLevel}] [{categoryName}] {message}";
		
		if (exception != null)
		{
			logMessage += Environment.NewLine + exception;
		}

		testOutputHelper.WriteLine(logMessage);
	}
}
