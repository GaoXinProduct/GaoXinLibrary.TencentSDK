using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Core;

/// <summary>
/// 统一共享密钥载荷
/// <para>
/// 由主服务器通过 <c>GetSharedSecretAsync()</c> 加密生成，备服务器配置 <c>SecretShareUrl</c> 后
/// SDK 自动拉取并解密，将载荷中的各项敏感信息分发至对应的缓存提供程序。<br/>
/// 传输格式：ChaCha20-Poly1305 加密后的 JSON，编码为 <c>Base64( nonce[12] + ciphertext[N] + tag[16] )</c>。
/// </para>
/// </summary>
public sealed class SharedSecretPayload
{
    /// <summary>access_token 明文</summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>access_token 剩余有效秒数</summary>
    [JsonPropertyName("token_expires_in")]
    public int TokenExpiresIn { get; set; }

    /// <summary>
    /// JS-SDK jsapi_ticket 明文（公众号：jsapi；企业微信：企业级 jsapi_ticket）
    /// <para>可为 <c>null</c>，表示主服务器尚未获取过该 Ticket。</para>
    /// </summary>
    [JsonPropertyName("jsapi_ticket")]
    public string? JsApiTicket { get; set; }

    /// <summary>jsapi_ticket 剩余有效秒数</summary>
    [JsonPropertyName("ticket_expires_in")]
    public int TicketExpiresIn { get; set; }

    // ─── 微信专属 ────────────────────────────────────────────────────────────

    /// <summary>应用 ID（微信 AppId）；备服务器可凭此回写 Options</summary>
    [JsonPropertyName("app_id")]
    public string? AppId { get; set; }

    /// <summary>应用密钥（微信 AppSecret）；备服务器可凭此回写 Options</summary>
    [JsonPropertyName("app_secret")]
    public string? AppSecret { get; set; }

    // ─── 企业微信专属 ─────────────────────────────────────────────────────────

    /// <summary>企业 ID（CorpId）；备服务器可凭此回写 Options</summary>
    [JsonPropertyName("corp_id")]
    public string? CorpId { get; set; }

    /// <summary>应用凭证密钥（CorpSecret）；备服务器可凭此回写 Options</summary>
    [JsonPropertyName("corp_secret")]
    public string? CorpSecret { get; set; }

    /// <summary>自建应用 AgentId；备服务器可凭此回写 Options</summary>
    [JsonPropertyName("agent_id")]
    public int AgentId { get; set; }

    /// <summary>
    /// 应用级 jsapi_ticket 明文（企业微信专属，用于 <c>wx.agentConfig</c>）
    /// <para>可为 <c>null</c>，表示主服务器尚未获取过该 Ticket。</para>
    /// </summary>
    [JsonPropertyName("agent_ticket")]
    public string? AgentTicket { get; set; }

    /// <summary>应用级 jsapi_ticket 剩余有效秒数</summary>
    [JsonPropertyName("agent_ticket_expires_in")]
    public int AgentTicketExpiresIn { get; set; }
}
