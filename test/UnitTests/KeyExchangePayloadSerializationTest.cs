using System.Security.Cryptography;
using System.Text.Json;
using FluentAssertions;
using Orchid.Contract.Payload;
using Xunit;

namespace Orchid.UnitTest.Contract;

/// <summary>
/// <see cref="KeyExchangePayload"/>의 결정론적 JSON 직렬화 및 역직렬화 무결성을 검증하는 테스트입니다.
/// </summary>
public sealed class KeyExchangePayloadSerializationTest
{
    [Fact]
    public void KeyExchangePayloadShouldSerializeAndDeserializeDeterministically()
    {
        // Given
        byte[] publicKey = new byte[65];
        RandomNumberGenerator.Fill(publicKey);
        KeyExchangePayload original = new KeyExchangePayload(
            Guid.NewGuid(),
            publicKey,
            "ECDH-P256",
            DateTimeOffset.UtcNow);

        // When
        string json = JsonSerializer.Serialize(original);
        KeyExchangePayload? deserialized = JsonSerializer.Deserialize<KeyExchangePayload>(json);

        // Then
        deserialized.Should().NotBeNull();
        deserialized.Should().BeEquivalentTo(original);
    }
}
