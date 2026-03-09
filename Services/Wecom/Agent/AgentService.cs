using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Agent;
using GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>应用管理服务实现（含自定义菜单管理）</summary>
public class AgentService : IAgentService, IMenuService
{
    private readonly WecomHttpClient _http;
    private readonly WecomOptions _options;

    public AgentService(WecomHttpClient http, WecomOptions options)
    {
        _http = http;
        _options = options;
    }

    public async Task<AgentInfo> GetAgentAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetAgentResponse>("/cgi-bin/agent/get",
            new() { ["agentid"] = _options.AgentId.ToString() }, ct);
        return resp.ToAgentInfo();
    }

    public async Task<AgentInfo[]> GetAgentListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetAgentListResponse>("/cgi-bin/agent/list", null, ct);
        return resp.AgentList ?? [];
    }

    public async Task SetAgentAsync(SetAgentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/agent/set", request, ct);

    public async Task CreateMenuAsync(CreateMenuRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/menu/create", request,
            new() { ["agentid"] = _options.AgentId.ToString() }, ct);

    public async Task<MenuButton[]> GetMenuAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetMenuResponse>("/cgi-bin/menu/get",
            new() { ["agentid"] = _options.AgentId.ToString() }, ct);
        return resp.Button ?? [];
    }

    public async Task DeleteMenuAsync(CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/menu/delete",
            new() { ["agentid"] = _options.AgentId.ToString() }, ct);

    public async Task SetWorkbenchTemplateAsync(SetWorkbenchTemplateRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/agent/set_workbench_template", request, ct);
}
