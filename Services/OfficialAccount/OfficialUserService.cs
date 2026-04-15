using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号用户管理服务实现</summary>
public class OfficialUserService
{
    private readonly WechatHttpClient _http;

    public OfficialUserService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <summary>
    /// 获取用户基本信息（包括 UnionID 机制）
    /// </summary>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="lang">语言（zh_CN/zh_TW/en），默认 zh_CN</param>
    /// <param name="ct">取消令牌</param>
    public Task<UserInfoResponse> GetInfoAsync(string openId, string lang = "zh_CN", CancellationToken ct = default)
        => _http.GetAsync<UserInfoResponse>("/cgi-bin/user/info",
            new Dictionary<string, string?> { ["openid"] = openId, ["lang"] = lang }, ct);

    /// <summary>
    /// 批量获取用户基本信息
    /// </summary>
    /// <param name="request">批量请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<BatchGetUserInfoResponse> BatchGetInfoAsync(BatchGetUserInfoRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchGetUserInfoResponse>("/cgi-bin/user/info/batchget", request, ct);

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="nextOpenId">第一个拉取的 OpenId（不传则从头开始）</param>
    /// <param name="ct">取消令牌</param>
    public Task<UserListResponse> GetListAsync(string? nextOpenId = null, CancellationToken ct = default)
    {
        var queryParams = new Dictionary<string, string?>();
        if (!string.IsNullOrEmpty(nextOpenId))
            queryParams["next_openid"] = nextOpenId;
        return _http.GetAsync<UserListResponse>("/cgi-bin/user/get", queryParams, ct);
    }

    /// <summary>
    /// 获取全部用户 OpenId 列表（自动分页拉取）
    /// <para>
    /// 自动循环调用 <see cref="GetListAsync"/>，直到获取全部关注用户。
    /// 每次最多拉取 10000 个，适用于关注用户较多的公众号。
    /// </para>
    /// </summary>
    /// <param name="ct">取消令牌</param>
    /// <returns>所有关注用户的 OpenId 列表</returns>
    public async Task<List<string>> GetAllOpenIdsAsync(CancellationToken ct = default)
    {
        var allOpenIds = new List<string>();
        string? nextOpenId = null;

        do
        {
            var response = await GetListAsync(nextOpenId, ct);
            if (response.Data?.OpenId is { Count: > 0 } openIds)
                allOpenIds.AddRange(openIds);

            // 当返回的 next_openid 为空或者本次没有返回数据，则已拉取完毕
            nextOpenId = string.IsNullOrEmpty(response.NextOpenId) || response.Count == 0
                ? null
                : response.NextOpenId;
        }
        while (nextOpenId is not null);

        return allOpenIds;
    }

    /// <summary>
    /// 设置用户备注名
    /// </summary>
    /// <param name="openId">用户 OpenId</param>
    /// <param name="remark">新的备注名</param>
    /// <param name="ct">取消令牌</param>
    public Task<UpdateRemarkResponse> UpdateRemarkAsync(string openId, string remark, CancellationToken ct = default)
        => _http.PostAsync<UpdateRemarkResponse>("/cgi-bin/user/info/updateremark",
            new UpdateRemarkRequest { OpenId = openId, Remark = remark }, ct);

    /// <summary>
    /// 拉黑用户
    /// </summary>
    /// <param name="request">拉黑请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<WechatBaseResponse> BatchBlacklistAsync(BatchBlacklistRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/cgi-bin/tags/members/batchblacklist", request, ct);

    /// <summary>
    /// 取消拉黑用户
    /// </summary>
    /// <param name="request">取消拉黑请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<WechatBaseResponse> BatchUnblacklistAsync(BatchBlacklistRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/cgi-bin/tags/members/batchunblacklist", request, ct);

    /// <summary>
    /// 获取公众号黑名单列表
    /// </summary>
    /// <param name="request">黑名单分页请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<UserListResponse> GetBlacklistAsync(GetBlacklistRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserListResponse>("/cgi-bin/tags/members/getblacklist", request, ct);

    /// <summary>
    /// 迁移场景下转换 OpenId
    /// </summary>
    /// <param name="request">转换请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<ChangeOpenIdResponse> ChangeOpenIdAsync(ChangeOpenIdRequest request, CancellationToken ct = default)
        => _http.PostAsync<ChangeOpenIdResponse>("/cgi-bin/changeopenid", request, ct);
}
