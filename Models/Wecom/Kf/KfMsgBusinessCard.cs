using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>名片消息内容</summary>
public class KfMsgBusinessCard
{
    /// <summary>名片 userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }
}

