using Microsoft.Extensions.Logging;
using System;

namespace Certify.Api;

/// <summary>
/// Options for the certifyClient
/// </summary>
public class CertifyClientOptions
{
	public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(120);
	public ILogger? Logger { get; internal set; }
}