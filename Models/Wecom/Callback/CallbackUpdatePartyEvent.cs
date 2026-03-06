using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 更新部门事件（ChangeType = update_party）
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/90971"/></para>
/// </summary>
public class CallbackUpdatePartyEvent : CallbackCreatePartyEvent { }

