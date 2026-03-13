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

    public async Task<BatchGetExternalContactResponse> BatchGetExternalContactAsync(BatchGetByUserRequest request, CancellationToken ct = default)
        => await _http.PostAsync<BatchGetExternalContactResponse>("/cgi-bin/externalcontact/batch/get_by_user", request, ct);

    public async Task UpdateRemarkAsync(UpdateRemarkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/remark", request, ct);

    public async Task<GetGroupChatListResponse> GetGroupChatListAsync(GetGroupChatListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetGroupChatListResponse>("/cgi-bin/externalcontact/groupchat/list", request, ct);

    public async Task<GetUserBehaviorDataResponse> GetUserBehaviorDataAsync(GetUserBehaviorDataRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetUserBehaviorDataResponse>("/cgi-bin/externalcontact/get_user_behavior_data", request, ct);

    public async Task SendWelcomeMsgAsync(SendWelcomeMsgRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/externalcontact/send_welcome_msg", request, ct);
}
