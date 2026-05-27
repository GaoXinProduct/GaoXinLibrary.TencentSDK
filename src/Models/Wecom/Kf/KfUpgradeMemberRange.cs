using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>专员服务范围</summary>
public sealed class KfUpgradeMemberRange
{
    /// <summary>专员 userid 列表</summary>
    [JsonPropertyName("userid_list")] public string[]? UserIdList { get; set; }
}

