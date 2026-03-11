using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>跟进人信息</summary>
public class FollowUser
{
    /// <summary>添加了此外部联系人的企业成员userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>该成员对此外部联系人的备注</summary>
    [JsonPropertyName("remark")] public string? Remark { get; set; }

    /// <summary>该成员对此外部联系人的描述</summary>
    [JsonPropertyName("description")] public string? Description { get; set; }

    /// <summary>该成员添加此外部联系人的时间</summary>
    [JsonPropertyName("createtime")] public long CreateTime { get; set; }

    /// <summary>该成员添加此外部联系人所打标签</summary>
    [JsonPropertyName("tags")] public FollowUserTag[]? Tags { get; set; }

    /// <summary>该成员对此客户备注的企业名称</summary>
    [JsonPropertyName("remark_corp_name")] public string? RemarkCorpName { get; set; }

    /// <summary>添加此客户的来源</summary>
    [JsonPropertyName("add_way")] public int AddWay { get; set; }

    /// <summary>企业自定义的state参数</summary>
    [JsonPropertyName("state")] public string? State { get; set; }
}
