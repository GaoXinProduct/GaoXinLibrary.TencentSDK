using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>下载文件请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97881</remarks>
public record DownloadFileRequest
{
    /// <summary>普通文件 ID，或改用文件选择凭证</summary>
    [JsonPropertyName("fileid")]
    public string? FileId { get; init; }

    /// <summary>选中的微盘文件凭证</summary>
    [JsonPropertyName("selected_ticket")]
    public string? SelectedTicket { get; init; }

    /// <summary>旧模型的下载格式字段</summary>
    [Obsolete("微盘下载接口返回链接和 Cookie。")]
    [JsonIgnore]
    public int DownloadType { get; init; } = 1;
}
