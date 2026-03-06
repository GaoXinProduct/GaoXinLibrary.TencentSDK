using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>获取客服账号列表请求</summary>
public class KfAccountListRequest
{
    /// <summary>分页偏移量，非必填</summary>
    [JsonPropertyName("offset")] public int? Offset { get; set; }

    /// <summary>分页大小，最大100</summary>
    [JsonPropertyName("limit")] public int? Limit { get; set; }
}

