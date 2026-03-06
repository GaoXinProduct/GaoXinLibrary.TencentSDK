using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.JsSdk;

/// <summary>应用级别 JS-SDK 签名结果</summary>
public class AgentJsSdkSignature
{
    /// <summary>企业 CorpId（即 appId）</summary>
    public string CorpId { get; set; } = string.Empty;

    /// <summary>应用 AgentId</summary>
    public int AgentId { get; set; }

    /// <summary>生成签名的时间戳（秒）</summary>
    public long Timestamp { get; set; }

    /// <summary>生成签名的随机字符串</summary>
    public string NonceStr { get; set; } = string.Empty;

    /// <summary>签名</summary>
    public string Signature { get; set; } = string.Empty;
}

