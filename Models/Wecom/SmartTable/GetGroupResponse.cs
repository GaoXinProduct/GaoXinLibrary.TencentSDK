using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>查询编组响应</summary>
public class GetGroupResponse : WecomBaseResponse
{
    /// <summary>编组列表</summary>
    [JsonPropertyName("groups")] public GroupInfo[]? Groups { get; set; }
}
