using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.LinkedCorp;

/// <summary>互联企业成员简要信息</summary>
public class LinkedCorpSimpleUser
{
    /// <summary>成员 UserId</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;

    /// <summary>成员姓名</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>成员所属部门 id 列表</summary>
    [JsonPropertyName("department")] public string[]? Department { get; set; }

    /// <summary>所属企业的 CorpId</summary>
    [JsonPropertyName("corpid")] public string? CorpId { get; set; }
}

