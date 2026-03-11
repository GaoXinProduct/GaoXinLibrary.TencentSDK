using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Living;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>直播服务实现</summary>
public class LivingService : ILivingService
{
    private readonly WecomHttpClient _http;

    public LivingService(WecomHttpClient http) => _http = http;

    public async Task<string?> CreateLivingAsync(string anchorUserId, string theme, long livingStart, long livingDuration, int type = 0, string? description = null, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateLivingResponse>("/cgi-bin/living/create",
            new { anchor_userid = anchorUserId, theme, living_start = livingStart, living_duration = livingDuration, type, description }, ct);
        return resp.LivingId;
    }

    public async Task UpdateLivingAsync(string livingId, string? theme = null, long? livingStart = null, long? livingDuration = null, string? description = null, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/living/modify",
            new { livingid = livingId, theme, living_start = livingStart, living_duration = livingDuration, description }, ct);

    public async Task CancelLivingAsync(string livingId, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/living/cancel",
            new { livingid = livingId }, ct);

    public async Task DeleteReplayDataAsync(string livingId, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/living/delete_replay_data",
            new { livingid = livingId }, ct);

    public async Task<LivingInfo?> GetLivingInfoAsync(string livingId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetLivingInfoResponse>("/cgi-bin/living/get_living_info",
            new() { ["livingid"] = livingId }, ct);
        return resp.LivingInfo;
    }

    public async Task<GetUserLivingIdResponse> GetUserLivingIdAsync(string userId, long beginTime, long endTime, string? cursor = null, int limit = 100, CancellationToken ct = default)
        => await _http.PostAsync<GetUserLivingIdResponse>("/cgi-bin/living/get_user_all_livingid",
            new { userid = userId, begin_time = beginTime, end_time = endTime, cursor = cursor ?? "", limit }, ct);
}
