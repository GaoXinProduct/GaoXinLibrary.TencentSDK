using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Living;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>直播服务实现</summary>
public sealed class LivingService
{
    private readonly WecomHttpClient _http;

    public LivingService(WecomHttpClient http) => _http = http;

    /// <summary>创建预约直播</summary>
    public async Task<string?> CreateLivingAsync(CreateLivingRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateLivingResponse>("/cgi-bin/living/create", request, ct).ConfigureAwait(false);
        return resp.LivingId;
    }

    /// <summary>修改预约直播</summary>
    public async Task UpdateLivingAsync(UpdateLivingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/living/modify", request, ct).ConfigureAwait(false);

    /// <summary>取消预约直播</summary>
    public async Task CancelLivingAsync(CancelLivingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/living/cancel", request, ct).ConfigureAwait(false);

    /// <summary>删除直播回放</summary>
    public async Task DeleteReplayDataAsync(DeleteReplayDataRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/living/delete_replay_data", request, ct).ConfigureAwait(false);

    /// <summary>获取直播详情</summary>
    public async Task<LivingInfo?> GetLivingInfoAsync(string livingId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetLivingInfoResponse>("/cgi-bin/living/get_living_info",
            new() { ["livingid"] = livingId }, ct).ConfigureAwait(false);
        return resp.LivingInfo;
    }

    /// <summary>获取成员直播ID列表</summary>
    public async Task<GetUserLivingIdResponse> GetUserLivingIdAsync(GetUserLivingIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetUserLivingIdResponse>("/cgi-bin/living/get_user_all_livingid", request, ct).ConfigureAwait(false);
}
