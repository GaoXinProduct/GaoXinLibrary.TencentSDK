using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取已设置二维码规则响应
/// </summary>
public class QrcodeJumpGetResponse : WechatBaseResponse
{
    /// <summary>规则详情列表</summary>
    [JsonPropertyName("rule_list")] public List<QrcodeJumpRuleItem>? RuleList { get; set; }

    /// <summary>是否已开启二维码跳转链接设置</summary>
    [JsonPropertyName("qrcodejump_open")] public int? QrcodeJumpOpen { get; set; }

    /// <summary>当前规则数量</summary>
    [JsonPropertyName("list_size")] public int? ListSize { get; set; }

    /// <summary>当月还可发布次数</summary>
    [JsonPropertyName("qrcodejump_pub_quota")] public int? QrcodeJumpPubQuota { get; set; }

    /// <summary>规则总数（分页时有意义）</summary>
    [JsonPropertyName("total_count")] public int? TotalCount { get; set; }
}
