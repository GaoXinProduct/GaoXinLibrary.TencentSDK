using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>外部联系人信息</summary>
public class ExternalContactInfo
{
    /// <summary>外部联系人的userid</summary>
    [JsonPropertyName("external_userid")] public string? ExternalUserId { get; set; }

    /// <summary>外部联系人的名称</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>外部联系人头像</summary>
    [JsonPropertyName("avatar")] public string? Avatar { get; set; }

    /// <summary>外部联系人的类型，1-微信用户，2-企业微信用户</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>外部联系人性别，0-未知，1-男性，2-女性</summary>
    [JsonPropertyName("gender")] public int Gender { get; set; }

    /// <summary>外部联系人在微信开放平台的唯一身份标识</summary>
    [JsonPropertyName("unionid")] public string? UnionId { get; set; }

    /// <summary>外部联系人的职位</summary>
    [JsonPropertyName("position")] public string? Position { get; set; }

    /// <summary>外部联系人所在企业的简称</summary>
    [JsonPropertyName("corp_name")] public string? CorpName { get; set; }

    /// <summary>外部联系人所在企业的主体名称</summary>
    [JsonPropertyName("corp_full_name")] public string? CorpFullName { get; set; }
}
