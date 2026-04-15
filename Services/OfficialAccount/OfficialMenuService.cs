using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号菜单服务实现</summary>
public class OfficialMenuService
{
    private readonly WechatHttpClient _http;

    public OfficialMenuService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <summary>
    /// 创建自定义菜单
    /// </summary>
    /// <param name="request">菜单创建请求</param>
    /// <param name="ct">取消令牌</param>
    public Task<CreateMenuResponse> CreateAsync(CreateMenuRequest request, CancellationToken ct = default)
        => _http.PostAsync<CreateMenuResponse>("/cgi-bin/menu/create", request, ct);

    /// <summary>
    /// 查询自定义菜单
    /// </summary>
    /// <param name="ct">取消令牌</param>
    public Task<GetMenuResponse> GetAsync(CancellationToken ct = default)
        => _http.GetAsync<GetMenuResponse>("/cgi-bin/menu/get", ct: ct);

    /// <summary>
    /// 删除自定义菜单
    /// </summary>
    /// <param name="ct">取消令牌</param>
    public Task<DeleteMenuResponse> DeleteAsync(CancellationToken ct = default)
        => _http.GetAsync<DeleteMenuResponse>("/cgi-bin/menu/delete", ct: ct);
}
