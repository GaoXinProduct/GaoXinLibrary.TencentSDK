using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 公众号自定义菜单服务接口
/// </summary>
public interface IOfficialMenuService
{
    /// <summary>
    /// 创建自定义菜单
    /// </summary>
    /// <param name="request">菜单创建请求</param>
    /// <param name="ct">取消令牌</param>
    Task<CreateMenuResponse> CreateAsync(CreateMenuRequest request, CancellationToken ct = default);

    /// <summary>
    /// 查询自定义菜单
    /// </summary>
    /// <param name="ct">取消令牌</param>
    Task<GetMenuResponse> GetAsync(CancellationToken ct = default);

    /// <summary>
    /// 删除自定义菜单
    /// </summary>
    /// <param name="ct">取消令牌</param>
    Task<DeleteMenuResponse> DeleteAsync(CancellationToken ct = default);
}

