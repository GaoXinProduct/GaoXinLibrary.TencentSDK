using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.VisitorAssistant;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public sealed class VisitorAssistantService
{
    private readonly WecomHttpClient _http;

    public VisitorAssistantService(WecomHttpClient http) => _http = http;

    public async Task<CreateVisitorLinkResponse> CreateVisitorLinkAsync(
        CreateVisitorLinkRequest request,
        CancellationToken ct = default)
        => await _http.PostAsync<CreateVisitorLinkResponse>(
            "/cgi-bin/externalcontact/customer_acquisition/create_link", request, ct).ConfigureAwait(false);

    public async Task<GetVisitorLinkResponse> GetVisitorLinkAsync(
        GetVisitorLinkRequest request,
        CancellationToken ct = default)
        => await _http.PostAsync<GetVisitorLinkResponse>(
            "/cgi-bin/externalcontact/customer_acquisition/get", request, ct).ConfigureAwait(false);

    public async Task<UpdateVisitorLinkResponse> UpdateVisitorLinkAsync(
        UpdateVisitorLinkRequest request,
        CancellationToken ct = default)
        => await _http.PostAsync<UpdateVisitorLinkResponse>(
            "/cgi-bin/externalcontact/customer_acquisition/update_link", request, ct).ConfigureAwait(false);

    public async Task<DeleteVisitorLinkResponse> DeleteVisitorLinkAsync(
        DeleteVisitorLinkRequest request,
        CancellationToken ct = default)
        => await _http.PostAsync<DeleteVisitorLinkResponse>(
            "/cgi-bin/externalcontact/customer_acquisition/delete_link", request, ct).ConfigureAwait(false);

    public async Task<GetVisitorCustomerInfoResponse> GetVisitorCustomerInfoAsync(
        GetVisitorCustomerInfoRequest request,
        CancellationToken ct = default)
        => await _http.PostAsync<GetVisitorCustomerInfoResponse>(
            "/cgi-bin/externalcontact/customer_acquisition/customer", request, ct).ConfigureAwait(false);

    public async Task<GetVisitorQuotaResponse> GetVisitorQuotaAsync(
        CancellationToken ct = default)
        => await _http.GetAsync<GetVisitorQuotaResponse>(
               "/cgi-bin/externalcontact/customer_acquisition_quota", ct: ct).ConfigureAwait(false);

    public async Task<GetVisitorLinkListResponse> GetVisitorLinkListAsync(
        GetVisitorLinkListRequest request,
        CancellationToken ct = default)
        => await _http.PostAsync<GetVisitorLinkListResponse>(
            "/cgi-bin/externalcontact/customer_acquisition/list_link", request, ct).ConfigureAwait(false);
}