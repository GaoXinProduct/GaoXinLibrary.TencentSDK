using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取客服列表响应（GET /cgi-bin/customservice/getkflist）</summary>
public class GetKfListResponse : WechatBaseResponse
{
    [JsonPropertyName("kf_list")] public List<KfAccountInfo>? KfList { get; set; }
}

