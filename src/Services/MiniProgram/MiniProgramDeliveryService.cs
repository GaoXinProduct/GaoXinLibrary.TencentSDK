using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序即时配送服务实现</summary>
public sealed class MiniProgramDeliveryService
{
    private readonly WechatHttpClient _http;

    public MiniProgramDeliveryService(WechatHttpClient http) => _http = http;

    /// <summary>获取已支持的配送公司列表（POST /cgi-bin/express/delivery/open/getall）</summary>
    public Task<GetAllImmeDeliveryResponse> GetAllImmeDeliveryAsync(CancellationToken ct = default)
        => _http.PostAsync<GetAllImmeDeliveryResponse>("/cgi-bin/express/delivery/open/getall", EmptyRequest.Instance, ct);

    /// <summary>预下配送单（POST /cgi-bin/express/delivery/open/preadd）</summary>
    public Task<PreAddOrderResponse> PreAddOrderAsync(PreAddOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<PreAddOrderResponse>("/cgi-bin/express/delivery/open/preadd", request, ct);

    /// <summary>拉取已绑定账号（POST /cgi-bin/express/delivery/open/getbindaccount）</summary>
    public Task<GetBindAccountResponse> GetBindAccountAsync(GetBindAccountRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetBindAccountResponse>("/cgi-bin/express/delivery/open/getbindaccount", request, ct);

    /// <summary>预取消配送单（POST /cgi-bin/express/delivery/open/precancel）</summary>
    public Task<PreCancelOrderResponse> PreCancelOrderAsync(PreCancelOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<PreCancelOrderResponse>("/cgi-bin/express/delivery/open/precancel", request, ct);

    /// <summary>申请开通即时配送（POST /cgi-bin/express/delivery/open/open_delivery）</summary>
    public Task<OpenDeliveryResponse> OpenDeliveryAsync(OpenDeliveryRequest request, CancellationToken ct = default)
        => _http.PostAsync<OpenDeliveryResponse>("/cgi-bin/express/delivery/open/open_delivery", request, ct);

    /// <summary>发起绑定请求（POST /cgi-bin/express/delivery/open/bind_local_account）</summary>
    public Task<BindLocalAccountResponse> BindLocalAccountAsync(BindLocalAccountRequest request, CancellationToken ct = default)
        => _http.PostAsync<BindLocalAccountResponse>("/cgi-bin/express/delivery/open/bind_local_account", request, ct);

    /// <summary>重新下单（POST /cgi-bin/express/delivery/open/re_order）</summary>
    public Task<ReOrderResponse> ReOrderAsync(ReOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<ReOrderResponse>("/cgi-bin/express/delivery/open/re_order", request, ct);

    /// <summary>模拟更新配送单状态（POST /cgi-bin/express/delivery/open/realmock_update_order）</summary>
    public Task<RealMockUpdateOrderResponse> RealMockUpdateOrderAsync(RealMockUpdateOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<RealMockUpdateOrderResponse>("/cgi-bin/express/delivery/open/realmock_update_order", request, ct);

    /// <summary>模拟配送公司更新配送单状态（POST /cgi-bin/express/delivery/open/mock_update_order）</summary>
    public Task<MockUpdateOrderResponse> MockUpdateOrderAsync(MockUpdateOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<MockUpdateOrderResponse>("/cgi-bin/express/delivery/open/mock_update_order", request, ct);

    /// <summary>拉取配送单信息（POST /cgi-bin/express/delivery/open/get_local_order）</summary>
    public Task<GetLocalOrderResponse> GetLocalOrderAsync(GetLocalOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetLocalOrderResponse>("/cgi-bin/express/delivery/open/get_local_order", request, ct);

    /// <summary>异常件退回商家确认（POST /cgi-bin/express/delivery/open/abnormal_confirm）</summary>
    public Task<AbnormalConfirmResponse> AbnormalConfirmAsync(AbnormalConfirmRequest request, CancellationToken ct = default)
        => _http.PostAsync<AbnormalConfirmResponse>("/cgi-bin/express/delivery/open/abnormal_confirm", request, ct);

    /// <summary>取消配送单（POST /cgi-bin/express/delivery/open/cancel_local_order）</summary>
    public Task<CancelLocalOrderResponse> CancelLocalOrderAsync(CancelLocalOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<CancelLocalOrderResponse>("/cgi-bin/express/delivery/open/cancel_local_order", request, ct);

    /// <summary>添加小费（POST /cgi-bin/express/delivery/open/add_tips）</summary>
    public Task<AddTipsResponse> AddTipsAsync(AddTipsRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddTipsResponse>("/cgi-bin/express/delivery/open/add_tips", request, ct);

    /// <summary>添加配送单（POST /cgi-bin/express/delivery/open/add_local_order）</summary>
    public Task<AddLocalOrderResponse> AddLocalOrderAsync(AddLocalOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddLocalOrderResponse>("/cgi-bin/express/delivery/open/add_local_order", request, ct);
}