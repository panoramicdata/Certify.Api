using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Certify.Api.Http;

internal sealed class AuthenticatedHttpClientHandler(string apiKey, string apiSecret, ILogger logger) : HttpClientHandler
{
	private readonly string _apiKey = apiKey;
	private readonly string _apiSecret = apiSecret;
	private readonly ILogger _logger = logger;

#if DEBUG
	private static readonly string[] s_textBasedContentTypes = ["html", "text", "xml", "json", "txt", "x-www-form-urlencoded"];
#endif

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		// The default content header being set by refit seems to be "Content-Type: application/json; charset=utf-8"
		// Certify does NOT like this - needs to just be "application/json" otherwise you'll get an HTML response with "HTTP Error 400. The request has an invalid header name."
		if (request.Content?.Headers.ContentType is not null)
		{
			request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		}

		request.Headers.Add("x-api-key", _apiKey);
		request.Headers.Add("x-api-secret", _apiSecret);

#if DEBUG
		await LogRequestAsync(request, cancellationToken).ConfigureAwait(false);
#endif

		var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

#if DEBUG
		await LogResponseAsync(response, cancellationToken).ConfigureAwait(false);
#endif

		return response;
	}

#if DEBUG
	private async Task LogRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var requestId = Guid.NewGuid();
		_logger.LogDebug("REQUEST ({RequestId}): {Method} - {RequestUri}", requestId, request.Method, request.RequestUri);
		_logger.LogDebug("REQUEST ({RequestId}): Headers", requestId);

		foreach (var header in request.Headers)
		{
			_logger.LogDebug("REQUEST ({RequestId}): {HeaderKey}: {HeaderValue}", requestId, header.Key, string.Join(", ", header.Value));
		}

		if (request.Content is not null)
		{
			_logger.LogDebug("REQUEST ({RequestId}): Content Headers", requestId);
			foreach (var header in request.Content.Headers)
			{
				_logger.LogDebug("REQUEST ({RequestId}): {HeaderKey}: {HeaderValue}", requestId, header.Key, string.Join(", ", header.Value));
			}

			_logger.LogDebug("REQUEST ({RequestId}): Content", requestId);
			var requestContent = await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
			_logger.LogDebug("REQUEST ({RequestId}): {Content}", requestId, requestContent);
		}
		else
		{
			_logger.LogDebug("REQUEST ({RequestId}): No request content", requestId);
		}
	}

	private async Task LogResponseAsync(HttpResponseMessage response, CancellationToken cancellationToken)
	{
		var requestId = Guid.NewGuid();
		_logger.LogDebug("RESPONSE ({RequestId}): {StatusCode} ({StatusCodeInt}) '{ReasonPhrase}'",
			requestId,
			response.StatusCode,
			(int)response.StatusCode, response.ReasonPhrase);

		if (response.Content is not null)
		{
			_logger.LogDebug("RESPONSE ({RequestId}): Content Headers", requestId);
			foreach (var header in response.Content.Headers)
			{
				_logger.LogDebug("RESPONSE ({RequestId}): {HeaderKey}: {HeaderValue}", requestId, header.Key, string.Join(", ", header.Value));
			}

			if (response.Content is StringContent || IsTextBasedContentType(response.Headers) || IsTextBasedContentType(response.Content.Headers))
			{
				var result = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

				_logger.LogDebug("RESPONSE ({RequestId}): Content", requestId);
				var truncatedResult = result.Length > 1024 ? string.Concat(result.AsSpan(0, 1024), "...") : result;
				_logger.LogDebug("RESPONSE ({RequestId}): {Content}", requestId, truncatedResult);
			}
		}
	}

	private static bool IsTextBasedContentType(HttpHeaders headers)
	{
		if (!headers.TryGetValues("Content-Type", out var values))
		{
			return false;
		}

		var header = string.Join(" ", values).ToLowerInvariant();

		return s_textBasedContentTypes.Any(t => header.Contains(t, StringComparison.Ordinal));
	}
#endif
}
