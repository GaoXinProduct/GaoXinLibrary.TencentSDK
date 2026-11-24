namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback.ExternalContact;

/// <summary>客户群创建、变更或解散事件</summary>
public sealed class ExternalChatChangeEvent : CallbackEventBase
{
    /// <summary>客户群 ID</summary>
    public string ChatId { get; set; } = string.Empty;

    /// <summary>变更类型（create / update / dismiss）</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>群成员、群主、群名或群公告的变更类型</summary>
    public string? UpdateDetail { get; set; }

    /// <summary>入群场景，仅在成员入群时返回</summary>
    public int? JoinScene { get; set; }

    /// <summary>退群场景，仅在成员退群时返回</summary>
    public int? QuitScene { get; set; }

    /// <summary>入群或退群的成员数量</summary>
    public int? MemberChangeCount { get; set; }

    /// <summary>入群或退群的成员 ID</summary>
    public string[]? MemberChangeList { get; set; }

    /// <summary>变更前的群成员版本</summary>
    public string? LastMemberVersion { get; set; }

    /// <summary>变更后的群成员版本</summary>
    public string? CurrentMemberVersion { get; set; }
}
