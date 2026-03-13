using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>批量获取客户详情请求</summary>
public class BatchGetByUserRequest
{
    /// <summary>企业成员 userid 列表</summary>
    [JsonPropertyName("userid_list")]
    public string[] UserIdList { get; set; } = [];

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;
}
