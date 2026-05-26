using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>客户群范围</summary>
public sealed class KfUpgradeGroupChatRange
{
    /// <summary>客户群 chatid 列表</summary>
    [JsonPropertyName("chatid_list")] public string[]? ChatIdList { get; set; }
}

