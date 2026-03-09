using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Agent;
using GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 应用管理服务接口
/// <para>
/// 包含自建应用的查询、配置以及自定义菜单管理功能，
/// 对应企业微信文档「应用管理」章节。
/// </para>
/// </summary>
public interface IAgentService
{
    /// <summary>
    /// 获取当前应用的详细信息
    /// <para>对应接口：GET /cgi-bin/agent/get</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>应用详细信息</returns>
    Task<AgentInfo> GetAgentAsync(CancellationToken ct = default);

    /// <summary>
    /// 获取当前企业所有自建应用列表
    /// <para>对应接口：GET /cgi-bin/agent/list</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>应用信息数组</returns>
    Task<AgentInfo[]> GetAgentListAsync(CancellationToken ct = default);

    /// <summary>
    /// 修改应用信息（名称、头像、描述、可见范围等）
    /// <para>对应接口：POST /cgi-bin/agent/set</para>
    /// </summary>
    /// <param name="request">应用设置请求，仅填写需修改的字段</param>
    /// <param name="ct">取消令牌</param>
    Task SetAgentAsync(SetAgentRequest request, CancellationToken ct = default);

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
