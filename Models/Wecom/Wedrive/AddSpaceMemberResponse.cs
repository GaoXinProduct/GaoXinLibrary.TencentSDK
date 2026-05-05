using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>添加空间成员/部门响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/93656</remarks>
public class AddSpaceMemberResponse : WecomBaseResponse
{
    /// <summary>无效的成员 ID 列表</summary>
    [JsonPropertyName("invalidauth_list")]
    public InvalidSpaceAuth[]? InvalidAuthList { get; set; }
}

/// <summary>无效空间权限信息</summary>
public class InvalidSpaceAuth
{
    /// <summary>类型，1-成员，2-部门</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>成员 ID 或部门 ID</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }
}