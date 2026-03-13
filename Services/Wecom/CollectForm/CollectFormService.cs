using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>收集表服务实现</summary>
public class CollectFormService : ICollectFormService
{
    private readonly WecomHttpClient _http;

    public CollectFormService(WecomHttpClient http) => _http = http;

    public async Task<CreateCollectFormResponse> CreateCollectFormAsync(CollectFormOperationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateCollectFormResponse>("/cgi-bin/wedoc/create_collect", request, ct);

    public async Task ModifyCollectFormAsync(CollectFormOperationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/modify_collect", request, ct);

    public async Task<CollectFormInfo?> GetCollectFormAsync(GetCollectFormRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCollectFormResponse>("/cgi-bin/wedoc/get_collect", request, ct);
        return resp.FormInfo;
    }

    public async Task<GetCollectAnswerResponse> GetCollectAnswerAsync(GetCollectAnswerRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetCollectAnswerResponse>("/cgi-bin/wedoc/get_form_answer", request, ct);
}
