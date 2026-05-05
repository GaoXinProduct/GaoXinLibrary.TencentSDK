using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>查询子表响应</summary>
public class GetSubTableResponse : WecomBaseResponse
{
    /// <summary>子表列表</summary>
    [JsonPropertyName("sheets")] public SubTableInfo[]? Sheets { get; set; }
}
