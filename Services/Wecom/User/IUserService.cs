using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.User;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>成员管理服务接口</summary>
public interface IUserService
{
    /// <summary>创建成员</summary>
    Task CreateUserAsync(CreateUserRequest request, CancellationToken ct = default);

    /// <summary>读取成员</summary>
    Task<UserInfo> GetUserAsync(string userId, CancellationToken ct = default);

    /// <summary>更新成员</summary>
    Task UpdateUserAsync(UpdateUserRequest request, CancellationToken ct = default);

    /// <summary>删除成员</summary>
    Task DeleteUserAsync(string userId, CancellationToken ct = default);

    /// <summary>批量删除成员</summary>
    Task BatchDeleteUsersAsync(BatchDeleteUserRequest request, CancellationToken ct = default);

    /// <summary>获取部门成员（简单信息）</summary>
    Task<SimpleUserInfo[]> GetDepartmentSimpleUsersAsync(int departmentId, bool fetchChild = false, CancellationToken ct = default);

    /// <summary>获取部门成员详情</summary>
    Task<UserInfo[]> GetDepartmentUsersAsync(int departmentId, bool fetchChild = false, CancellationToken ct = default);

    /// <summary>userid 转换为 openid</summary>
    Task<string> ConvertUserIdToOpenIdAsync(ConvertToOpenIdRequest request, CancellationToken ct = default);

    /// <summary>openid 转换为 userid</summary>
    Task<string> ConvertOpenIdToUserIdAsync(ConvertToUserIdRequest request, CancellationToken ct = default);

    /// <summary>获取加入企业二维码</summary>
    Task<string> GetJoinQrCodeAsync(int sizeType = 3, CancellationToken ct = default);

    /// <summary>手机号获取 userid</summary>
    Task<string> GetUserIdByMobileAsync(GetUserIdByMobileRequest request, CancellationToken ct = default);

    /// <summary>邮箱获取 userid</summary>
    Task<string> GetUserIdByEmailAsync(GetUserIdByEmailRequest request, CancellationToken ct = default);

    /// <summary>邀请成员（企业微信、邮件或短信）</summary>
    Task<InviteMemberResponse> InviteMemberAsync(InviteMemberRequest request, CancellationToken ct = default);

    /// <summary>获取成员ID列表（支持分页）</summary>
    Task<GetUserIdListResponse> GetUserIdListAsync(int? departmentId = null, string? cursor = null, int limit = 10000, CancellationToken ct = default);

    /// <summary>登录二次验证</summary>
    /// <param name="userId">成员 userid</param>
    /// <param name="ct">取消令牌</param>
    Task AuthSuccAsync(string userId, CancellationToken ct = default);
}
