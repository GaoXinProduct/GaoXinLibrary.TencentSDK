using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取图文群发总数据响应（POST /datacube/getarticletotal）</summary>
public class ArticleTotalResponse : WechatBaseResponse
{
    [JsonPropertyName("list")] public List<ArticleTotalItem>? List { get; set; }
}

