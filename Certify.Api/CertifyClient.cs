using Refit;

namespace Certify.Api
{
	/// <summary>
	/// The main Certify Client
	/// </summary>
	public class CertifyClient
	{
		private readonly string _apiKey;
		private readonly string _apiSecret;

		public CertifyClient(string apiKey, string apiSecret, CertifyClientOptions options = default)
		{
			_apiKey = apiKey;
			_apiSecret = apiSecret;
			var abc = RestService.For<string>("")
				//options?.HttpClient ?? new;
		}
	}
}
