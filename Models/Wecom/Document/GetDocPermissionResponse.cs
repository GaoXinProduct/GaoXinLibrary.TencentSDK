using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>获取文档权限响应</summary>
public class GetDocPermissionResponse : WecomBaseResponse
{
    /// <summary>权限信息</summary>
    [JsonPropertyName("permission_info")] public DocPermissionInfo? PermissionInfo { get; set; }
}
