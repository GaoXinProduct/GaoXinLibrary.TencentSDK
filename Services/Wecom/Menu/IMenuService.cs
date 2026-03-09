using GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 自定义菜单管理服务接口
/// <para>
/// 菜单管理属于应用管理的子功能；<see cref="IAgentService"/> 实现了此接口，
/// 二者通过同一 <c>AgentService</c> 实例提供服务。
/// </para>
/// </summary>
public interface IMenuService
{
    /// <summary>
    /// 创建或覆盖当前应用的自定义菜单
    /// <para>对应接口：POST /cgi-bin/menu/create</para>
    /// </summary>
    /// <param name="request">菜单定义，最多3个一级菜单，每个一级菜单最多5个子菜单</param>
    /// <param name="ct">取消令牌</param>
    Task CreateMenuAsync(CreateMenuRequest request, CancellationToken ct = default);

    /// <summary>
    /// 获取当前应用已创建的菜单
    /// <para>对应接口：GET /cgi-bin/menu/get</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>菜单按钮数组</returns>
    Task<MenuButton[]> GetMenuAsync(CancellationToken ct = default);

    /// <summary>
    /// 删除当前应用的自定义菜单
    /// <para>对应接口：GET /cgi-bin/menu/delete</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    Task DeleteMenuAsync(CancellationToken ct = default);

    /// <summary>
    /// 设置工作台自定义展示（设置应用在工作台的展示模板和内容）
    /// <para>对应接口：POST /cgi-bin/agent/set_workbench_template</para>
    /// </summary>
    /// <param name="request">工作台展示设置请求</param>
    /// <param name="ct">取消令牌</param>
    Task SetWorkbenchTemplateAsync(SetWorkbenchTemplateRequest request, CancellationToken ct = default);
}
