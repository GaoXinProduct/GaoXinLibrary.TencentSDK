using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 更新成员事件（ChangeType = update_user）
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90970"/></para>
/// </summary>
public sealed class CallbackUpdateUserEvent : CallbackCreateUserEvent
{
    /// <summary>新的 UserID（仅在 UserID 变更时有值）</summary>
    public string? NewUserID { get; set; }
}

