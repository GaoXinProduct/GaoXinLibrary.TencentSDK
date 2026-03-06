using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查看评论数据响应</summary>
public class ListCommentResponse : WechatBaseResponse
{
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("comment")] public List<CommentItem>? Comment { get; set; }
}

