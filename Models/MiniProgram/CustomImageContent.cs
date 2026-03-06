using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>图片消息内容</summary>
public class CustomImageContent
{
    [JsonPropertyName("media_id")] public required string MediaId { get; set; }
}

