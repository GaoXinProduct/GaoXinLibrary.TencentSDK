using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>获取客户群列表请求</summary>
public class GetGroupChatListRequest
{
    /// <summary>群状态筛选，0-所有，1-正常，2-跟进中，3-待开发</summary>
    [JsonPropertyName("status_filter")]
    public int StatusFilter { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;
}
