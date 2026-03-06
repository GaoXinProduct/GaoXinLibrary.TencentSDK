using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>数据水印</summary>
public class Watermark
{
    /// <summary>用户获取手机号操作的时间戳</summary>
    [JsonPropertyName("timestamp")] public long Timestamp { get; set; }

    /// <summary>小程序 AppId</summary>
    [JsonPropertyName("appid")] public string? AppId { get; set; }
}

