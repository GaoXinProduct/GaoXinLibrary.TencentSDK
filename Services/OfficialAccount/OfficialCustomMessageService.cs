using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号客服消息服务实现</summary>
public class OfficialCustomMessageService
{
    private readonly WechatHttpClient _http;
    public OfficialCustomMessageService(WechatHttpClient http) => _http = http;

    /// <summary>发送客服消息</summary>
    public Task<OfficialCustomMessageResponse> SendAsync(OfficialCustomMessageRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialCustomMessageResponse>("/cgi-bin/message/custom/send", request, ct);

    /// <summary>下发客服输入状态</summary>
    public Task<OfficialSetTypingResponse> SetTypingAsync(OfficialSetTypingRequest request, CancellationToken ct = default)
        => _http.PostAsync<OfficialSetTypingResponse>("/cgi-bin/message/custom/typing", request, ct);

    /// <summary>添加客服帐号</summary>
    public Task<KfAccountOperationResponse> AddKfAccountAsync(AddKfAccountRequest request, CancellationToken ct = default)
        => _http.PostAsync<KfAccountOperationResponse>("/customservice/kfaccount/add", request, ct);

    /// <summary>修改客服帐号</summary>
    public Task<KfAccountOperationResponse> UpdateKfAccountAsync(UpdateKfAccountRequest request, CancellationToken ct = default)
        => _http.PostAsync<KfAccountOperationResponse>("/customservice/kfaccount/update", request, ct);

    /// <summary>删除客服帐号</summary>
    public Task<KfAccountOperationResponse> DeleteKfAccountAsync(string kfAccount, CancellationToken ct = default)
        => _http.PostAsync<KfAccountOperationResponse>("/customservice/kfaccount/del", new DeleteKfAccountRequest { KfAccount = kfAccount }, ct);

    /// <summary>获取所有客服帐号</summary>
    public Task<GetKfListResponse> GetKfListAsync(CancellationToken ct = default)
        => _http.GetAsync<GetKfListResponse>("/cgi-bin/customservice/getkflist", ct: ct);
}
