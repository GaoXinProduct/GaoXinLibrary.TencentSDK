using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 删除成员事件（ChangeType = delete_user）
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90970"/></para>
/// </summary>
public class CallbackDeleteUserEvent : CallbackChangeContactEvent
{
    /// <summary>成员 UserID</summary>
    public string UserID { get; set; } = string.Empty;
}

