using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 查询评价列表请求（POST /wxa/comment/get_comment_list）
/// </summary>
public sealed class GetCommentListRequest
{
    /// <summary>评价类型（0全部 1差评 2中评 3好评）</summary>
    [JsonPropertyName("star")] public int Star { get; set; } = 0;
    /// <summary>分页大小</summary>
    [JsonPropertyName("limit")] public int Limit { get; set; } = 10;
    /// <summary>分页起始位置</summary>
    [JsonPropertyName("offset")] public int Offset { get; set; } = 0;
}
