using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CustomerMoments;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public class CustomerMomentsService
{
    private readonly WecomHttpClient _http;

    public CustomerMomentsService(WecomHttpClient http) => _http = http;

    public async Task<CreateMomentsTaskResponse> CreateCustomerMomentsTaskAsync(
        CreateMomentsTaskRequest request,
        CancellationToken ct = default)
        => await _http.PostAsync<CreateMomentsTaskResponse>(
            "/cgi-bin/externalcontact/add_moment_task", request, ct);

    public async Task<StopMomentsTaskResponse> StopCustomerMomentsTaskAsync(
        StopMomentsTaskRequest request,
        CancellationToken ct = default)
        => await _http.PostAsync<StopMomentsTaskResponse>(
            "/cgi-bin/externalcontact/cancel_moment_task", request, ct);

    public async Task<GetMomentsTasksResponse> GetCustomerMomentsTasksAsync(
        GetMomentsTasksRequest request,
        CancellationToken ct = default)
        => await _http.PostAsync<GetMomentsTasksResponse>(
            "/cgi-bin/externalcontact/get_moment_list", request, ct);

    public async Task<GetMomentsRuleGroupResponse> GetCustomerMomentsFilterListAsync(
        GetMomentsRuleGroupRequest request,
        CancellationToken ct = default)
        => await _http.PostAsync<GetMomentsRuleGroupResponse>(
            "/cgi-bin/externalcontact/moment_strategy/list", request, ct);

    public async Task<GetMomentsTasksResponse> GetCustomerMomentsTaskDetailAsync(
        string momentId,
        string? cursor = null,
        int? limit = null,
        CancellationToken ct = default)
    {
        var request = new { moment_id = momentId, cursor, limit };
        return await _http.PostAsync<GetMomentsTasksResponse>(
            "/cgi-bin/externalcontact/get_moment_task", request, ct);
    }
}