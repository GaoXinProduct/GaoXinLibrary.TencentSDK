using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>微信客服服务实现</summary>
public class KfService : IKfService
{
    private readonly WecomHttpClient _http;

    public KfService(WecomHttpClient http) => _http = http;

    // ─── 客服账号管理 ─────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<string> AddAccountAsync(string name, string? mediaId = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfAccountAddResponse>(
            "/cgi-bin/kf/account/add",
            new KfAccountAddRequest { Name = name, MediaId = mediaId }, ct);
        return resp.OpenKfId;
    }

    /// <inheritdoc/>
    public async Task DeleteAccountAsync(string openKfId, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/account/del",
            new KfAccountDelRequest { OpenKfId = openKfId }, ct);
    }

    /// <inheritdoc/>
    public async Task UpdateAccountAsync(KfAccountUpdateRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/account/update", request, ct);
    }

    /// <inheritdoc/>
    public async Task<KfAccount[]> ListAccountsAsync(int? offset = null, int? limit = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfAccountListResponse>(
            "/cgi-bin/kf/account/list",
            new KfAccountListRequest { Offset = offset, Limit = limit }, ct);
        return resp.AccountList ?? [];
    }

    /// <inheritdoc/>
    public async Task<string> GetContactWayAsync(string openKfId, string? scene = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfAddContactWayResponse>(
            "/cgi-bin/kf/add_contact_way",
            new KfAddContactWayRequest { OpenKfId = openKfId, Scene = scene }, ct);
        return resp.Url;
    }

    // ─── 接待人员管理 ─────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<KfServicerResult[]> AddServicerAsync(KfServicerAddRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfServicerResponse>(
            "/cgi-bin/kf/servicer/add", request, ct);
        return resp.ResultList ?? [];
    }

    /// <inheritdoc/>
    public async Task<KfServicerResult[]> DeleteServicerAsync(KfServicerDelRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfServicerResponse>(
            "/cgi-bin/kf/servicer/del", request, ct);
        return resp.ResultList ?? [];
    }

    /// <inheritdoc/>
    public async Task<KfServicer[]> ListServicersAsync(string openKfId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<KfServicerListResponse>(
            "/cgi-bin/kf/servicer/list",
            new Dictionary<string, string?> { ["open_kfid"] = openKfId }, ct);
        return resp.ServicerList ?? [];
    }

    // ─── 会话分配 ─────────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<KfServiceStateGetResponse> GetServiceStateAsync(string openKfId, string externalUserId, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfServiceStateGetResponse>(
            "/cgi-bin/kf/service_state/get",
            new KfServiceStateGetRequest { OpenKfId = openKfId, ExternalUserId = externalUserId }, ct);
    }

    /// <inheritdoc/>
    public async Task<KfServiceStateTransResponse> TransServiceStateAsync(KfServiceStateTransRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfServiceStateTransResponse>(
            "/cgi-bin/kf/service_state/trans", request, ct);
    }

    // ─── 消息收发 ─────────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<KfSyncMsgResponse> SyncMsgAsync(KfSyncMsgRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfSyncMsgResponse>(
            "/cgi-bin/kf/sync_msg", request, ct);
    }

    /// <inheritdoc/>
    public async Task<KfSendMsgResponse> SendMsgAsync(KfSendMsgRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfSendMsgResponse>(
            "/cgi-bin/kf/send_msg", request, ct);
    }

    // ─── 客户信息 ─────────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<KfCustomer[]> BatchGetCustomerAsync(string[] externalUserIds, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfCustomerBatchGetResponse>(
            "/cgi-bin/kf/customer/batchget",
            new KfCustomerBatchGetRequest { ExternalUserIdList = externalUserIds }, ct);
        return resp.CustomerList ?? [];
    }

    // ─── 统计 ─────────────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<KfCorpStatisticResponse> GetCorpStatisticAsync(KfStatisticRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfCorpStatisticResponse>(
            "/cgi-bin/kf/get_corp_statistic", request, ct);
    }

    /// <inheritdoc/>
    public async Task<KfServicerStatisticResponse> GetServicerStatisticAsync(KfStatisticRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfServicerStatisticResponse>(
            "/cgi-bin/kf/get_servicer_statistic", request, ct);
    }

    // ─── 事件响应消息 ─────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<KfSendMsgOnEventResponse> SendMsgOnEventAsync(KfSendMsgOnEventRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfSendMsgOnEventResponse>(
            "/cgi-bin/kf/send_msg_on_event", request, ct);
    }

    // ─── 「升级服务」配置 ──────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<KfUpgradeServiceConfigResponse> GetUpgradeServiceConfigAsync(string openKfId, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfUpgradeServiceConfigResponse>(
            "/cgi-bin/kf/customer/get_upgrade_service_config",
            new KfUpgradeServiceConfigRequest { OpenKfId = openKfId }, ct);
    }

    /// <inheritdoc/>
    public async Task UpgradeServiceAsync(KfCustomerUpgradeServiceRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/customer/upgrade_service", request, ct);
    }

    /// <inheritdoc/>
    public async Task CancelUpgradeServiceAsync(KfCustomerCancelUpgradeServiceRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/customer/cancel_upgrade_service", request, ct);
    }

    // ─── 知识库分组管理 ─────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<string> AddKnowledgeGroupAsync(string name, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfKnowledgeAddGroupResponse>(
            "/cgi-bin/kf/knowledge/add_group",
            new KfKnowledgeAddGroupRequest { Name = name }, ct);
        return resp.GroupId ?? string.Empty;
    }

    /// <inheritdoc/>
    public async Task DeleteKnowledgeGroupAsync(string groupId, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/knowledge/del_group",
            new KfKnowledgeDelGroupRequest { GroupId = groupId }, ct);
    }

    /// <inheritdoc/>
    public async Task UpdateKnowledgeGroupAsync(string groupId, string name, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/knowledge/mod_group",
            new KfKnowledgeModGroupRequest { GroupId = groupId, Name = name }, ct);
    }

    /// <inheritdoc/>
    public async Task<KfKnowledgeListGroupResponse> ListKnowledgeGroupsAsync(KfKnowledgeListGroupRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfKnowledgeListGroupResponse>(
            "/cgi-bin/kf/knowledge/list_group", request, ct);
    }

    // ─── 知识库问答管理 ─────────────────────────────────────────────────────

    /// <inheritdoc/>
    public async Task<string> AddKnowledgeIntentAsync(KfKnowledgeAddIntentRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfKnowledgeAddIntentResponse>(
            "/cgi-bin/kf/knowledge/add_intent", request, ct);
        return resp.IntentId ?? string.Empty;
    }

    /// <inheritdoc/>
    public async Task DeleteKnowledgeIntentAsync(string intentId, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/knowledge/del_intent",
            new KfKnowledgeDelIntentRequest { IntentId = intentId }, ct);
    }

    /// <inheritdoc/>
    public async Task UpdateKnowledgeIntentAsync(KfKnowledgeModIntentRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/knowledge/mod_intent", request, ct);
    }

    /// <inheritdoc/>
    public async Task<KfKnowledgeListIntentResponse> ListKnowledgeIntentsAsync(KfKnowledgeListIntentRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfKnowledgeListIntentResponse>(
            "/cgi-bin/kf/knowledge/list_intent", request, ct);
    }
}
