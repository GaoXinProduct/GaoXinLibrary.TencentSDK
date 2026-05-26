using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>订阅消息模板数据值</summary>
public sealed class SubscribeMessageDataValue
{
    /// <summary>模板数据值</summary>
    [JsonPropertyName("value")] public required string Value { get; set; }
}

