using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>修改客服账号请求</summary>
public class KfAccountUpdateRequest
{
    /// <summary>客服账号 id</summary>
    [JsonPropertyName("open_kfid")] public string OpenKfId { get; set; } = string.Empty;

    /// <summary>客服名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>客服头像的 media_id</summary>
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }
}

