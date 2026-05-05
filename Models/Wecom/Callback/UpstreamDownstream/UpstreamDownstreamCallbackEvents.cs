namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback.UpstreamDownstream;

/// <summary>
/// 上下游变更回调事件
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/95796"/></para>
/// </summary>
public class UpstreamDownstreamChangeEvent : CallbackEventBase
{
    /// <summary>变更类型</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>上下游 ID</summary>
    public string ChainId { get; set; } = string.Empty;

    /// <summary>企业 ID</summary>
    public string CorpId { get; set; } = string.Empty;
}

/// <summary>
/// 异步任务完成通知（上下游）
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/95797"/></para>
/// </summary>
public class UpstreamAsyncTaskCompleteEvent : CallbackEventBase
{
    /// <summary>任务类型</summary>
    public string JobType { get; set; } = string.Empty;

    /// <summary>错误码</summary>
    public int ErrCode { get; set; }

    /// <summary>错误信息</summary>
    public string? ErrMsg { get; set; }

    /// <summary>任务 ID</summary>
    public string? JobId { get; set; }

    /// <summary>结果 URL</summary>
    public string? ResultUrl { get; set; }
}