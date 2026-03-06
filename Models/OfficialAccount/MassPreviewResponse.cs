using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>预览群发消息响应</summary>
public class MassPreviewResponse : WechatBaseResponse
{
    [JsonPropertyName("msg_id")] public long MsgId { get; set; }
}

