using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

// ─── 成员变更通知 ──────────────────────────────────────────────────────

/// <summary>
/// 新建成员事件（ChangeType = create_user）
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90970"/></para>
/// </summary>
public class CallbackCreateUserEvent : CallbackChangeContactEvent
{
    /// <summary>成员 UserID</summary>
    public string UserID { get; set; } = string.Empty;

    /// <summary>成员名称</summary>
    public string? Name { get; set; }

    /// <summary>成员所属部门 ID 列表（逗号分隔）</summary>
    public string? Department { get; set; }

    /// <summary>主部门</summary>
    public int MainDepartment { get; set; }

    /// <summary>表示在所在的部门内是否为部门负责人（逗号分隔，0-否 1-是）</summary>
    public string? IsLeaderInDept { get; set; }

    /// <summary>直属上级 UserID 列表（逗号分隔）</summary>
    public string? DirectLeader { get; set; }

    /// <summary>职务信息</summary>
    public string? Position { get; set; }

    /// <summary>手机号码</summary>
    public string? Mobile { get; set; }

    /// <summary>性别（1-男 2-女 0-未定义）</summary>
    public int Gender { get; set; }

    /// <summary>邮箱</summary>
    public string? Email { get; set; }

    /// <summary>企业邮箱</summary>
    public string? BizMail { get; set; }

    /// <summary>激活状态（1-已激活 2-已禁用 4-未激活 5-退出企业）</summary>
    public int Status { get; set; }

    /// <summary>头像 URL</summary>
    public string? Avatar { get; set; }

    /// <summary>成员别名</summary>
    public string? Alias { get; set; }

    /// <summary>座机</summary>
    public string? Telephone { get; set; }

    /// <summary>地址</summary>
    public string? Address { get; set; }

    /// <summary>扩展属性</summary>
    public CallbackExtAttrItem[]? ExtAttr { get; set; }
}

