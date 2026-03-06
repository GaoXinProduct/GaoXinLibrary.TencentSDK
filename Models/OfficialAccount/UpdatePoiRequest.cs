using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>修改门店服务信息请求（POST /cgi-bin/poi/updatepoi）</summary>
public class UpdatePoiRequest
{
    [JsonPropertyName("business")] public required PoiBusiness Business { get; set; }
}

