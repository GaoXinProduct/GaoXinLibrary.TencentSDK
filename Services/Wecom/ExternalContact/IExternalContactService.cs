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
    Task<BatchGetExternalContactResponse> BatchGetExternalContactAsync(string[] userIdList, string? cursor = null, int limit = 100, CancellationToken ct = default);

    /// <summary>修改客户备注信息</summary>
    Task UpdateRemarkAsync(string userId, string externalUserId, string? remark = null, string? description = null, CancellationToken ct = default);

    /// <summary>获取客户群列表</summary>
    Task<GetGroupChatListResponse> GetGroupChatListAsync(int statusFilter = 0, string? cursor = null, int limit = 100, CancellationToken ct = default);

    /// <summary>获取「联系客户统计」数据</summary>
    Task<GetUserBehaviorDataResponse> GetUserBehaviorDataAsync(string[] userIdList, long startTime, long endTime, CancellationToken ct = default);

    /// <summary>发送新客户欢迎语</summary>
    Task SendWelcomeMsgAsync(string welcomeCode, object text, object? image = null, object? link = null, object? miniProgram = null, CancellationToken ct = default);
}
