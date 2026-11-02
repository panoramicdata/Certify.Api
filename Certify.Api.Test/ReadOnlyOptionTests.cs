using AwesomeAssertions;
using Certify.Api.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Certify.Api.Test;

/// <summary>
/// Pure unit tests: a refused write throws before any request is sent, so no credentials or account are needed.
/// </summary>
public class ReadOnlyOptionTests
{
	private static CertifyClient NewClient(bool isReadOnly)
		=> new("fake-key", "fake-secret", new CertifyClientOptions { IsReadOnly = isReadOnly });

	/// <summary>The option defaults to false..</summary>
	[Fact]
	public void IsReadOnly_DefaultsToFalse()
		=> new CertifyClientOptions().IsReadOnly.Should().BeFalse();

	/// <summary>A POST is refused (Refit wraps the handler exception in ApiRequestException)..</summary>
	[Fact]
	public async Task PostIsRefused_WhenIsReadOnly()
	{
		using var client = NewClient(true);

		var act = () => client.Departments.UpdateAsync(new Department(), TestContext.Current.CancellationToken);

		(await act.Should().ThrowAsync<Refit.ApiRequestException>()).WithInnerException<InvalidOperationException>();
	}

	/// <summary>A PUT is refused..</summary>
	[Fact]
	public async Task PutIsRefused_WhenIsReadOnly()
	{
		using var client = NewClient(true);

		var act = () => client.Departments.CreateAsync(new Department(), TestContext.Current.CancellationToken);

		(await act.Should().ThrowAsync<Refit.ApiRequestException>()).WithInnerException<InvalidOperationException>();
	}
}
