using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>
/// 获取已设置二维码规则请求
/// </summary>
public class QrcodeJumpGetRequest
{
    /// <summary>小程序 AppId（服务号场景）</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }

    /// <summary>查询类型：0 最近新增，1 前缀查询，2 分页查询</summary>
    [JsonPropertyName("get_type")] public int GetType { get; set; }

    /// <summary>前缀列表（get_type=1 时使用）</summary>
    [JsonPropertyName("prefix_list")] public List<string>? PrefixList { get; set; }

    /// <summary>页码（get_type=2 时使用）</summary>
    [JsonPropertyName("page_num")] public int? PageNum { get; set; }

    /// <summary>每页数量（get_type=2 时使用）</summary>
    [JsonPropertyName("page_size")] public int? PageSize { get; set; }
}
