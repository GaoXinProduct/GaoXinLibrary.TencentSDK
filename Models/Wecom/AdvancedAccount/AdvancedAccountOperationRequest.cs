using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AdvancedAccount;

/// <summary>分配/取消高级功能账号请求</summary>
public class AdvancedAccountOperationRequest
{
    /// <summary>用户 userid</summary>
    [JsonPropertyName("userid")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>账号类型</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }
}
