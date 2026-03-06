using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>媒体消息内容（图片/语音）</summary>
public class CustomMsgMedia { [JsonPropertyName("media_id")] public required string MediaId { get; set; } }

