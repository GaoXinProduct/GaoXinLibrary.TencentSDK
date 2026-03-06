using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 删除部门事件（ChangeType = delete_party）
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90971"/></para>
/// </summary>
public class CallbackDeletePartyEvent : CallbackChangeContactEvent
{
    /// <summary>部门 ID</summary>
    public int Id { get; set; }
}

