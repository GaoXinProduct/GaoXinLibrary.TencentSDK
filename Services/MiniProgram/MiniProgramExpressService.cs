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
    /// <summary>批量获取运单数据（POST /cgi-bin/express/business/order/batchget）</summary>
    public Task<BatchGetOrderResponse> BatchGetOrderAsync(BatchGetOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchGetOrderResponse>("/cgi-bin/express/business/order/batchget", request, ct);
    /// <summary>生成运单（POST /cgi-bin/express/business/order/add）</summary>
    public Task<AddOrderResponse> AddOrderAsync(AddOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddOrderResponse>("/cgi-bin/express/business/order/add", request, ct);
    /// <summary>取消运单（POST /cgi-bin/express/business/order/cancel）</summary>
    public Task<CancelOrderResponse> CancelOrderAsync(CancelOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<CancelOrderResponse>("/cgi-bin/express/business/order/cancel", request, ct);
    /// <summary>模拟更新订单状态（POST /cgi-bin/express/business/testupdateorder）</summary>
    public Task<TestUpdateOrderResponse> TestUpdateOrderAsync(TestUpdateOrderRequest request, CancellationToken ct = default)
        => _http.PostAsync<TestUpdateOrderResponse>("/cgi-bin/express/business/testupdateorder", request, ct);
    /// <summary>获取电子面单余额（POST /cgi-bin/express/business/delivery/getquota）</summary>
    public Task<GetQuotaResponse> GetQuotaAsync(GetQuotaRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetQuotaResponse>("/cgi-bin/express/business/delivery/getquota", request, ct);
    /// <summary>配置面单打印员（POST /cgi-bin/express/business/printer/update）</summary>
    public Task<UpdatePrinterResponse> UpdatePrinterAsync(UpdatePrinterRequest request, CancellationToken ct = default)
        => _http.PostAsync<UpdatePrinterResponse>("/cgi-bin/express/business/printer/update", request, ct);
    /// <summary>获取打印员（POST /cgi-bin/express/business/printer/get）</summary>
    public Task<GetPrinterResponse> GetPrinterAsync(GetPrinterRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetPrinterResponse>("/cgi-bin/express/business/printer/get", request, ct);
    /// <summary>绑定/解绑物流账号（POST /cgi-bin/express/business/account/bind）</summary>
    public Task<BindAccountResponse> BindAccountAsync(BindAccountRequest request, CancellationToken ct = default)
        => _http.PostAsync<BindAccountResponse>("/cgi-bin/express/business/account/bind", request, ct);
    /// <summary>获取所有绑定的物流账号（POST /cgi-bin/express/business/account/getall）</summary>
    public Task<GetAllAccountResponse> GetAllAccountAsync(GetAllAccountRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetAllAccountResponse>("/cgi-bin/express/business/account/getall", request, ct);
}
