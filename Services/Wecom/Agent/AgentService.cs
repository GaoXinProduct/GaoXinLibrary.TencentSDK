using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Agent;
using GaoXinLibrary.TencentSDK.Wecom.Models.Menu;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>应用管理服务实现（含自定义菜单管理）</summary>
public class AgentService : IAgentService, IMenuService
{
    private readonly WecomHttpClient _http;

    public AgentService(WecomHttpClient http) => _http = http;

    public async Task<AgentInfo> GetAgentAsync(int agentId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetAgentResponse>("/cgi-bin/agent/get",
            new() { ["agentid"] = agentId.ToString() }, ct);
        return resp.ToAgentInfo();
    }

    public async Task<AgentInfo[]> GetAgentListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetAgentListResponse>("/cgi-bin/agent/list", null, ct);
        return resp.AgentList ?? [];
    }

    public async Task SetAgentAsync(SetAgentRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/agent/set", request, ct);

    public async Task CreateMenuAsync(int agentId, CreateMenuRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/menu/create", request,
            new() { ["agentid"] = agentId.ToString() }, ct);

    public async Task<MenuButton[]> GetMenuAsync(int agentId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetMenuResponse>("/cgi-bin/menu/get",
            new() { ["agentid"] = agentId.ToString() }, ct);
        return resp.Button ?? [];
    }

    public async Task DeleteMenuAsync(int agentId, CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/menu/delete",
            new() { ["agentid"] = agentId.ToString() }, ct);

    public async Task SetWorkbenchTemplateAsync(SetWorkbenchTemplateRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/agent/set_workbench_template", request, ct);
}
