using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>文本消息内容</summary>
public sealed class CustomTextContent
{
    [JsonPropertyName("content")] public required string Content { get; set; }
}

