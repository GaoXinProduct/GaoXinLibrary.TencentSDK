using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>异步任务完成事件</summary>
public class CallbackBatchJobEvent : CallbackEventBase
{
    /// <summary>异步任务 ID（最大长度64字符）</summary>
    public string JobId { get; set; } = string.Empty;

    /// <summary>操作类型：sync_user / replace_user / invite_user / replace_party</summary>
    public string JobType { get; set; } = string.Empty;

    /// <summary>返回码</summary>
    public int ErrCode { get; set; }

    /// <summary>错误信息</summary>
    public string? ErrMsg { get; set; }
}

