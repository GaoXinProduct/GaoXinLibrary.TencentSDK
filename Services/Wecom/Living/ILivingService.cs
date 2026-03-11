using GaoXinLibrary.TencentSDK.Wecom.Models.Living;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>直播服务接口</summary>
public interface ILivingService
{
    /// <summary>创建预约直播</summary>
    Task<string?> CreateLivingAsync(string anchorUserId, string theme, long livingStart, long livingDuration, int type = 0, string? description = null, CancellationToken ct = default);

    /// <summary>修改预约直播</summary>
    Task UpdateLivingAsync(string livingId, string? theme = null, long? livingStart = null, long? livingDuration = null, string? description = null, CancellationToken ct = default);

    /// <summary>取消预约直播</summary>
    Task CancelLivingAsync(string livingId, CancellationToken ct = default);

    /// <summary>删除直播回放</summary>
    Task DeleteReplayDataAsync(string livingId, CancellationToken ct = default);

    /// <summary>获取直播详情</summary>
    Task<LivingInfo?> GetLivingInfoAsync(string livingId, CancellationToken ct = default);

    /// <summary>获取成员直播ID列表</summary>
    Task<GetUserLivingIdResponse> GetUserLivingIdAsync(string userId, long beginTime, long endTime, string? cursor = null, int limit = 100, CancellationToken ct = default);
}
