using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>图文消息内容</summary>
public class CustomMsgNews
{
    [JsonPropertyName("articles")] public required List<CustomMsgArticle> Articles { get; set; }
}

