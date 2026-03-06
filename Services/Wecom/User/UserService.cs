using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.User;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public class UserService : IUserService
{
    private readonly WecomHttpClient _http;

    public UserService(WecomHttpClient http) => _http = http;

    public async Task CreateUserAsync(CreateUserRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/user/create", request, ct);

    public async Task<UserInfo> GetUserAsync(string userId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetUserDirectResponse>("/cgi-bin/user/get",
            new() { ["userid"] = userId }, ct);
        return resp.ToUserInfo();
    }

    public async Task UpdateUserAsync(UpdateUserRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/user/update", request, ct);

    public async Task DeleteUserAsync(string userId, CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/user/delete",
            new() { ["userid"] = userId }, ct);

    public async Task BatchDeleteUsersAsync(string[] userIds, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/user/batchdelete",
            new BatchDeleteUserRequest { UserIdList = userIds }, ct);

    public async Task<SimpleUserInfo[]> GetDepartmentSimpleUsersAsync(int departmentId, bool fetchChild = false, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetSimpleUsersResponse>("/cgi-bin/user/simplelist",
            new() { ["department_id"] = departmentId.ToString(), ["fetch_child"] = fetchChild ? "1" : "0" }, ct);
        return resp.UserList ?? [];
    }

    public async Task<UserInfo[]> GetDepartmentUsersAsync(int departmentId, bool fetchChild = false, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetDepartmentUsersResponse>("/cgi-bin/user/list",
            new() { ["department_id"] = departmentId.ToString(), ["fetch_child"] = fetchChild ? "1" : "0" }, ct);
        return resp.UserList ?? [];
    }

    public async Task<string> ConvertUserIdToOpenIdAsync(string userId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<ConvertOpenIdResponse>("/cgi-bin/user/convert_to_openid",
            new { userid = userId }, ct);
        return resp.OpenId ?? string.Empty;
    }

    public async Task<string> ConvertOpenIdToUserIdAsync(string openId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<ConvertOpenIdResponse>("/cgi-bin/user/convert_to_userid",
            new { openid = openId }, ct);
        return resp.UserId ?? string.Empty;
    }

    public async Task<string> GetJoinQrCodeAsync(int sizeType = 3, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetJoinQrCodeResponse>("/cgi-bin/corp/get_join_qrcode",
            new() { ["size_type"] = sizeType.ToString() }, ct);
        return resp.JoinQrCode ?? string.Empty;
    }

    public async Task<string> GetUserIdByMobileAsync(string mobile, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetUserIdByMobileResponse>("/cgi-bin/user/getuserid",
            new { mobile }, ct);
        return resp.UserId ?? string.Empty;
    }

    public async Task<string> GetUserIdByEmailAsync(string email, int emailType = 1, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetUserIdByMobileResponse>("/cgi-bin/user/get_userid_by_email",
            new { email, email_type = emailType }, ct);
        return resp.UserId ?? string.Empty;
    }

    public async Task<InviteMemberResponse> InviteMemberAsync(InviteMemberRequest request, CancellationToken ct = default)
        => await _http.PostAsync<InviteMemberResponse>("/cgi-bin/batch/inviteuser", request, ct);

    public async Task<GetUserIdListResponse> GetUserIdListAsync(int? departmentId = null, string? cursor = null, int limit = 10000, CancellationToken ct = default)
    {
        var body = new Dictionary<string, object?>();
        if (departmentId.HasValue) body["department_id"] = departmentId.Value;
        if (!string.IsNullOrEmpty(cursor)) body["cursor"] = cursor;
        body["limit"] = limit;
        return await _http.PostAsync<GetUserIdListResponse>("/cgi-bin/user/list_id", body, ct);
    }

    public async Task AuthSuccAsync(string userId, CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/user/authsucc",
            new() { ["userid"] = userId }, ct);
}
