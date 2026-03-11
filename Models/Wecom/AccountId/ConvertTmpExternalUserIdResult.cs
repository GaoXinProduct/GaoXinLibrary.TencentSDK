using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AccountId;

/// <summary>tmp_external_userid转换结果项</summary>
public class ConvertTmpExternalUserIdResult
{
    /// <summary>原始tmp_external_userid</summary>
    [JsonPropertyName("tmp_external_userid")] public string? TmpExternalUserId { get; set; }

    /// <summary>转换后的external_userid</summary>
    [JsonPropertyName("external_userid")] public string? ExternalUserId { get; set; }
}
