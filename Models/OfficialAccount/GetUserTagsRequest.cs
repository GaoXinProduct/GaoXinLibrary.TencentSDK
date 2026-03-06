using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取用户身上的标签列表请求（POST /cgi-bin/tags/getidlist）</summary>
public class GetUserTagsRequest
{
    [JsonPropertyName("openid")] public required string OpenId { get; set; }
}

