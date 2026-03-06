using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

// ─── 工作台自定义展示 ─────────────────────────────────────────────────────

/// <summary>设置工作台自定义展示请求</summary>
public class SetWorkbenchTemplateRequest
{
    /// <summary>应用 agentid</summary>
    [JsonPropertyName("agentid")] public int AgentId { get; set; }

    /// <summary>
    /// 展示类型：
    /// image=图片 / list=列表 / webview=网页 / keydata=关键数据型 /
    /// button=功能按钮型
    /// </summary>
    [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;

    /// <summary>图片型展示配置（type=image 时使用）</summary>
    [JsonPropertyName("image")] public WorkbenchImageConfig? Image { get; set; }

    /// <summary>列表型展示配置（type=list 时使用）</summary>
    [JsonPropertyName("list")] public WorkbenchListConfig? List { get; set; }

    /// <summary>关键数据型展示配置（type=keydata 时使用）</summary>
    [JsonPropertyName("keydata")] public WorkbenchKeyDataConfig? KeyData { get; set; }

    /// <summary>功能按钮型展示配置（type=button 时使用）</summary>
    [JsonPropertyName("button")] public WorkbenchButtonConfig? Button { get; set; }

    /// <summary>网页型展示配置（type=webview 时使用）</summary>
    [JsonPropertyName("webview")] public WorkbenchWebviewConfig? Webview { get; set; }

    /// <summary>是否替换默认展示内容（0=不替换, 1=替换），默认0</summary>
    [JsonPropertyName("replace_user_data")] public int ReplaceUserData { get; set; }
}

