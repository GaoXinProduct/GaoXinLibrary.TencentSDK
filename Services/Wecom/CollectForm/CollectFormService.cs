using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>收集表服务实现</summary>
public class CollectFormService : ICollectFormService
{
    private readonly WecomHttpClient _http;

    public CollectFormService(WecomHttpClient http) => _http = http;

    public async Task<CreateCollectFormResponse> CreateCollectFormAsync(CollectFormInfo form, CancellationToken ct = default)
        => await _http.PostAsync<CreateCollectFormResponse>("/cgi-bin/wedoc/create_collect",
            new { form_info = form }, ct);

    public async Task ModifyCollectFormAsync(CollectFormInfo form, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/modify_collect",
            new { form_info = form }, ct);

    public async Task<CollectFormInfo?> GetCollectFormAsync(string formId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCollectFormResponse>("/cgi-bin/wedoc/get_collect",
            new { formid = formId }, ct);
        return resp.FormInfo;
    }

    public async Task<GetCollectAnswerResponse> GetCollectAnswerAsync(string formId, string? cursor = null, int limit = 100, CancellationToken ct = default)
        => await _http.PostAsync<GetCollectAnswerResponse>("/cgi-bin/wedoc/get_form_answer",
            new { formid = formId, cursor = cursor ?? "", limit }, ct);
}
