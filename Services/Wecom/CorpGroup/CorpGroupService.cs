using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CorpGroup;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>企业互联服务实现</summary>
public class CorpGroupService : ICorpGroupService
{
    private readonly WecomHttpClient _http;

    public CorpGroupService(WecomHttpClient http) => _http = http;

    /// <inheritdoc/>
    public async Task<SharedCorpInfo[]> GetAppShareInfoAsync(int agentId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetAppShareInfoResponse>(
            "/cgi-bin/corpgroup/corp/get_app_share_info",
            new GetAppShareInfoRequest { AgentId = agentId }, ct);
        return resp.CorpList ?? [];
    }

    /// <inheritdoc/>
    public async Task<GetCorpTokenResponse> GetCorpTokenAsync(string corpId, int agentId, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetCorpTokenResponse>(
            "/cgi-bin/corpgroup/corp/gettoken",
            new GetCorpTokenRequest { CorpId = corpId, AgentId = agentId }, ct);
    }

    /// <inheritdoc/>
    public async Task<TransferSessionResponse> TransferSessionAsync(string userId, string sessionKey, CancellationToken ct = default)
    {
        return await _http.PostAsync<TransferSessionResponse>(
            "/cgi-bin/miniprogram/transfer_session",
            new TransferSessionRequest { UserId = userId, SessionKey = sessionKey }, ct);
    }
}
