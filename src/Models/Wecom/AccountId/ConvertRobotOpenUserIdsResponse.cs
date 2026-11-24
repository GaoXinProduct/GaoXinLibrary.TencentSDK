using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AccountId;

/// <summary>智能机器人密文成员 ID 的批量转换结果。</summary>
public sealed class ConvertRobotOpenUserIdsResponse : WecomBaseResponse
{
    /// <summary>转换成功的成员 ID 对应关系。</summary>
    [JsonPropertyName("userid_list")] public ConvertedRobotUserId[]? UserIds { get; set; }

    /// <summary>无效、不可见或已经为明文的输入 ID。</summary>
    [JsonPropertyName("invalid_open_userid_list")] public string[]? InvalidOpenUserIds { get; set; }
}

/// <summary>一个转换成功的成员 ID。</summary>
public sealed class ConvertedRobotUserId
{
    /// <summary>智能机器人获取的密文 ID。</summary>
    [JsonPropertyName("open_userid")] public string? OpenUserId { get; set; }

    /// <summary>企业内的明文成员 ID。</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }
}
