using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>创建标签响应</summary>
public class CreateTagResponse : WechatBaseResponse
{
    [JsonPropertyName("tag")] public TagItem? Tag { get; set; }
}

