using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号菜单服务实现</summary>
public class OfficialMenuService : IOfficialMenuService
{
    private readonly WechatHttpClient _http;

    public OfficialMenuService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <inheritdoc/>
    public Task<CreateMenuResponse> CreateAsync(CreateMenuRequest request, CancellationToken ct = default)
        => _http.PostAsync<CreateMenuResponse>("/cgi-bin/menu/create", request, ct);

    /// <inheritdoc/>
    public Task<GetMenuResponse> GetAsync(CancellationToken ct = default)
        => _http.GetAsync<GetMenuResponse>("/cgi-bin/menu/get", ct: ct);

    /// <inheritdoc/>
    public Task<DeleteMenuResponse> DeleteAsync(CancellationToken ct = default)
        => _http.GetAsync<DeleteMenuResponse>("/cgi-bin/menu/delete", ct: ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号模板消息服务

