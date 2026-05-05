using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>新增文件成员请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/93658</remarks>
public record AddFileMemberRequest
{
    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public required string FileId { get; init; }

    /// <summary>成员权限列表</summary>
    [JsonPropertyName("auth_list")]
    public required FileMemberAuth[] AuthList { get; init; }
}

/// <summary>文件成员权限信息</summary>
public class FileMemberAuth
{
    /// <summary>成员 userid 或部门 id</summary>
    [JsonPropertyName("type")]
    public int Type { get; init; }

    /// <summary>成员 ID 或部门 ID</summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>权限，1-可查看，2-可编辑</summary>
    [JsonPropertyName("auth")]
    public int Auth { get; init; }
}