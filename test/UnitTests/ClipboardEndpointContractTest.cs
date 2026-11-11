using FluentAssertions;
using Orchid.Contract;
using Xunit;

namespace Orchid.UnitTests.Contract;

public sealed class ClipboardEndpointContractTest
{
    [Fact]
    public void RelativePathsShouldNotStartWithSlashAndStagingUrlShouldUseSubpath()
    {
        // Given & When
        string basePath = ClipboardEndpointContract.CanonicalBasePath;
        string stagingUrl = ClipboardEndpointContract.StagingRelayBaseUrl;
        string hubPath = ClipboardEndpointContract.HubRelativePath;
        string pushPath = ClipboardEndpointContract.ApiPushRelativePath;

        // Then
        basePath.Should().Be("/orchid");
        stagingUrl.Should().Be("https://stag.botanicsoft.com/orchid");
        hubPath.Should().NotStartWith("/");
        pushPath.Should().NotStartWith("/");
    }
}