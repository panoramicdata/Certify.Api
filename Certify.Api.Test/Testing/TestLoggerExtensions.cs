using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Certify.Api.Test.Testing;

/// <summary>
/// Extension methods for creating loggers for xUnit tests
/// </summary>
internal static class TestLoggerExtensions
{
	/// <summary>
	/// Creates an ILogger that writes to xUnit's ITestOutputHelper
	/// </summary>
	/// <param name="testOutputHelper">The xUnit test output helper</param>
	/// <param name="categoryName">Optional category name for the logger</param>
	/// <returns>An ILogger instance</returns>
	public static ILogger CreateLogger(this ITestOutputHelper testOutputHelper, string? categoryName = null)
	{
		categoryName ??= "Test";
		return new XunitLogger(categoryName, testOutputHelper);
	}

	/// <summary>
	/// Creates an ILoggerFactory that uses xUnit's ITestOutputHelper
	/// </summary>
	/// <param name="testOutputHelper">The xUnit test output helper</param>
	/// <returns>An ILoggerFactory instance</returns>
	public static ILoggerFactory CreateLoggerFactory(this ITestOutputHelper testOutputHelper)
	{
		var factory = LoggerFactory.Create(builder =>
		{
			builder.AddProvider(new XunitLoggerProvider(testOutputHelper));
			builder.SetMinimumLevel(LogLevel.Trace);
		});

		return factory;
	}

	/// <summary>
	/// Creates a typed ILogger&lt;T&gt; that writes to xUnit's ITestOutputHelper
	/// </summary>
	/// <typeparam name="T">The type for the logger category</typeparam>
	/// <param name="testOutputHelper">The xUnit test output helper</param>
	/// <returns>An ILogger&lt;T&gt; instance</returns>
	public static ILogger<T> CreateLogger<T>(this ITestOutputHelper testOutputHelper)
	{
		var factory = testOutputHelper.CreateLoggerFactory();
		return factory.CreateLogger<T>();
	}
}
