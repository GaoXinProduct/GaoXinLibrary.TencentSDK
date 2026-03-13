using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AdvancedAccount;

/// <summary>获取高级功能账号列表请求</summary>
public class GetAdvancedAccountListRequest
{
    /// <summary>账号类型</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 1000;
}
