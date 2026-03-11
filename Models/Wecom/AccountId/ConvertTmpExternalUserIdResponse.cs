using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AccountId;

/// <summary>tmp_external_userid转换响应</summary>
public class ConvertTmpExternalUserIdResponse : WecomBaseResponse
{
    /// <summary>转换后的external_userid列表</summary>
    [JsonPropertyName("results")] public ConvertTmpExternalUserIdResult[]? Results { get; set; }

    /// <summary>无效的tmp_external_userid列表</summary>
    [JsonPropertyName("invalid_tmp_external_userid_list")] public string[]? InvalidList { get; set; }
}
