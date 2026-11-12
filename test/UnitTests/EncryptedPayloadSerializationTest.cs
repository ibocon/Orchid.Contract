using System.Text.Json;
using FluentAssertions;
using Orchid.Contract.Payload;
using Xunit;

namespace Orchid.UnitTest.Contract;

public sealed class EncryptedPayloadSerializationTest
{
    [Fact]
    public void EncryptedPayloadShouldSerializeAndDeserializeDeterministically()
    {
        // Given
        EncryptedPayload original = new EncryptedPayload(
            Guid.NewGuid(),
            [1, 2, 3, 4],
            [5, 6, 7],
            [8, 9],
            "AES-256-GCM",
            DateTimeOffset.UtcNow);

        // When
        string json = JsonSerializer.Serialize(original);
        EncryptedPayload? deserialized = JsonSerializer.Deserialize<EncryptedPayload>(json);

        // Then
        deserialized.Should().NotBeNull();
        deserialized.Should().BeEquivalentTo(original);
    }

    [Fact]
    public void EncryptedPayloadWithEmptyBytesShouldPreserveEmptyArrays()
    {
        // Given
        EncryptedPayload emptyPayload = new EncryptedPayload(
            Guid.NewGuid(),
            [],
            [],
            [],
            "AES-256-GCM",
            DateTimeOffset.UtcNow);

        // When
        string json = JsonSerializer.Serialize(emptyPayload);
        EncryptedPayload? deserialized = JsonSerializer.Deserialize<EncryptedPayload>(json);

        // Then
        deserialized.Should().NotBeNull();
        deserialized.Should().BeEquivalentTo(emptyPayload);
        deserialized.CipherText.Should().BeEmpty();
    }
}
