using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>JS-SDK 签名结果</summary>
public class JsSdkSignature
{
    /// <summary>AppId</summary>
    public required string AppId { get; set; }

    /// <summary>时间戳</summary>
    public required string Timestamp { get; set; }

    /// <summary>随机字符串</summary>
    public required string NonceStr { get; set; }

    /// <summary>签名</summary>
    public required string Signature { get; set; }
}

