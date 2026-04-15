using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>微信客服服务实现</summary>
public class KfService
{
    private readonly WecomHttpClient _http;

    public KfService(WecomHttpClient http) => _http = http;

    #region 客服账号管理

    /// <summary>添加客服账号</summary>
    /// <param name="name">客服名称</param>
    /// <param name="mediaId">客服头像的 media_id（可选）</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>新创建的客服账号 id</returns>
    public async Task<string> AddAccountAsync(string name, string? mediaId = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfAccountAddResponse>(
            "/cgi-bin/kf/account/add",
            new KfAccountAddRequest { Name = name, MediaId = mediaId }, ct);
        return resp.OpenKfId;
    }

    /// <summary>删除客服账号</summary>
    /// <param name="openKfId">客服账号 id</param>
    /// <param name="ct">取消令牌</param>
    public async Task DeleteAccountAsync(string openKfId, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/account/del",
            new KfAccountDelRequest { OpenKfId = openKfId }, ct);
    }

    /// <summary>修改客服账号</summary>
    /// <param name="request">修改请求</param>
    /// <param name="ct">取消令牌</param>
    public async Task UpdateAccountAsync(KfAccountUpdateRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/account/update", request, ct);
    }

    /// <summary>获取客服账号列表</summary>
    /// <param name="offset">分页偏移量</param>
    /// <param name="limit">分页大小，最大100</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>客服账号列表</returns>
    public async Task<KfAccount[]> ListAccountsAsync(int? offset = null, int? limit = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfAccountListResponse>(
            "/cgi-bin/kf/account/list",
            new KfAccountListRequest { Offset = offset, Limit = limit }, ct);
        return resp.AccountList ?? [];
    }

    /// <summary>获取客服账号链接</summary>
    /// <param name="openKfId">客服账号 id</param>
    /// <param name="scene">场景值（可选）</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>客服链接 URL</returns>
    public async Task<string> GetContactWayAsync(string openKfId, string? scene = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfAddContactWayResponse>(
            "/cgi-bin/kf/add_contact_way",
            new KfAddContactWayRequest { OpenKfId = openKfId, Scene = scene }, ct);
        return resp.Url;
    }

    #endregion
    #region 接待人员管理

    /// <summary>添加接待人员</summary>
    /// <param name="request">添加请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>操作结果列表</returns>
    public async Task<KfServicerResult[]> AddServicerAsync(KfServicerAddRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfServicerResponse>(
            "/cgi-bin/kf/servicer/add", request, ct);
        return resp.ResultList ?? [];
    }

    /// <summary>删除接待人员</summary>
    /// <param name="request">删除请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>操作结果列表</returns>
    public async Task<KfServicerResult[]> DeleteServicerAsync(KfServicerDelRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfServicerResponse>(
            "/cgi-bin/kf/servicer/del", request, ct);
        return resp.ResultList ?? [];
    }

    /// <summary>获取接待人员列表</summary>
    /// <param name="openKfId">客服账号 id</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>接待人员列表</returns>
    public async Task<KfServicer[]> ListServicersAsync(string openKfId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<KfServicerListResponse>(
            "/cgi-bin/kf/servicer/list",
            new Dictionary<string, string?> { ["open_kfid"] = openKfId }, ct);
        return resp.ServicerList ?? [];
    }

    #endregion
    #region 会话分配

    /// <summary>获取会话状态</summary>
    /// <param name="openKfId">客服账号 id</param>
    /// <param name="externalUserId">微信客户的 external_userid</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>会话状态信息</returns>
    public async Task<KfServiceStateGetResponse> GetServiceStateAsync(string openKfId, string externalUserId, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfServiceStateGetResponse>(
            "/cgi-bin/kf/service_state/get",
            new KfServiceStateGetRequest { OpenKfId = openKfId, ExternalUserId = externalUserId }, ct);
    }

    /// <summary>变更会话状态</summary>
    /// <param name="request">变更请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>变更结果</returns>
    public async Task<KfServiceStateTransResponse> TransServiceStateAsync(KfServiceStateTransRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfServiceStateTransResponse>(
            "/cgi-bin/kf/service_state/trans", request, ct);
    }

    #endregion
    #region 消息收发

    /// <summary>读取消息</summary>
    /// <param name="request">同步消息请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>消息列表及翻页信息</returns>
    public async Task<KfSyncMsgResponse> SyncMsgAsync(KfSyncMsgRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfSyncMsgResponse>(
            "/cgi-bin/kf/sync_msg", request, ct);
    }

    /// <summary>发送消息</summary>
    /// <param name="request">发送消息请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>发送结果</returns>
    public async Task<KfSendMsgResponse> SendMsgAsync(KfSendMsgRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfSendMsgResponse>(
            "/cgi-bin/kf/send_msg", request, ct);
    }

    #endregion
    #region 客户信息

    /// <summary>批量获取客户基础信息</summary>
    /// <param name="externalUserIds">微信客户的 external_userid 列表，最多100个</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>客户信息列表</returns>
    public async Task<KfCustomer[]> BatchGetCustomerAsync(string[] externalUserIds, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfCustomerBatchGetResponse>(
            "/cgi-bin/kf/customer/batchget",
            new KfCustomerBatchGetRequest { ExternalUserIdList = externalUserIds }, ct);
        return resp.CustomerList ?? [];
    }

    #endregion
    #region 统计

    /// <summary>获取「客户数据」企业汇总数据</summary>
    /// <param name="request">统计请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>企业汇总统计</returns>
    public async Task<KfCorpStatisticResponse> GetCorpStatisticAsync(KfStatisticRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfCorpStatisticResponse>(
            "/cgi-bin/kf/get_corp_statistic", request, ct);
    }

    /// <summary>获取「客户数据」接待人员明细数据</summary>
    /// <param name="request">统计请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>接待人员明细统计</returns>
    public async Task<KfServicerStatisticResponse> GetServicerStatisticAsync(KfStatisticRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfServicerStatisticResponse>(
            "/cgi-bin/kf/get_servicer_statistic", request, ct);
    }

    #endregion
    #region 事件响应消息

    /// <summary>发送欢迎语等事件响应消息</summary>
    /// <param name="request">事件响应消息请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>发送结果</returns>
    public async Task<KfSendMsgOnEventResponse> SendMsgOnEventAsync(KfSendMsgOnEventRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfSendMsgOnEventResponse>(
            "/cgi-bin/kf/send_msg_on_event", request, ct);
    }

    #endregion
    #region 「升级服务」配置

    /// <summary>获取配置的专员与客户群</summary>
    /// <param name="openKfId">客服账号 id</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>升级服务配置</returns>
    public async Task<KfUpgradeServiceConfigResponse> GetUpgradeServiceConfigAsync(string openKfId, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfUpgradeServiceConfigResponse>(
            "/cgi-bin/kf/customer/get_upgrade_service_config",
            new KfUpgradeServiceConfigRequest { OpenKfId = openKfId }, ct);
    }

    /// <summary>为客户升级为专员或客户群服务</summary>
    /// <param name="request">升级请求</param>
    /// <param name="ct">取消令牌</param>
    public async Task UpgradeServiceAsync(KfCustomerUpgradeServiceRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/customer/upgrade_service", request, ct);
    }

    /// <summary>为客户取消升级服务</summary>
    /// <param name="request">取消升级请求</param>
    /// <param name="ct">取消令牌</param>
    public async Task CancelUpgradeServiceAsync(KfCustomerCancelUpgradeServiceRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/customer/cancel_upgrade_service", request, ct);
    }

    #endregion
    #region 知识库分组管理

    /// <summary>添加知识库分组</summary>
    /// <param name="name">分组名称</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>分组 id</returns>
    public async Task<string> AddKnowledgeGroupAsync(string name, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfKnowledgeAddGroupResponse>(
            "/cgi-bin/kf/knowledge/add_group",
            new KfKnowledgeAddGroupRequest { Name = name }, ct);
        return resp.GroupId ?? string.Empty;
    }

    /// <summary>删除知识库分组</summary>
    /// <param name="groupId">分组 id</param>
    /// <param name="ct">取消令牌</param>
    public async Task DeleteKnowledgeGroupAsync(string groupId, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/knowledge/del_group",
            new KfKnowledgeDelGroupRequest { GroupId = groupId }, ct);
    }

    /// <summary>修改知识库分组</summary>
    /// <param name="groupId">分组 id</param>
    /// <param name="name">分组名称</param>
    /// <param name="ct">取消令牌</param>
    public async Task UpdateKnowledgeGroupAsync(string groupId, string name, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/knowledge/mod_group",
            new KfKnowledgeModGroupRequest { GroupId = groupId, Name = name }, ct);
    }

    /// <summary>获取知识库分组列表</summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>分组列表响应</returns>
    public async Task<KfKnowledgeListGroupResponse> ListKnowledgeGroupsAsync(KfKnowledgeListGroupRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfKnowledgeListGroupResponse>(
            "/cgi-bin/kf/knowledge/list_group", request, ct);
    }

    #endregion
    #region 知识库问答管理

    /// <summary>添加知识库问答</summary>
    /// <param name="request">添加请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>问答 id</returns>
    public async Task<string> AddKnowledgeIntentAsync(KfKnowledgeAddIntentRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<KfKnowledgeAddIntentResponse>(
            "/cgi-bin/kf/knowledge/add_intent", request, ct);
        return resp.IntentId ?? string.Empty;
    }

    /// <summary>删除知识库问答</summary>
    /// <param name="intentId">问答 id</param>
    /// <param name="ct">取消令牌</param>
    public async Task DeleteKnowledgeIntentAsync(string intentId, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/knowledge/del_intent",
            new KfKnowledgeDelIntentRequest { IntentId = intentId }, ct);
    }

    /// <summary>修改知识库问答</summary>
    /// <param name="request">修改请求</param>
    /// <param name="ct">取消令牌</param>
    public async Task UpdateKnowledgeIntentAsync(KfKnowledgeModIntentRequest request, CancellationToken ct = default)
    {
        await _http.PostAsync<WecomBaseResponse>(
            "/cgi-bin/kf/knowledge/mod_intent", request, ct);
    }

    /// <summary>获取知识库问答列表</summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>问答列表响应</returns>
    public async Task<KfKnowledgeListIntentResponse> ListKnowledgeIntentsAsync(KfKnowledgeListIntentRequest request, CancellationToken ct = default)
    {
        return await _http.PostAsync<KfKnowledgeListIntentResponse>(
            "/cgi-bin/kf/knowledge/list_intent", request, ct);
    }
    #endregion
}
