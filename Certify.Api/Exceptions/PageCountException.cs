using System;

namespace Certify.Api.Exceptions;

[Serializable]
public class PageCountMismatchException : Exception
{
	public PageCountMismatchException()
	{
	}

	public PageCountMismatchException(string message) : base(message)
	{
	}

	public PageCountMismatchException(string message, Exception innerException) : base(message, innerException)
	{
	}
}