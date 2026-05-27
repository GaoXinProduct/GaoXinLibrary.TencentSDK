// ═══════════════════════════════════════════════════════════════════════════

using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 选用模板响应
/// </summary>
public sealed class AddTemplateResponse : WechatBaseResponse
{
    /// <summary>模板ID</summary>
    [JsonPropertyName("pri_tmpl_id")] public string? TemplateId { get; init; }
}