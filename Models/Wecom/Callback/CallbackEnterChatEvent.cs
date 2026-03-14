using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

/// <summary>
/// 进入智能机器人聊天事件
/// <para>当用户进入智能机器人的聊天窗口时推送此事件</para>
/// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101027"/></para>
/// </summary>
public class CallbackEnterChatEvent : CallbackEventBase { }
