using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取公众号已创建的标签响应（GET /cgi-bin/tags/get）</summary>
public class GetTagsResponse : WechatBaseResponse
{
    [JsonPropertyName("tags")] public List<TagItem>? Tags { get; set; }
}

