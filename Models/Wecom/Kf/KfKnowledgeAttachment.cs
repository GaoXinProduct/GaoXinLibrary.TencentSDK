using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>知识库附件</summary>
public class KfKnowledgeAttachment
{
    /// <summary>附件类型</summary>
    [JsonPropertyName("msgtype")] public string? MsgType { get; set; }

    /// <summary>图片附件</summary>
    [JsonPropertyName("image")] public KfMsgMedia? Image { get; set; }

    /// <summary>链接附件</summary>
    [JsonPropertyName("link")] public KfMsgLink? Link { get; set; }

    /// <summary>视频附件</summary>
    [JsonPropertyName("video")] public KfMsgMedia? Video { get; set; }

    /// <summary>文件附件</summary>
    [JsonPropertyName("file")] public KfMsgMedia? File { get; set; }

    /// <summary>小程序附件</summary>
    [JsonPropertyName("miniprogram")] public KfMsgMiniProgram? MiniProgram { get; set; }
}

