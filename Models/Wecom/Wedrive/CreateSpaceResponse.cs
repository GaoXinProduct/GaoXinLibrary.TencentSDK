using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>新建空间响应</summary>
public class CreateSpaceResponse : WecomBaseResponse
{
    /// <summary>空间ID</summary>
    [JsonPropertyName("spaceid")] public string? SpaceId { get; set; }
}
