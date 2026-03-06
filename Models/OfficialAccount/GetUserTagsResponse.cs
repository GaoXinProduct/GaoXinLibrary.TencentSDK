using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取用户身上的标签列表响应</summary>
public class GetUserTagsResponse : WechatBaseResponse
{
    [JsonPropertyName("tagid_list")] public List<int>? TagIdList { get; set; }
}

