using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>文档权限信息</summary>
public class DocPermissionInfo
{
    /// <summary>权限类型：0-无权限，1-可编辑，2-可查看</summary>
    [JsonPropertyName("permission")] public int Permission { get; set; }

    /// <summary>权限到期时间</summary>
    [JsonPropertyName("permission_expired_time")] public long PermissionExpiredTime { get; set; }
}
