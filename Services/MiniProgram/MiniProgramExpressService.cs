using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>小程序物流助手服务实现</summary>
public class MiniProgramExpressService
{
    private readonly WechatHttpClient _http;
    public MiniProgramExpressService(WechatHttpClient http) => _http = http;

    /// <summary>获取支持的快递公司列表（GET /cgi-bin/express/business/delivery/getall）</summary>
    public Task<GetAllDeliveryResponse> GetAllDeliveryAsync(CancellationToken ct = default)
        => _http.GetAsync<GetAllDeliveryResponse>("/cgi-bin/express/business/delivery/getall", ct: ct);
    /// <summary>查询运单（POST /cgi-bin/express/business/order/get）</summary>
    public Task<GetExpressOrderResponse> GetOrderAsync(GetExpressOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetExpressOrderResponse>("/cgi-bin/express/business/order/get", request, ct);
    /// <summary>获取运单轨迹（POST /cgi-bin/express/business/path/get）</summary>
    public Task<GetExpressPathResponse> GetPathAsync(GetExpressPathRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetExpressPathResponse>("/cgi-bin/express/business/path/get", request, ct);
}
