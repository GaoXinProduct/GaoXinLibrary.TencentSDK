using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取空间信息响应</summary>
public class GetSpaceInfoResponse : WecomBaseResponse
{
    /// <summary>空间信息</summary>
    [JsonPropertyName("space_info")] public SpaceInfo? SpaceInfo { get; set; }
}
