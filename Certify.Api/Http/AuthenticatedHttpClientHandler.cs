using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
			return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
		}
	}
}
