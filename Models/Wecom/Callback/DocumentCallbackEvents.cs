namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 文档事件基类
/// </summary>
public abstract class DocumentCallbackEventBase : CallbackEventBase { }

/// <summary>
/// 文档变更事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97316"/></para>
/// </summary>
public class DocumentChangeEvent : DocumentCallbackEventBase
{
    /// <summary>变更类型</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>文档 ID</summary>
    public string DocId { get; set; } = string.Empty;

    /// <summary>文档标题</summary>
    public string? Title { get; set; }

    /// <summary>创建者 userid</summary>
    public string? Creator { get; set; }
}