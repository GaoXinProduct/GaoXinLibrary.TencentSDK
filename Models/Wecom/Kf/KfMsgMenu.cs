using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

/// <summary>菜单消息内容</summary>
public class KfMsgMenu
{
    /// <summary>菜单头部内容</summary>
    [JsonPropertyName("head_content")] public string? HeadContent { get; set; }

    /// <summary>菜单项列表</summary>
    [JsonPropertyName("list")] public KfMsgMenuItem[]? List { get; set; }

    /// <summary>菜单尾部内容</summary>
    [JsonPropertyName("tail_content")] public string? TailContent { get; set; }
}

