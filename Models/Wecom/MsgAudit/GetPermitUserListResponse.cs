using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.MsgAudit;

/// <summary>获取会话内容存档开启成员列表响应</summary>
public class GetPermitUserListResponse : WecomBaseResponse
{
    /// <summary>设置了会话内容存档的成员列表</summary>
    [JsonPropertyName("ids")] public string[]? Ids { get; set; }
}

