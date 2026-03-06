using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>批量打标签/取消标签请求</summary>
public class BatchTagRequest
{
    [JsonPropertyName("openid_list")] public required List<string> OpenIdList { get; set; }
    [JsonPropertyName("tagid")] public required int TagId { get; set; }
}

