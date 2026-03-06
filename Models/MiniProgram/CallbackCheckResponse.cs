using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>网络通信检测响应</summary>
public class CallbackCheckResponse : WechatBaseResponse
{
    /// <summary>dns 检测结果列表</summary>
    [JsonPropertyName("dns")] public List<CallbackCheckItem>? Dns { get; set; }
    /// <summary>ping 检测结果列表</summary>
    [JsonPropertyName("ping")] public List<CallbackCheckItem>? Ping { get; set; }
}

/// <summary>网络检测单项结果</summary>
public class CallbackCheckItem
{
    [JsonPropertyName("ip")]            public string? Ip { get; set; }
    [JsonPropertyName("real_operator")] public string? RealOperator { get; set; }
    [JsonPropertyName("from")]          public string? From { get; set; }
    [JsonPropertyName("time")]          public string? Time { get; set; }
    [JsonPropertyName("ttl")]           public string? Ttl { get; set; }
    [JsonPropertyName("errCode")]       public int ErrCode { get; set; }
    [JsonPropertyName("errMsg")]        public string? ErrMsg { get; set; }
}
