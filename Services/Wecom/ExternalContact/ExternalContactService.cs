using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>客户联系服务实现</summary>
public class ExternalContactService : IExternalContactService
{
    private readonly WecomHttpClient _http;

    public ExternalContactService(WecomHttpClient http) => _http = http;

    public async Task<string[]> GetFollowUserListAsync(CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetFollowUserListResponse>("/cgi-bin/externalcontact/get_follow_user_list", ct: ct);
        return resp.FollowUserList ?? [];
    }

    public async Task<string[]> GetExternalContactListAsync(string userId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetExternalContactListResponse>("/cgi-bin/externalcontact/list",
            new() { ["userid"] = userId }, ct);
        return resp.ExternalUserIdList ?? [];
    }

    public async Task<GetExternalContactResponse> GetExternalContactAsync(string externalUserId, string? cursor = null, CancellationToken ct = default)
    {
        var query = new Dictionary<string, string?> { ["external_userid"] = externalUserId };
        if (!string.IsNullOrEmpty(cursor)) query["cursor"] = cursor;
        return await _http.GetAsync<GetExternalContactResponse>("/cgi-bin/externalcontact/get", query, ct);
    }

    public async Task<BatchGetExternalContactResponse> BatchGetExternalContactAsync(string[] userIdList, string? cursor = null, int limit = 100, CancellationToken ct = default)
        => await _http.PostAsync<BatchGetExternalContactResponse>("/cgi-bin/externalcontact/batch/get_by_user",
            new { userid_list = userIdList, cursor = cursor ?? "", limit }, ct);

    public async Task UpdateRemarkAsync(string userId, string externalUserId, string? remark = null, string? description = null, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/remark",
            new { userid = userId, external_userid = externalUserId, remark, description }, ct);

    public async Task<GetGroupChatListResponse> GetGroupChatListAsync(int statusFilter = 0, string? cursor = null, int limit = 100, CancellationToken ct = default)
        => await _http.PostAsync<GetGroupChatListResponse>("/cgi-bin/externalcontact/groupchat/list",
            new { status_filter = statusFilter, cursor = cursor ?? "", limit }, ct);

    public async Task<GetUserBehaviorDataResponse> GetUserBehaviorDataAsync(string[] userIdList, long startTime, long endTime, CancellationToken ct = default)
        => await _http.PostAsync<GetUserBehaviorDataResponse>("/cgi-bin/externalcontact/get_user_behavior_data",
            new { userid = userIdList, start_time = startTime, end_time = endTime }, ct);

    public async Task SendWelcomeMsgAsync(string welcomeCode, object text, object? image = null, object? link = null, object? miniProgram = null, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/send_welcome_msg",
            new { welcome_code = welcomeCode, text, image, link, miniprogram = miniProgram }, ct);
}
