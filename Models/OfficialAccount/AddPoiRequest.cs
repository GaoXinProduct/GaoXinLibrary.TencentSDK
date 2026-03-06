using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>创建门店请求（POST /cgi-bin/poi/addpoi）</summary>
public class AddPoiRequest
{
    [JsonPropertyName("business")] public required PoiBusiness Business { get; set; }
}

