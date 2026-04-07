using System;

namespace Certify.Api;

/// <summary>
/// Options for the certifyClient
/// </summary>
public class CertifyClientOptions
{
	/// <summary>
	/// Gets or sets the HTTP request timeout.
	/// </summary>
	public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(120);
}