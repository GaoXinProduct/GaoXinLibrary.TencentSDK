using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Dial;

/// <summary>获取公费电话拨打记录响应</summary>
public class GetDialRecordResponse : WecomBaseResponse
{
    /// <summary>拨打记录列表</summary>
    [JsonPropertyName("record")] public DialRecord[]? Record { get; set; }
}
