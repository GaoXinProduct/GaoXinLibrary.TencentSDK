using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartSheet;

/// <summary>获取子表列表响应</summary>
public class GetSheetsResponse : WecomBaseResponse
{
    /// <summary>子表列表</summary>
    [JsonPropertyName("properties")] public SheetInfo[]? Properties { get; set; }
}
