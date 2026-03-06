using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 网络通信检测请求（POST /cgi-bin/callback/check）
/// </summary>
public class CallbackCheckRequest
{
    /// <summary>检测动作：dns / ping / all</summary>
    [JsonPropertyName("action")] public string Action { get; set; } = "all";
    /// <summary>运营商：DEFAULT / CHINANET / UNICOM / CAP</summary>
    [JsonPropertyName("check_operator")] public string CheckOperator { get; set; } = "DEFAULT";
}
