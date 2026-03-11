using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>获取字段列表响应</summary>
public class GetFieldsResponse : WecomBaseResponse
{
    /// <summary>字段列表</summary>
    [JsonPropertyName("fields")] public SheetField[]? Fields { get; set; }
}
