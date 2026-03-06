using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

// ─── 标签变更通知 ──────────────────────────────────────────────────────

/// <summary>
/// 标签成员变更事件（ChangeType = update_tag）
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90972"/></para>
/// </summary>
public class CallbackUpdateTagEvent : CallbackChangeContactEvent
{
    /// <summary>标签 ID</summary>
    public int TagId { get; set; }

    /// <summary>标签中新增的成员 UserID 列表（逗号分隔）</summary>
    public string? AddUserItems { get; set; }

    /// <summary>标签中删除的成员 UserID 列表（逗号分隔）</summary>
    public string? DelUserItems { get; set; }

    /// <summary>标签中新增的部门 ID 列表（逗号分隔）</summary>
    public string? AddPartyItems { get; set; }

    /// <summary>标签中删除的部门 ID 列表（逗号分隔）</summary>
    public string? DelPartyItems { get; set; }
}

