using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

#region 响应模型

/// <summary>获取菜单响应</summary>
public class GetMenuResponse : WecomBaseResponse
{
    /// <summary>菜单按钮列表</summary>
    [JsonPropertyName("button")] public MenuButton[]? Button { get; set; }
}

#endregion
