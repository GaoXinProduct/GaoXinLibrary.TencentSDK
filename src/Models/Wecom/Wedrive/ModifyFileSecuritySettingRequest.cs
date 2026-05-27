using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>修改文件安全设置请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97892</remarks>
public record ModifyFileSecuritySettingRequest
{
    /// <summary>文件 ID</summary>
    [JsonPropertyName("fileid")]
    public required string FileId { get; init; }

    /// <summary>安全设置，0-关闭，1-开启（仅微文档支持）</summary>
    [JsonPropertyName("security_enable")]
    public required int SecurityEnable { get; init; }
}