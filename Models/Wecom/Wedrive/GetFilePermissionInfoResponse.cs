using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取文件权限信息响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97891</remarks>
public class GetFilePermissionInfoResponse : WecomBaseResponse
{
    /// <summary>权限信息列表</summary>
    [JsonPropertyName("auth_list")]
    public FilePermissionInfo[]? AuthList { get; set; }
}

/// <summary>文件权限信息</summary>
public class FilePermissionInfo
{
    /// <summary>类型，1-成员，2-部门</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>成员 ID 或部门 ID</summary>
    [JsonPropertyName("auth_id")]
    public string? AuthId { get; set; }

    /// <summary>权限，1-可查看，2-可编辑</summary>
    [JsonPropertyName("auth")]
    public int Auth { get; set; }
}