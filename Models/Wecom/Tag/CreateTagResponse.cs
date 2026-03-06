using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

// ─── 响应模型 ──────────────────────────────────────────────────────────────

public class CreateTagResponse : WecomBaseResponse
{
    [JsonPropertyName("tagid")] public int TagId { get; set; }
}

