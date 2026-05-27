using GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document.Callback;

/// <summary>
/// 文档变更事件
/// </summary>
public class DocChangedEvent : CallbackEventBase
{
    /// <summary>变更类型</summary>
    public string ChangeType { get; init; } = string.Empty;

    /// <summary>文档 ID</summary>
    public string DocId { get; init; } = string.Empty;

    /// <summary>文档标题</summary>
    public string? Title { get; init; }

    /// <summary>创建者 userid</summary>
    public string? Creator { get; init; }
}

/// <summary>
/// 文档成员变更事件
/// </summary>
public class ModifyMemberEvent : CallbackEventBase
{
    /// <summary>文档 ID</summary>
    public string DocId { get; init; } = string.Empty;

    /// <summary>变更类型（add_member / del_member / change_permission）</summary>
    public string ChangeType { get; init; } = string.Empty;

    /// <summary>被变更成员的 userid</summary>
    public string MemberUserId { get; init; } = string.Empty;

    /// <summary>权限类型（1-可编辑，2-可查看）</summary>
    public int Permission { get; init; }
}

/// <summary>
/// 删除文档事件
/// </summary>
public class DeleteDocEvent : CallbackEventBase
{
    /// <summary>文档 ID</summary>
    public string DocId { get; init; } = string.Empty;

    /// <summary>操作者 userid</summary>
    public string Operator { get; init; } = string.Empty;
}

/// <summary>
/// 收集表完成事件
/// </summary>
public class CollectFormCompleteEvent : CallbackEventBase
{
    /// <summary>收集表 ID</summary>
    public string FormId { get; init; } = string.Empty;

    /// <summary>收集表标题</summary>
    public string? Title { get; init; }

    /// <summary>提交者 userid</summary>
    public string? SubmitUser { get; init; }
}

/// <summary>
/// 删除收集表事件
/// </summary>
public class DeleteCollectFormEvent : CallbackEventBase
{
    /// <summary>收集表 ID</summary>
    public string FormId { get; init; } = string.Empty;

    /// <summary>操作者 userid</summary>
    public string Operator { get; init; } = string.Empty;
}

/// <summary>
/// 修改收集表设置事件
/// </summary>
public class ModifyCollectFormSettingEvent : CallbackEventBase
{
    /// <summary>收集表 ID</summary>
    public string FormId { get; init; } = string.Empty;

    /// <summary>变更类型</summary>
    public string ChangeType { get; init; } = string.Empty;
}

/// <summary>
/// 智能表格字段变更事件
/// </summary>
public class FieldChangeEvent : CallbackEventBase
{
    /// <summary>文档 ID</summary>
    public string DocId { get; init; } = string.Empty;

    /// <summary>子表 ID</summary>
    public string SheetId { get; init; } = string.Empty;

    /// <summary>变更类型（add_field / del_field / update_field）</summary>
    public string ChangeType { get; init; } = string.Empty;

    /// <summary>字段 ID</summary>
    public string FieldId { get; init; } = string.Empty;

    /// <summary>字段标题</summary>
    public string? FieldTitle { get; init; }
}

/// <summary>
/// 智能表格记录变更事件
/// </summary>
public class RecordChangeEvent : CallbackEventBase
{
    /// <summary>文档 ID</summary>
    public string DocId { get; init; } = string.Empty;

    /// <summary>子表 ID</summary>
    public string SheetId { get; init; } = string.Empty;

    /// <summary>变更类型（add_record / del_record / update_record）</summary>
    public string ChangeType { get; init; } = string.Empty;

    /// <summary>记录 ID</summary>
    public string RecordId { get; init; } = string.Empty;
}
