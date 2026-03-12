using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 转换 OpenId 响应
/// </summary>
public class ChangeOpenIdResponse : WechatBaseResponse
{
    /// <summary>转换结果列表</summary>
    [JsonPropertyName("result_list")] public List<ChangeOpenIdResultItem>? ResultList { get; set; }
}
