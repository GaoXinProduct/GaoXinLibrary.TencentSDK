using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartTable;

/// <summary>添加编组响应</summary>
public class AddGroupResponse : WecomBaseResponse
{
    /// <summary>编组 ID</summary>
    [JsonPropertyName("group_id")] public string? GroupId { get; set; }
}
