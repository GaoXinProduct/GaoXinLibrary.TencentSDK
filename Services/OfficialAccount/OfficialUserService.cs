using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号用户管理服务实现</summary>
public class OfficialUserService : IOfficialUserService
{
    private readonly WechatHttpClient _http;

    public OfficialUserService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <inheritdoc/>
    public Task<UserInfoResponse> GetInfoAsync(string openId, string lang = "zh_CN", CancellationToken ct = default)
        => _http.GetAsync<UserInfoResponse>("/cgi-bin/user/info",
            new Dictionary<string, string?> { ["openid"] = openId, ["lang"] = lang }, ct);

    /// <inheritdoc/>
    public Task<BatchGetUserInfoResponse> BatchGetInfoAsync(BatchGetUserInfoRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchGetUserInfoResponse>("/cgi-bin/user/info/batchget", request, ct);

    /// <inheritdoc/>
    public Task<UserListResponse> GetListAsync(string? nextOpenId = null, CancellationToken ct = default)
    {
        var queryParams = new Dictionary<string, string?>();
        if (!string.IsNullOrEmpty(nextOpenId))
            queryParams["next_openid"] = nextOpenId;
        return _http.GetAsync<UserListResponse>("/cgi-bin/user/get", queryParams, ct);
    }

    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public Task<UpdateRemarkResponse> UpdateRemarkAsync(string openId, string remark, CancellationToken ct = default)
        => _http.PostAsync<UpdateRemarkResponse>("/cgi-bin/user/info/updateremark",
            new UpdateRemarkRequest { OpenId = openId, Remark = remark }, ct);

    /// <inheritdoc/>
    public Task<WechatBaseResponse> BatchBlacklistAsync(BatchBlacklistRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/cgi-bin/tags/members/batchblacklist", request, ct);

    /// <inheritdoc/>
    public Task<WechatBaseResponse> BatchUnblacklistAsync(BatchBlacklistRequest request, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/cgi-bin/tags/members/batchunblacklist", request, ct);

    /// <inheritdoc/>
    public Task<UserListResponse> GetBlacklistAsync(GetBlacklistRequest request, CancellationToken ct = default)
        => _http.PostAsync<UserListResponse>("/cgi-bin/tags/members/getblacklist", request, ct);

    /// <inheritdoc/>
    public Task<ChangeOpenIdResponse> ChangeOpenIdAsync(ChangeOpenIdRequest request, CancellationToken ct = default)
        => _http.PostAsync<ChangeOpenIdResponse>("/cgi-bin/changeopenid", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号素材管理服务

