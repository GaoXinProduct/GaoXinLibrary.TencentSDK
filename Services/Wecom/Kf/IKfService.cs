using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Kf;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 微信客服服务接口
/// <para>
/// 提供微信客服账号管理、接待人员管理、会话消息收发、客户信息查询及统计等功能。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/94638"/>
/// </para>
/// </summary>
public interface IKfService
{
    // ─── 客服账号管理 ─────────────────────────────────────────────────────

    /// <summary>添加客服账号</summary>
    /// <param name="name">客服名称</param>
    /// <param name="mediaId">客服头像的 media_id（可选）</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>新创建的客服账号 id</returns>
    Task<string> AddAccountAsync(string name, string? mediaId = null, CancellationToken ct = default);

    /// <summary>删除客服账号</summary>
    /// <param name="openKfId">客服账号 id</param>
    /// <param name="ct">取消令牌</param>
    Task DeleteAccountAsync(string openKfId, CancellationToken ct = default);

    /// <summary>修改客服账号</summary>
    /// <param name="request">修改请求</param>
    /// <param name="ct">取消令牌</param>
    Task UpdateAccountAsync(KfAccountUpdateRequest request, CancellationToken ct = default);

    /// <summary>获取客服账号列表</summary>
    /// <param name="offset">分页偏移量</param>
    /// <param name="limit">分页大小，最大100</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>客服账号列表</returns>
    Task<KfAccount[]> ListAccountsAsync(int? offset = null, int? limit = null, CancellationToken ct = default);

    /// <summary>获取客服账号链接</summary>
    /// <param name="openKfId">客服账号 id</param>
    /// <param name="scene">场景值（可选）</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>客服链接 URL</returns>
    Task<string> GetContactWayAsync(string openKfId, string? scene = null, CancellationToken ct = default);

    // ─── 接待人员管理 ─────────────────────────────────────────────────────

    /// <summary>添加接待人员</summary>
    /// <param name="request">添加请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>操作结果列表</returns>
    Task<KfServicerResult[]> AddServicerAsync(KfServicerAddRequest request, CancellationToken ct = default);

    /// <summary>删除接待人员</summary>
    /// <param name="request">删除请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>操作结果列表</returns>
    Task<KfServicerResult[]> DeleteServicerAsync(KfServicerDelRequest request, CancellationToken ct = default);

    /// <summary>获取接待人员列表</summary>
    /// <param name="openKfId">客服账号 id</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>接待人员列表</returns>
    Task<KfServicer[]> ListServicersAsync(string openKfId, CancellationToken ct = default);

    // ─── 会话分配 ─────────────────────────────────────────────────────────

    /// <summary>获取会话状态</summary>
    /// <param name="openKfId">客服账号 id</param>
    /// <param name="externalUserId">微信客户的 external_userid</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>会话状态信息</returns>
    Task<KfServiceStateGetResponse> GetServiceStateAsync(string openKfId, string externalUserId, CancellationToken ct = default);

    /// <summary>变更会话状态</summary>
    /// <param name="request">变更请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>变更结果</returns>
    Task<KfServiceStateTransResponse> TransServiceStateAsync(KfServiceStateTransRequest request, CancellationToken ct = default);

    // ─── 消息收发 ─────────────────────────────────────────────────────────

    /// <summary>读取消息</summary>
    /// <param name="request">同步消息请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>消息列表及翻页信息</returns>
    Task<KfSyncMsgResponse> SyncMsgAsync(KfSyncMsgRequest request, CancellationToken ct = default);

    /// <summary>发送消息</summary>
    /// <param name="request">发送消息请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>发送结果</returns>
    Task<KfSendMsgResponse> SendMsgAsync(KfSendMsgRequest request, CancellationToken ct = default);

    // ─── 客户信息 ─────────────────────────────────────────────────────────

    /// <summary>批量获取客户基础信息</summary>
    /// <param name="externalUserIds">微信客户的 external_userid 列表，最多100个</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>客户信息列表</returns>
    Task<KfCustomer[]> BatchGetCustomerAsync(string[] externalUserIds, CancellationToken ct = default);

    // ─── 统计 ─────────────────────────────────────────────────────────────

    /// <summary>获取「客户数据」企业汇总数据</summary>
    /// <param name="request">统计请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>企业汇总统计</returns>
    Task<KfCorpStatisticResponse> GetCorpStatisticAsync(KfStatisticRequest request, CancellationToken ct = default);

    /// <summary>获取「客户数据」接待人员明细数据</summary>
    /// <param name="request">统计请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>接待人员明细统计</returns>
    Task<KfServicerStatisticResponse> GetServicerStatisticAsync(KfStatisticRequest request, CancellationToken ct = default);

    // ─── 事件响应消息 ─────────────────────────────────────────────────────

    /// <summary>发送欢迎语等事件响应消息</summary>
    /// <param name="request">事件响应消息请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>发送结果</returns>
    Task<KfSendMsgOnEventResponse> SendMsgOnEventAsync(KfSendMsgOnEventRequest request, CancellationToken ct = default);

    // ─── 「升级服务」配置 ──────────────────────────────────────────────────

    /// <summary>获取配置的专员与客户群</summary>
    /// <param name="openKfId">客服账号 id</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>升级服务配置</returns>
    Task<KfUpgradeServiceConfigResponse> GetUpgradeServiceConfigAsync(string openKfId, CancellationToken ct = default);

    /// <summary>为客户升级为专员或客户群服务</summary>
    /// <param name="request">升级请求</param>
    /// <param name="ct">取消令牌</param>
    Task UpgradeServiceAsync(KfCustomerUpgradeServiceRequest request, CancellationToken ct = default);

    /// <summary>为客户取消升级服务</summary>
    /// <param name="request">取消升级请求</param>
    /// <param name="ct">取消令牌</param>
    Task CancelUpgradeServiceAsync(KfCustomerCancelUpgradeServiceRequest request, CancellationToken ct = default);

    // ─── 知识库分组管理 ─────────────────────────────────────────────────────

    /// <summary>添加知识库分组</summary>
    /// <param name="name">分组名称</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>分组 id</returns>
    Task<string> AddKnowledgeGroupAsync(string name, CancellationToken ct = default);

    /// <summary>删除知识库分组</summary>
    /// <param name="groupId">分组 id</param>
    /// <param name="ct">取消令牌</param>
    Task DeleteKnowledgeGroupAsync(string groupId, CancellationToken ct = default);

    /// <summary>修改知识库分组</summary>
    /// <param name="groupId">分组 id</param>
    /// <param name="name">分组名称</param>
    /// <param name="ct">取消令牌</param>
    Task UpdateKnowledgeGroupAsync(string groupId, string name, CancellationToken ct = default);

    /// <summary>获取知识库分组列表</summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>分组列表响应</returns>
    Task<KfKnowledgeListGroupResponse> ListKnowledgeGroupsAsync(KfKnowledgeListGroupRequest request, CancellationToken ct = default);

    // ─── 知识库问答管理 ─────────────────────────────────────────────────────

    /// <summary>添加知识库问答</summary>
    /// <param name="request">添加请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>问答 id</returns>
    Task<string> AddKnowledgeIntentAsync(KfKnowledgeAddIntentRequest request, CancellationToken ct = default);

    /// <summary>删除知识库问答</summary>
    /// <param name="intentId">问答 id</param>
    /// <param name="ct">取消令牌</param>
    Task DeleteKnowledgeIntentAsync(string intentId, CancellationToken ct = default);

    /// <summary>修改知识库问答</summary>
    /// <param name="request">修改请求</param>
    /// <param name="ct">取消令牌</param>
    Task UpdateKnowledgeIntentAsync(KfKnowledgeModIntentRequest request, CancellationToken ct = default);

    /// <summary>获取知识库问答列表</summary>
    /// <param name="request">查询请求</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>问答列表响应</returns>
    Task<KfKnowledgeListIntentResponse> ListKnowledgeIntentsAsync(KfKnowledgeListIntentRequest request, CancellationToken ct = default);
}
