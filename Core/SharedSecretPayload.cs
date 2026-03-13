using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 统一共享密钥载荷
/// <para>
/// 主服务通过 <see cref="TencentAccessTokenProvider.GetSharedSecretAsync"/> 将此载荷加密后返回给备服务，
/// 备服务解密后获得所有敏感信息（access_token、jsapi_ticket、AppId、AppSecret 等），
/// 无需在配置中存储 AppId / AppSecret。
/// </para>
/// </summary>
public sealed class SharedSecretPayload
{
    /// <summary>access_token</summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>access_token 剩余有效秒数</summary>
    [JsonPropertyName("token_expires_in")]
    public int TokenExpiresIn { get; set; }

    /// <summary>jsapi_ticket（可选，公众号场景使用）</summary>
    [JsonPropertyName("jsapi_ticket")]
    public string? JsApiTicket { get; set; }

    /// <summary>jsapi_ticket 剩余有效秒数</summary>
    [JsonPropertyName("ticket_expires_in")]
    public int TicketExpiresIn { get; set; }

    /// <summary>应用 ID（AppID，微信公众号/小程序/开放平台使用）</summary>
    [JsonPropertyName("app_id")]
    public string AppId { get; set; } = string.Empty;

    /// <summary>应用密钥（AppSecret，微信公众号/小程序/开放平台使用）</summary>
    [JsonPropertyName("app_secret")]
    public string AppSecret { get; set; } = string.Empty;

    // ─── 企业微信扩展字段 ─────────────────────────────────────────────────────

    /// <summary>企业 ID（CorpId，企业微信使用）</summary>
    [JsonPropertyName("corp_id")]
    public string? CorpId { get; set; }

    /// <summary>应用凭证密钥（CorpSecret，企业微信使用）</summary>
    [JsonPropertyName("corp_secret")]
    public string? CorpSecret { get; set; }

    /// <summary>自建应用 AgentId（企业微信使用）</summary>
    [JsonPropertyName("agent_id")]
    public int? AgentId { get; set; }

    /// <summary>应用级 jsapi_ticket（可选，企业微信使用）</summary>
    [JsonPropertyName("agent_ticket")]
    public string? AgentTicket { get; set; }

    /// <summary>应用级 jsapi_ticket 剩余有效秒数</summary>
    [JsonPropertyName("agent_ticket_expires_in")]
    public int AgentTicketExpiresIn { get; set; }
}
