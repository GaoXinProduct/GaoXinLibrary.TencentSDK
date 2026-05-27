using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>新增文件成员响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/93658</remarks>
public class AddFileMemberResponse : WecomBaseResponse
{
    /// <summary>无效的成员 ID 列表</summary>
    [JsonPropertyName("invalidauth_list")]
    public InvalidAuth[]? InvalidAuthList { get; set; }
}

/// <summary>无效权限信息</summary>
public class InvalidAuth
{
    /// <summary>类型，1-成员，2-部门</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>成员 ID 或部门 ID</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }
}