using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Certify.Api.Test;

/// <summary>Builds a fake of an interface that answers only the calls a test cares about.</summary>
public class FakeProxy : DispatchProxy
{
	private Func<string, object?[], object?> _handler = (name, _) => throw new NotSupportedException(name);

	public static T Create<T>(Func<string, object?[], object?> handler)
		where T : class
	{
		var proxy = Create<T, FakeProxy>();
		((FakeProxy)(object)proxy)._handler = handler;
		return proxy;
	}

	/// <summary>
	/// Fakes the interface's single GetPageAsync method, recording each call's arguments and
	/// answering with <paramref name="respond"/>.
	/// </summary>
	public static T RecordPages<T>(List<object?[]> calls, Func<object?[], object?> respond)
		where T : class
		=> Create<T>((name, args) =>
		{
			if (name != "GetPageAsync")
			{
				throw new NotSupportedException(name);
			}

			calls.Add(args);
			return respond(args);
		});

	/// <summary>The filter arguments of a recorded call: everything but the page number and the cancellation token.</summary>
	public static List<object?> Filters(object?[] args, int pageIndex)
		=> [.. args.Where((_, index) => index != pageIndex && index != args.Length - 1)];

	public static string? Text(object?[] args, int index) => (string?)args[index];

	public static uint? Number(object?[] args, int index) => (uint?)args[index];

	protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
		=> _handler(targetMethod!.Name, args ?? []);
}
