using GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>客户联系服务接口</summary>
public interface IExternalContactService
{
    /// <summary>获取配置了客户联系功能的成员列表</summary>
    Task<string[]> GetFollowUserListAsync(CancellationToken ct = default);

    /// <summary>获取客户列表</summary>
    Task<string[]> GetExternalContactListAsync(string userId, CancellationToken ct = default);

    /// <summary>获取客户详情</summary>
    Task<GetExternalContactResponse> GetExternalContactAsync(string externalUserId, string? cursor = null, CancellationToken ct = default);

    /// <summary>批量获取客户详情</summary>
    Task<BatchGetExternalContactResponse> BatchGetExternalContactAsync(BatchGetByUserRequest request, CancellationToken ct = default);

    /// <summary>修改客户备注信息</summary>
    Task UpdateRemarkAsync(UpdateRemarkRequest request, CancellationToken ct = default);

    /// <summary>获取客户群列表</summary>
    Task<GetGroupChatListResponse> GetGroupChatListAsync(GetGroupChatListRequest request, CancellationToken ct = default);

    /// <summary>获取「联系客户统计」数据</summary>
    Task<GetUserBehaviorDataResponse> GetUserBehaviorDataAsync(GetUserBehaviorDataRequest request, CancellationToken ct = default);

    /// <summary>发送新客户欢迎语</summary>
    Task SendWelcomeMsgAsync(SendWelcomeMsgRequest request, CancellationToken ct = default);
}
