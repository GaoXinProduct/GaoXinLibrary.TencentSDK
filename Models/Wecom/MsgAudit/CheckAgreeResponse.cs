using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>获取会话同意情况响应</summary>
public class CheckAgreeResponse : WecomBaseResponse
{
    /// <summary>同意情况列表</summary>
    [JsonPropertyName("agreeinfo")] public AgreeInfo[]? AgreeInfoList { get; set; }
}

