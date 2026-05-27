namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback.AddressBook;

/// <summary>
/// 通讯录回调事件基类
/// </summary>
public abstract class AddressBookCallbackEventBase : CallbackEventBase { }

/// <summary>
/// 成员变更通知
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90970"/></para>
/// </summary>
public class MemberChangeEvent : AddressBookCallbackEventBase
{
    /// <summary>变更类型（create/update/delete）</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>成员 UserID</summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>成员名称</summary>
    public string? Name { get; set; }

    /// <summary>成员所属部门 ID 列表</summary>
    public string? Department { get; set; }

    /// <summary>主部门</summary>
    public int MainDepartment { get; set; }

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

    /// <summary>激活状态</summary>
    public int Status { get; set; }

    /// <summary>头像 URL</summary>
    public string? Avatar { get; set; }

    /// <summary>成员别名</summary>
    public string? Alias { get; set; }

    /// <summary>座机</summary>
    public string? Telephone { get; set; }

    /// <summary>地址</summary>
    public string? Address { get; set; }

    /// <summary>是否部门负责人</summary>
    public string? IsLeaderInDept { get; set; }

    /// <summary>直属上级</summary>
    public string? DirectLeader { get; set; }

    /// <summary>扩展属性</summary>
    public CallbackExtAttrItem[]? ExtAttr { get; set; }
}

/// <summary>
/// 部门变更通知
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90971"/></para>
/// </summary>
public class DepartmentChangeEvent : AddressBookCallbackEventBase
{
    /// <summary>变更类型（create/update/delete）</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>部门 ID</summary>
    public int Id { get; set; }

    /// <summary>部门名称</summary>
    public string? Name { get; set; }

    /// <summary>父部门 ID</summary>
    public int ParentId { get; set; }

    /// <summary>部门排序</summary>
    public int Order { get; set; }
}

/// <summary>
/// 标签变更通知
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90972"/></para>
/// </summary>
public class TagChangeEvent : AddressBookCallbackEventBase
{
    /// <summary>变更类型</summary>
    public string ChangeType { get; set; } = string.Empty;

    /// <summary>标签 ID</summary>
    public int TagId { get; set; }

    /// <summary>标签名称</summary>
    public string? TagName { get; set; }

    /// <summary>新增的成员 userid 列表</summary>
    public string? AddUserItems { get; set; }

    /// <summary>删除的成员 userid 列表</summary>
    public string? DelUserItems { get; set; }

    /// <summary>新增的部门 id 列表</summary>
    public string? AddPartyItems { get; set; }

    /// <summary>删除的部门 id 列表</summary>
    public string? DelPartyItems { get; set; }
}

/// <summary>
/// 异步任务完成通知
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90973"/></para>
/// </summary>
public class AsyncTaskCompleteEvent : AddressBookCallbackEventBase
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