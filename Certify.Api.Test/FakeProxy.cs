using System;
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

	public static string? Text(object?[] args, int index) => (string?)args[index];

	public static uint? Number(object?[] args, int index) => (uint?)args[index];

	protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
		=> _handler(targetMethod!.Name, args ?? []);
}
