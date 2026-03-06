using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>获取接口分析数据响应（POST /datacube/getinterfacesummary）</summary>
public class InterfaceSummaryResponse : WechatBaseResponse
{
    [JsonPropertyName("list")] public List<InterfaceSummaryItem>? List { get; set; }
}

