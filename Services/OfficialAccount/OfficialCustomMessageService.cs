using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号客服消息服务实现</summary>
public class OfficialCustomMessageService : IOfficialCustomMessageService
{
    private readonly WechatHttpClient _http;
    public OfficialCustomMessageService(WechatHttpClient http) => _http = http;

    public Task<OfficialCustomMessageResponse> SendAsync(OfficialCustomMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialCustomMessageResponse>("/cgi-bin/message/custom/send", request, ct);

    public Task<OfficialSetTypingResponse> SetTypingAsync(OfficialSetTypingRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialSetTypingResponse>("/cgi-bin/message/custom/typing", request, ct);

    public Task<KfAccountOperationResponse> AddKfAccountAsync(AddKfAccountRequest request, CancellationToken ct = default)
        => _http.PostAsync<KfAccountOperationResponse>("/customservice/kfaccount/add", request, ct);

    public Task<KfAccountOperationResponse> UpdateKfAccountAsync(UpdateKfAccountRequest request, CancellationToken ct = default)
        => _http.PostAsync<KfAccountOperationResponse>("/customservice/kfaccount/update", request, ct);

    public Task<KfAccountOperationResponse> DeleteKfAccountAsync(string kfAccount, CancellationToken ct = default)
        => _http.PostAsync<KfAccountOperationResponse>("/customservice/kfaccount/del", new DeleteKfAccountRequest { KfAccount = kfAccount }, ct);

    public Task<GetKfListResponse> GetKfListAsync(CancellationToken ct = default)
        => _http.GetAsync<GetKfListResponse>("/cgi-bin/customservice/getkflist", ct: ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号基础消息服务（群发 / 模板扩展）

