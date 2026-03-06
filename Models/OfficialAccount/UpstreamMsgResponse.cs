using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取消息发送概况数据响应（POST /datacube/getupstreammsg）</summary>
public class UpstreamMsgResponse : WechatBaseResponse
{
    [JsonPropertyName("list")] public List<UpstreamMsgItem>? List { get; set; }
}

