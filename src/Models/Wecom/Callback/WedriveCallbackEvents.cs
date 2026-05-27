namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 微盘事件基类
/// </summary>
public abstract class WedriveCallbackEventBase : CallbackEventBase { }

/// <summary>
/// 微盘文件变更事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/97482"/></para>
/// </summary>
public class WedriveFileChangeEvent : WedriveCallbackEventBase
{
    /// <summary>变更类型</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>文件 ID</summary>
    public string FileId { get; set; } = string.Empty;

    /// <summary>空间 ID</summary>
    public string SpaceId { get; set; } = string.Empty;

    /// <summary>文件名</summary>
    public string? FileName { get; set; }
}