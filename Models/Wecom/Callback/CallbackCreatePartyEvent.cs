using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

// ─── 部门变更通知 ──────────────────────────────────────────────────────

/// <summary>
/// 新建部门事件（ChangeType = create_party）
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90971"/></para>
/// </summary>
public class CallbackCreatePartyEvent : CallbackChangeContactEvent
{
    /// <summary>部门 ID</summary>
    public int Id { get; set; }

    /// <summary>部门名称</summary>
    public string? Name { get; set; }

    /// <summary>父部门 ID</summary>
    public int ParentId { get; set; }

    /// <summary>部门排序</summary>
    public int Order { get; set; }
}

