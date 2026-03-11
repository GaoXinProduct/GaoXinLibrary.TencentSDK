using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>批量获取客户详情响应</summary>
public class BatchGetExternalContactResponse : WecomBaseResponse
{
    /// <summary>客户详情列表</summary>
    [JsonPropertyName("external_contact_list")] public ExternalContactDetail[]? ExternalContactList { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }
}
