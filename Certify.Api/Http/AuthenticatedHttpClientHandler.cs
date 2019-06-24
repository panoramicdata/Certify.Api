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
			request.Headers.Add("x-api-key", apiKey);
			request.Headers.Add("x-api-secret", apiSecret);
			var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
#if DEBUG
			var requestId = Guid.NewGuid();
			Debug.WriteLine($"{requestId} - {response.StatusCode} ({(int)response.StatusCode}) '{response.ReasonPhrase}'");
			if (response.Content != null)
			{
				foreach (var header in response.Content.Headers)
				{
					Debug.WriteLine($"{requestId} {header.Key}: {string.Join(", ", header.Value)}");
				}

				if (response.Content is StringContent || IsTextBasedContentType(response.Headers) || IsTextBasedContentType(response.Content.Headers))
				{
					var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

					Debug.WriteLine($"{requestId} Content:");
					Debug.WriteLine($"{requestId} {result}");
					// Use below for more truncated version
					//Debug.WriteLine($"{requestId} {string.Join("", result.Cast<char>().Take(255))}...");
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
