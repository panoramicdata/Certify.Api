using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Http
{
	internal class AuthenticatedHttpClientHandler : HttpClientHandler
	{
		private readonly string apiKey;
		private readonly string apiSecret;

		public AuthenticatedHttpClientHandler(string apiKey, string apiSecret)
		{
			this.apiKey = apiKey;
			this.apiSecret = apiSecret;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			// The default content header being set by refit seems to be "Content-Type: application/json; charset=utf-8"
			// Certify does NOT like this - needs to just be "application/json" otherwise you'll get an HTML response with "HTTP Error 400. The request has an invalid header name."
			request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			request.Headers.Add("x-api-key", apiKey);
			request.Headers.Add("x-api-secret", apiSecret);

#if DEBUG
			var requestId = Guid.NewGuid();
			Debug.WriteLine($"{requestId} REQUEST ({request.Method} - {request.RequestUri})");
			Debug.WriteLine($"{requestId} ** Headers");
			foreach (var header in request.Headers)
			{
				Debug.WriteLine($"{requestId} {header.Key}: {string.Join(", ", header.Value)}");
			}
			Debug.WriteLine($"{requestId} ** Content Headers:");
			foreach (var header in request.Content.Headers)
			{
				Debug.WriteLine($"{requestId} {header.Key}: {string.Join(", ", header.Value)}");
			}
			Debug.WriteLine($"{requestId} ** Content:");
			var requestContent = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
			Debug.WriteLine($"{requestId} {requestContent}");
#endif

			var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
#if DEBUG
			Debug.WriteLine($"{requestId} RESPONSE");
			Debug.WriteLine($"{requestId} - {response.StatusCode} ({(int)response.StatusCode}) '{response.ReasonPhrase}'");
			if (response.Content != null)
			{
				Debug.WriteLine($"{requestId} ** Content Headers:");
				foreach (var header in response.Content.Headers)
				{
					Debug.WriteLine($"{requestId} {header.Key}: {string.Join(", ", header.Value)}");
				}

				if (response.Content is StringContent || IsTextBasedContentType(response.Headers) || IsTextBasedContentType(response.Content.Headers))
				{
					var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

					Debug.WriteLine($"{requestId} ** Content:");
					// Use below for the whole thing
					//Debug.WriteLine($"{requestId} {result}");
					// Use below for more truncated version
					Debug.WriteLine($"{requestId} {string.Join("", result.Cast<char>().Take(1024))}...");
				}
			}
#endif
			return response;
		}

#if DEBUG
		private readonly string[] types = new[] { "html", "text", "xml", "json", "txt", "x-www-form-urlencoded" };

		private bool IsTextBasedContentType(HttpHeaders headers)
		{
			if (!headers.TryGetValues("Content-Type", out var values))
			{
				return false;
			}

			var header = string.Join(" ", values).ToLowerInvariant();

			return types.Any(t => header.Contains(t));
		}
#endif
	}
}
