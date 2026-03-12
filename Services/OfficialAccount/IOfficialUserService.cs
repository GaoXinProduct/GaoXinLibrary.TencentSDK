using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 公众号用户管理服务接口
/// </summary>
public interface IOfficialUserService
{
    /// <summary>
    /// 获取用户基本信息（包括 UnionID 机制）
    /// </summary>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="lang">语言（zh_CN/zh_TW/en），默认 zh_CN</param>
    /// <param name="ct">取消令牌</param>
    Task<UserInfoResponse> GetInfoAsync(string openId, string lang = "zh_CN", CancellationToken ct = default);

    /// <summary>
    /// 批量获取用户基本信息
    /// </summary>
    /// <param name="request">批量请求参数</param>
    /// <param name="ct">取消令牌</param>
    Task<BatchGetUserInfoResponse> BatchGetInfoAsync(BatchGetUserInfoRequest request, CancellationToken ct = default);

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="nextOpenId">第一个拉取的 OpenId（不传则从头开始）</param>
    /// <param name="ct">取消令牌</param>
    Task<UserListResponse> GetListAsync(string? nextOpenId = null, CancellationToken ct = default);

    /// <summary>
    /// 获取全部用户 OpenId 列表（自动分页拉取）
    /// <para>
    /// 自动循环调用 <see cref="GetListAsync"/>，直到获取全部关注用户。
    /// 每次最多拉取 10000 个，适用于关注用户较多的公众号。
    /// </para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>所有关注用户的 OpenId 列表</returns>
    Task<List<string>> GetAllOpenIdsAsync(CancellationToken ct = default);

    /// <summary>
    /// 设置用户备注名
    /// </summary>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="remark">新的备注名</param>
    /// <param name="ct">取消令牌</param>
    Task<UpdateRemarkResponse> UpdateRemarkAsync(string openId, string remark, CancellationToken ct = default);

    /// <summary>
    /// 拉黑用户
    /// </summary>
    /// <param name="request">拉黑请求参数</param>
    /// <param name="ct">取消令牌</param>
    Task<WechatBaseResponse> BatchBlacklistAsync(BatchBlacklistRequest request, CancellationToken ct = default);

    /// <summary>
    /// 取消拉黑用户
    /// </summary>
    /// <param name="request">取消拉黑请求参数</param>
    /// <param name="ct">取消令牌</param>
    Task<WechatBaseResponse> BatchUnblacklistAsync(BatchBlacklistRequest request, CancellationToken ct = default);

    /// <summary>
    /// 获取公众号黑名单列表
    /// </summary>
    /// <param name="request">黑名单分页请求参数</param>
    /// <param name="ct">取消令牌</param>
    Task<UserListResponse> GetBlacklistAsync(GetBlacklistRequest request, CancellationToken ct = default);

    /// <summary>
    /// 迁移场景下转换 OpenId
    /// </summary>
    /// <param name="request">转换请求参数</param>
    /// <param name="ct">取消令牌</param>
    Task<ChangeOpenIdResponse> ChangeOpenIdAsync(ChangeOpenIdRequest request, CancellationToken ct = default);
}

