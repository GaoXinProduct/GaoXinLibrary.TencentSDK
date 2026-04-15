using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.User;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public class UserService
{
    private readonly WecomHttpClient _http;

    public UserService(WecomHttpClient http) => _http = http;

    /// <summary>创建成员</summary>
    public async Task CreateUserAsync(CreateUserRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/user/create", request, ct);

    /// <summary>读取成员</summary>
    public async Task<UserInfo> GetUserAsync(string userId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetUserDirectResponse>("/cgi-bin/user/get",
            new() { ["userid"] = userId }, ct);
        return resp.ToUserInfo();
    }

    /// <summary>更新成员</summary>
    public async Task UpdateUserAsync(UpdateUserRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/user/update", request, ct);

    /// <summary>删除成员</summary>
    public async Task DeleteUserAsync(string userId, CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/user/delete",
            new() { ["userid"] = userId }, ct);

    /// <summary>批量删除成员</summary>
    public async Task BatchDeleteUsersAsync(BatchDeleteUserRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/user/batchdelete", request, ct);

    /// <summary>获取部门成员（简单信息）</summary>
    public async Task<SimpleUserInfo[]> GetDepartmentSimpleUsersAsync(int departmentId, bool fetchChild = false, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetSimpleUsersResponse>("/cgi-bin/user/simplelist",
            new() { ["department_id"] = departmentId.ToString(), ["fetch_child"] = fetchChild ? "1" : "0" }, ct);
        return resp.UserList ?? [];
    }

    /// <summary>获取部门成员详情</summary>
    public async Task<UserInfo[]> GetDepartmentUsersAsync(int departmentId, bool fetchChild = false, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetDepartmentUsersResponse>("/cgi-bin/user/list",
            new() { ["department_id"] = departmentId.ToString(), ["fetch_child"] = fetchChild ? "1" : "0" }, ct);
        return resp.UserList ?? [];
    }

    /// <summary>userid 转换为 openid</summary>
    public async Task<string> ConvertUserIdToOpenIdAsync(ConvertToOpenIdRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<ConvertOpenIdResponse>("/cgi-bin/user/convert_to_openid", request, ct);
        return resp.OpenId ?? string.Empty;
    }

    /// <summary>openid 转换为 userid</summary>
    public async Task<string> ConvertOpenIdToUserIdAsync(ConvertToUserIdRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<ConvertOpenIdResponse>("/cgi-bin/user/convert_to_userid", request, ct);
        return resp.UserId ?? string.Empty;
    }

    /// <summary>获取加入企业二维码</summary>
    public async Task<string> GetJoinQrCodeAsync(int sizeType = 3, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetJoinQrCodeResponse>("/cgi-bin/corp/get_join_qrcode",
            new() { ["size_type"] = sizeType.ToString() }, ct);
        return resp.JoinQrCode ?? string.Empty;
    }

    /// <summary>手机号获取 userid</summary>
    public async Task<string> GetUserIdByMobileAsync(GetUserIdByMobileRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetUserIdByMobileResponse>("/cgi-bin/user/getuserid", request, ct);
        return resp.UserId ?? string.Empty;
    }

    /// <summary>邮箱获取 userid</summary>
    public async Task<string> GetUserIdByEmailAsync(GetUserIdByEmailRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetUserIdByMobileResponse>("/cgi-bin/user/get_userid_by_email", request, ct);
        return resp.UserId ?? string.Empty;
    }

    /// <summary>邀请成员（企业微信、邮件或短信）</summary>
    public async Task<InviteMemberResponse> InviteMemberAsync(InviteMemberRequest request, CancellationToken ct = default)
        => await _http.PostAsync<InviteMemberResponse>("/cgi-bin/batch/inviteuser", request, ct);

    /// <summary>获取成员ID列表（支持分页）</summary>
    public async Task<GetUserIdListResponse> GetUserIdListAsync(int? departmentId = null, string? cursor = null, int limit = 10000, CancellationToken ct = default)
    {
        var body = new Dictionary<string, object?>();
        if (departmentId.HasValue) body["department_id"] = departmentId.Value;
        if (!string.IsNullOrEmpty(cursor)) body["cursor"] = cursor;
        body["limit"] = limit;
        return await _http.PostAsync<GetUserIdListResponse>("/cgi-bin/user/list_id", body, ct);
    }

    /// <summary>登录二次验证</summary>
    /// <param name="userId">成员 userid</param>
    /// <param name="ct">取消令牌</param>
    public async Task AuthSuccAsync(string userId, CancellationToken ct = default)
        => await _http.GetAsync<WecomBaseResponse>("/cgi-bin/user/authsucc",
            new() { ["userid"] = userId }, ct);
}
