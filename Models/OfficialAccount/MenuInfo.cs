using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>菜单信息</summary>
public sealed class MenuInfo
{
    [JsonPropertyName("button")] public List<MenuButton>? Button { get; set; }
}

