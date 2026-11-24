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

    /// <summary>添加客户所用「联系我」方式设置的渠道标识</summary>
    public string? State { get; set; }

    /// <summary>用于发送新客户欢迎语的凭证</summary>
    public string? WelcomeCode { get; set; }

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

    /// <summary>删除来源，例如在职继承触发的 DELETE_BY_TRANSFER</summary>
    public string? Source { get; set; }
}

/// <summary>客户信息变更、客户删除跟进成员或接替失败等事件</summary>
public sealed class ExternalContactChangeEvent : ExternalContactCallbackEventBase
{
    /// <summary>变更类型</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>企业成员 UserID</summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>外部联系人 UserID</summary>
    public string ExternalUserId { get; set; } = string.Empty;

    /// <summary>客户接替失败原因，仅在接替失败时返回</summary>
    public string? FailReason { get; set; }
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
