using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>查询字段响应</summary>
public class GetFieldResponse : WecomBaseResponse
{
    /// <summary>字段列表</summary>
    [JsonPropertyName("fields")] public FieldInfo[]? Fields { get; set; }
}
