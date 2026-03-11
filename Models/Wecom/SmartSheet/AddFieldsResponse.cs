using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>添加字段响应</summary>
public class AddFieldsResponse : WecomBaseResponse
{
    /// <summary>添加的字段列表</summary>
    [JsonPropertyName("fields")] public SheetField[]? Fields { get; set; }
}
