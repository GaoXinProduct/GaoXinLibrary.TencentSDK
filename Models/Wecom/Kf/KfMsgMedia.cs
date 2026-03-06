using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>媒体消息内容（图片/语音/视频/文件）</summary>
public class KfMsgMedia
{
    /// <summary>媒体文件 id</summary>
    [JsonPropertyName("media_id")] public string? MediaId { get; set; }
}

