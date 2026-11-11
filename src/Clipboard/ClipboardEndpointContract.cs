namespace Orchid.Contract;

/// <summary>
/// Orchid 서브패스 라우팅 및 클립보드 릴레이 엔드포인트 경로 상수를 정의합니다.
/// </summary>
public static class ClipboardEndpointContract
{
    /// <summary>
    /// 대표 도메인 아래 마운트되는 Orchid 정규 서브패스입니다.
    /// </summary>
    public const string CanonicalBasePath = "/orchid";

    /// <summary>
    /// Staging 환경의 기본 릴레이 서브패스 URL입니다.
    /// </summary>
    public const string StagingRelayBaseUrl = "https://stag.botanicsoft.com/orchid";

    /// <summary>
    /// Production 환경의 기본 릴레이 서브패스 URL입니다.
    /// </summary>
    public const string ProductionRelayBaseUrl = "https://prod.botanicsoft.com/orchid";

    /// <summary>
    /// 서브패스 보존 결합을 위해 선행 슬래시를 제거한 SignalR 허브 상대 경로입니다.
    /// </summary>
    public const string HubRelativePath = "hubs/clipboard";

    /// <summary>
    /// 서브패스 보존 결합을 위해 선행 슬래시를 제거한 클립보드 푸시 API 상대 경로입니다.
    /// </summary>
    public const string ApiPushRelativePath = "api/clipboard/push";
}