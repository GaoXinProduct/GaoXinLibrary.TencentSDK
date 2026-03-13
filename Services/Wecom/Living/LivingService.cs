using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Living;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>直播服务实现</summary>
public class LivingService : ILivingService
{
    private readonly WecomHttpClient _http;

    public LivingService(WecomHttpClient http) => _http = http;

    public async Task<string?> CreateLivingAsync(CreateLivingRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateLivingResponse>("/cgi-bin/living/create", request, ct);
        return resp.LivingId;
    }

    public async Task UpdateLivingAsync(UpdateLivingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/living/modify", request, ct);

    public async Task CancelLivingAsync(CancelLivingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/living/cancel", request, ct);

    public async Task DeleteReplayDataAsync(DeleteReplayDataRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/living/delete_replay_data", request, ct);

    public async Task<LivingInfo?> GetLivingInfoAsync(string livingId, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync<GetLivingInfoResponse>("/cgi-bin/living/get_living_info",
            new() { ["livingid"] = livingId }, ct);
        return resp.LivingInfo;
    }

    public async Task<GetUserLivingIdResponse> GetUserLivingIdAsync(GetUserLivingIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetUserLivingIdResponse>("/cgi-bin/living/get_user_all_livingid", request, ct);
}
