using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>获取群聊会话同意情况响应</summary>
public class CheckRoomAgreeResponse : WecomBaseResponse
{
    /// <summary>同意情况列表</summary>
    [JsonPropertyName("agreeinfo")] public AgreeInfo[]? AgreeInfoList { get; set; }
}

