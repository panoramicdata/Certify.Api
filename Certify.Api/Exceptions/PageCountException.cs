using System;

namespace Certify.Api.Exceptions;

/// <summary>
/// Exception thrown when the total record count does not match the number of records retrieved.
/// </summary>
[Serializable]
public class PageCountMismatchException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="PageCountMismatchException"/> class.
	/// </summary>
	public PageCountMismatchException()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="PageCountMismatchException"/> class with a message.
	/// </summary>
	/// <param name="message">The error message.</param>
	public PageCountMismatchException(string message) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="PageCountMismatchException"/> class with a message and inner exception.
	/// </summary>
	/// <param name="message">The error message.</param>
	/// <param name="innerException">The inner exception.</param>
	public PageCountMismatchException(string message, Exception innerException) : base(message, innerException)
	{
	}
}