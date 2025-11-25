using Microsoft.Extensions.Logging;
using System;
using Xunit;

namespace Certify.Api.Test;

internal class XunitLogger(ITestOutputHelper testOutputHelper, string categoryName) : ILogger
{
	private readonly ITestOutputHelper _testOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));
	private readonly string _categoryName = categoryName ?? throw new ArgumentNullException(nameof(categoryName));

	public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

	public bool IsEnabled(LogLevel logLevel) => true;

	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
	{
		if (!IsEnabled(logLevel))
		{
			return;
		}

		ArgumentNullException.ThrowIfNull(formatter);

		var message = formatter(state, exception);

		if (string.IsNullOrEmpty(message) && exception == null)
		{
			return;
		}

		var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{logLevel}] {_categoryName}: {message}";

		if (exception != null)
		{
			logEntry += Environment.NewLine + exception;
		}

		try
		{
			_testOutputHelper.WriteLine(logEntry);
		}
		catch
		{
			// Ignore exceptions from test output helper (e.g., if test has already completed)
		}
	}
}
