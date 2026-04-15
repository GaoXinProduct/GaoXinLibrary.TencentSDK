using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Agent;
using GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>应用管理服务实现（含自定义菜单管理）</summary>
public class AgentService
{
    private readonly WecomHttpClient _http;
    private readonly WecomOptions _options;

    public AgentService(WecomHttpClient http, WecomOptions options)
    {
        _http = http;
        _options = options;
    }

    /// <summary>
    /// 获取当前应用的详细信息
    /// <para>对应接口：GET /cgi-bin/agent/get</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>应用详细信息</returns>
    public async Task<AgentInfo> GetAgentAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetAgentResponse>("/cgi-bin/agent/get",
            new() { ["agentid"] = _options.AgentId.ToString() }, ct);
        return resp.ToAgentInfo();
    }

    /// <summary>
    /// 获取当前企业所有自建应用列表
    /// <para>对应接口：GET /cgi-bin/agent/list</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>应用信息数组</returns>
    public async Task<AgentInfo[]> GetAgentListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetAgentListResponse>("/cgi-bin/agent/list", null, ct);
        return resp.AgentList ?? [];
    }

    /// <summary>
    /// 修改应用信息（名称、头像、描述、可见范围等）
    /// <para>对应接口：POST /cgi-bin/agent/set</para>
    /// </summary>
    /// <param name="request">应用设置请求，仅填写需修改的字段</param>
    /// <param name="ct">取消令牌</param>
    public async Task SetAgentAsync(SetAgentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/agent/set", request, ct);

    /// <summary>
    /// 创建或覆盖当前应用的自定义菜单
    /// <para>对应接口：POST /cgi-bin/menu/create</para>
    /// </summary>
    /// <param name="request">菜单定义，最多3个一级菜单，每个一级菜单最多5个子菜单</param>
    /// <param name="ct">取消令牌</param>
    public async Task CreateMenuAsync(CreateMenuRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/menu/create", request,
            new() { ["agentid"] = _options.AgentId.ToString() }, ct);

    /// <summary>
    /// 获取当前应用已创建的菜单
    /// <para>对应接口：GET /cgi-bin/menu/get</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>菜单按钮数组</returns>
    public async Task<MenuButton[]> GetMenuAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetMenuResponse>("/cgi-bin/menu/get",
            new() { ["agentid"] = _options.AgentId.ToString() }, ct);
        return resp.Button ?? [];
    }

    /// <summary>
    /// 删除当前应用的自定义菜单
    /// <para>对应接口：GET /cgi-bin/menu/delete</para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    public async Task DeleteMenuAsync(CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/menu/delete",
            new() { ["agentid"] = _options.AgentId.ToString() }, ct);

    /// <summary>
    /// 设置工作台自定义展示（设置应用在工作台的展示模板和内容）
    /// <para>对应接口：POST /cgi-bin/agent/set_workbench_template</para>
    /// </summary>
    /// <param name="request">工作台展示设置请求</param>
    /// <param name="ct">取消令牌</param>
    public async Task SetWorkbenchTemplateAsync(SetWorkbenchTemplateRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/agent/set_workbench_template", request, ct);
}