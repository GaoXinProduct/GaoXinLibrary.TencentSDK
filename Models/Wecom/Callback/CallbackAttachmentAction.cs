namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 附件消息中的操作项
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/100719"/></para>
/// </summary>
public class CallbackAttachmentAction
{
    /// <summary>操作名称</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>操作值</summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>操作类型</summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>操作 Key</summary>
    public string Key { get; set; } = string.Empty;
}
