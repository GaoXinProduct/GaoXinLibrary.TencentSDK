using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CorpGroup;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>
/// 企业互联服务接口
/// <para>
/// 提供上级企业与下级/下游企业之间的应用共享、access_token 获取、小程序 session 转换等功能。
/// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/93360"/>
/// </para>
/// </summary>
public interface ICorpGroupService
{
    /// <summary>
    /// 获取应用共享信息
    /// <para>获取分享后的下级企业的 CorpId 和应用 AgentId 列表。</para>
    /// </summary>
    /// <param name="agentId">上级企业应用的 AgentId</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>下级/下游企业的应用共享信息列表</returns>
    Task<SharedCorpInfo[]> GetAppShareInfoAsync(int agentId, CancellationToken ct = default);

    /// <summary>
    /// 获取下级/下游企业的 access_token
    /// <para>使用上级企业的 access_token 换取下级企业的 access_token，以调用下级企业的 API 接口。</para>
    /// </summary>
    /// <param name="corpId">下级/下游企业的 CorpId</param>
    /// <param name="agentId">下级/下游企业的应用 AgentId</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>下级企业的 access_token 信息</returns>
    Task<GetCorpTokenResponse> GetCorpTokenAsync(string corpId, int agentId, CancellationToken ct = default);

    /// <summary>
    /// 获取下级/下游企业小程序 session
    /// <para>将上级企业的小程序 session 转换为下级企业的 session，用于跨企业小程序登录。</para>
    /// </summary>
    /// <param name="userId">通过 code2Session 接口获取到的 userid</param>
    /// <param name="sessionKey">通过 code2Session 接口获取到的 session_key</param>
    /// <param name="ct">取消令牌</param>
    /// <returns>下级企业的 userid 和 session_key</returns>
    Task<TransferSessionResponse> TransferSessionAsync(string userId, string sessionKey, CancellationToken ct = default);
}
