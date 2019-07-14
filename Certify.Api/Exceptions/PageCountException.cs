using System;
using System.Runtime.Serialization;

namespace Certify.Api.Exceptions
{
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

		protected PageCountMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}