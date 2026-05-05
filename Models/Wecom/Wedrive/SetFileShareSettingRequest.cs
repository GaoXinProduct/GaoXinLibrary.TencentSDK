using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>设置文件分享设置请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97889</remarks>
public record SetFileShareSettingRequest
{
    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public required string FileId { get; init; }

    /// <summary>分享设置，0-仅文件所有者可分享，1-任何人可分享</summary>
    [JsonPropertyName("share_mode")]
    public required int ShareMode { get; init; }
}