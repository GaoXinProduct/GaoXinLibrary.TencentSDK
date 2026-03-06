using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>媒体消息内容（图片/语音/视频/文件）</summary>
public class MsgAuditMedia
{
    /// <summary>SDK 文件 ID，用于通过 GetMediaData 下载</summary>
    [JsonPropertyName("sdkfileid")] public string? SdkFileId { get; set; }

    /// <summary>文件大小</summary>
    [JsonPropertyName("filesize")] public long FileSize { get; set; }

    /// <summary>文件名（仅文件消息）</summary>
    [JsonPropertyName("filename")] public string? FileName { get; set; }

    /// <summary>文件后缀名</summary>
    [JsonPropertyName("fileext")] public string? FileExt { get; set; }

    /// <summary>md5 校验值</summary>
    [JsonPropertyName("md5sum")] public string? Md5Sum { get; set; }

    /// <summary>播放时长（语音/视频，秒）</summary>
    [JsonPropertyName("play_length")] public int PlayLength { get; set; }
}

