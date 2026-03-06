using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>门店业务信息包装</summary>
public class PoiBusiness
{
    [JsonPropertyName("base_info")] public required PoiBaseInfo BaseInfo { get; set; }
}

