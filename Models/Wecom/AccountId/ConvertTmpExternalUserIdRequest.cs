using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AccountId;

/// <summary>转换临时外部联系人 ID 请求</summary>
public class ConvertTmpExternalUserIdRequest
{
    /// <summary>临时外部联系人 userid 列表</summary>
    [JsonPropertyName("tmp_external_userid_list")]
    public string[] TmpExternalUserIdList { get; set; } = [];

    /// <summary>业务类型，1-客户联系</summary>
    [JsonPropertyName("business_type")]
    public int BusinessType { get; set; } = 1;
}
