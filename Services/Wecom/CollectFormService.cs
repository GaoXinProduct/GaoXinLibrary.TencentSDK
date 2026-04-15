using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CollectForm;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>收集表服务实现</summary>
public class CollectFormService
{
    private readonly WecomHttpClient _http;

    public CollectFormService(WecomHttpClient http) => _http = http;

    /// <summary>创建收集表</summary>
    public async Task<CreateCollectFormResponse> CreateCollectFormAsync(CollectFormOperationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateCollectFormResponse>("/cgi-bin/wedoc/create_collect", request, ct);

    /// <summary>修改收集表</summary>
    public async Task ModifyCollectFormAsync(CollectFormOperationRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/modify_collect", request, ct);

    /// <summary>获取收集表详情</summary>
    public async Task<CollectFormInfo?> GetCollectFormAsync(GetCollectFormRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetCollectFormResponse>("/cgi-bin/wedoc/get_collect", request, ct);
        return resp.FormInfo;
    }

    /// <summary>获取收集表答案</summary>
    public async Task<GetCollectAnswerResponse> GetCollectAnswerAsync(GetCollectAnswerRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetCollectAnswerResponse>("/cgi-bin/wedoc/get_form_answer", request, ct);
}
