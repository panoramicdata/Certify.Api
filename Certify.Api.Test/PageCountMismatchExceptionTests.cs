using AwesomeAssertions;
using Certify.Api.Exceptions;
using System;
using Xunit;

namespace Certify.Api.Test;

public class PageCountMismatchExceptionTests
{
	[Fact]
	public void DefaultConstructor_ProducesEmptyMessage()
	{
		var ex = new PageCountMismatchException();
		ex.InnerException.Should().BeNull();
		ex.Should().BeAssignableTo<Exception>();
	}

	[Fact]
	public void MessageConstructor_StoresMessage()
	{
		var ex = new PageCountMismatchException("boom");
		ex.Message.Should().Be("boom");
	}

	[Fact]
	public void MessageAndInnerConstructor_StoresBoth()
	{
		var inner = new InvalidOperationException("inner");
		var ex = new PageCountMismatchException("outer", inner);
		ex.Message.Should().Be("outer");
		ex.InnerException.Should().BeSameAs(inner);
	}
}
