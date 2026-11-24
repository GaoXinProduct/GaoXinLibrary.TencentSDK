namespace GaoXinLibrary.TencentSDK.Wecom.Models.AccountId;

/// <summary>请求将智能机器人获取的密文成员 ID 转为企业内的成员 ID。</summary>
public sealed class ConvertRobotOpenUserIdsRequest
{
    /// <summary>企业主体下的密文成员 ID 列表，最多 1000 个。</summary>
    [JsonPropertyName("open_userid_list")] public string[] OpenUserIds { get; set; } = [];
}
