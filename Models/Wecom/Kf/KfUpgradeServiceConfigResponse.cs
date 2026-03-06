using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>获取配置的专员与客户群响应</summary>
public class KfUpgradeServiceConfigResponse : WecomBaseResponse
{
    /// <summary>专员服务配置</summary>
    [JsonPropertyName("member_range")] public KfUpgradeMemberRange? MemberRange { get; set; }

    /// <summary>客户群配置</summary>
    [JsonPropertyName("groupchat_range")] public KfUpgradeGroupChatRange? GroupChatRange { get; set; }
}

