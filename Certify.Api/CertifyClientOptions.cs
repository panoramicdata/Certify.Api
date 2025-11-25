using System;

namespace Certify.Api;

/// <summary>
/// Options for the certifyClient
/// </summary>
public class CertifyClientOptions
{
	public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(120);
}