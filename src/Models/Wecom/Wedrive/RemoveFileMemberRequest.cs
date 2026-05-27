using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>删除文件成员请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97888</remarks>
public record RemoveFileMemberRequest
{
    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public required string FileId { get; init; }

    /// <summary>成员类型，1-成员，2-部门</summary>
    [JsonPropertyName("type")]
    public required int Type { get; init; }

    /// <summary>成员 ID 列表或部门 ID 列表</summary>
    [JsonPropertyName("auth_id_list")]
    public required string[] AuthIdList { get; init; }
}