using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 通讯录变更事件基类
/// <para>Event = change_contact，通过 <see cref="ChangeType"/> 区分具体变更类型</para>
/// </summary>
public class CallbackChangeContactEvent : CallbackEventBase
{
    /// <summary>变更类型（create_user / update_user / delete_user / create_party / update_party / delete_party / update_tag）</summary>
    public string ChangeType { get; set; } = string.Empty;
}

