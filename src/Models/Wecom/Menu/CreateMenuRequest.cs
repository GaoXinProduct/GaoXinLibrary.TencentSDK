using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

#region 请求模型

/// <summary>创建自定义菜单请求</summary>
public sealed class CreateMenuRequest
{
    /// <summary>一级菜单按钮列表，最多3个</summary>
    [JsonPropertyName("button")] public MenuButton[] Button { get; set; } = [];
}

#endregion
