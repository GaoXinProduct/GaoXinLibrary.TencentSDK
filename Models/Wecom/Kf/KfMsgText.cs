using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>文本消息内容</summary>
public class KfMsgText
{
    /// <summary>文本内容</summary>
    [JsonPropertyName("content")] public string? Content { get; set; }

    /// <summary>菜单 id</summary>
    [JsonPropertyName("menu_id")] public string? MenuId { get; set; }
}

