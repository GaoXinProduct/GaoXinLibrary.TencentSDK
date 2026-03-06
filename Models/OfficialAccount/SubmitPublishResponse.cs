using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>发布草稿响应</summary>
public class SubmitPublishResponse : WechatBaseResponse
{
    /// <summary>发布任务的 id</summary>
    [JsonPropertyName("publish_id")] public string? PublishId { get; set; }
}

