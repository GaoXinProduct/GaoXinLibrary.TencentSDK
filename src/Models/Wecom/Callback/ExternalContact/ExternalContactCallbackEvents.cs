namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback.ExternalContact;

/// <summary>
/// 外部联系人变更事件基类
/// </summary>
public abstract class ExternalContactCallbackEventBase : CallbackEventBase { }

/// <summary>
/// 添加外部联系人事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/92130"/></para>
/// </summary>
public class AddExternalContactEvent : ExternalContactCallbackEventBase
{
    /// <summary>变更类型</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>企业成员 UserID</summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>外部联系人 UserID</summary>
    public string ExternalUserId { get; set; } = string.Empty;

    /// <summary>下次跟进时间</summary>
    public long NextRemindTime { get; set; }

    /// <summary>跟进小结</summary>
    public string? Remark { get; set; }
}

/// <summary>
/// 删除外部联系人事件
/// </summary>
public class DelExternalContactEvent : ExternalContactCallbackEventBase
{
    /// <summary>变更类型</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>企业成员 UserID</summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>外部联系人 UserID</summary>
    public string ExternalUserId { get; set; } = string.Empty;
}

/// <summary>
/// 外部联系人标签变更事件
/// </summary>
public class ExternalContactTagChangeEvent : ExternalContactCallbackEventBase
{
    /// <summary>变更类型</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>企业成员 UserID</summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>外部联系人 UserID</summary>
    public string ExternalUserId { get; set; } = string.Empty;

    /// <summary>添加的标签</summary>
    public string? AddTag { get; set; }

    /// <summary>删除的标签</summary>
    public string? DelTag { get; set; }
}