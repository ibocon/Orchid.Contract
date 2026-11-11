// keep: FluentAssertions extension methods
using FluentAssertions;
// keep: NetArchTest fluent rules
using NetArchTest.Rules;
// keep: xUnit Fact attribute
using Xunit;

namespace Orchid.ArchTests;

/// <summary>
/// Orchid.Contract ?쇱씠釉뚮윭由ъ쓽 ?붾（???댁쇅遺 ?섏〈???쒕줈(?쒖닔 BCL 怨꾩빟) 蹂댁옣??寃利앺븯???꾪궎?띿쿂 ?뚯뒪?몄엯?덈떎.
/// </summary>
public sealed class ContractPurityTest
{
    /// <summary>
    /// Contract ?쇱씠釉뚮윭由ш? ?붾（?????ㅻⅨ ?꾨줈?앺듃???섏〈?섏? ?딅뒗吏 寃利앺빀?덈떎.
    /// </summary>
    [Fact]
    public void Contract_ShouldNotDependOn_InternalProjects()
    {
        // Given
        var contractAssembly = typeof(Orchid.Contract.Payload.EncryptedPayload).Assembly;

        // When
        // ??Orchid.Contract???붾（????? ?꾨줈?앺듃???섏〈?댁꽌?????⑥쓣 媛뺤젣
        TestResult result = Types.InAssembly(contractAssembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                "Orchid.Core",
                "Orchid.Desktop",
                "Orchid.Mobile",
                "Orchid.Web",
                "Orchid.Service")
            .GetResult();

        // Then
        result.IsSuccessful.Should().BeTrue("Contract ?쇱씠釉뚮윭由щ뒗 100% ?낅┰?곸씤 ?쒖닔 怨꾩빟?댁뼱???⑸땲??");
    }
}
