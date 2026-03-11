using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>添加子表响应</summary>
public class AddSheetResponse : WecomBaseResponse
{
    /// <summary>添加的子表信息</summary>
    [JsonPropertyName("properties")] public SheetInfo[]? Properties { get; set; }
}
