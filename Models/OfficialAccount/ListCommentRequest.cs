using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>查看指定文章的评论数据请求（POST /cgi-bin/comment/list）</summary>
public class ListCommentRequest
{
    [JsonPropertyName("msg_data_id")] public required long MsgDataId { get; set; }
    [JsonPropertyName("index")] public int Index { get; set; }
    /// <summary>起始位置</summary>
    [JsonPropertyName("begin")] public int Begin { get; set; }
    /// <summary>获取数目（>=50 会被拒绝）</summary>
    [JsonPropertyName("count")] public int Count { get; set; } = 20;
    /// <summary>type=0 普通评论&精选评论 type=1 普通评论 type=2 精选评论</summary>
    [JsonPropertyName("type")] public int Type { get; set; }
}

