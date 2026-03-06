using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 小程序物流助手服务接口
/// </summary>
public interface IMiniProgramExpressService
{
    /// <summary>获取支持的快递公司列表（GET /cgi-bin/express/business/delivery/getall）</summary>
    Task<GetAllDeliveryResponse> GetAllDeliveryAsync(CancellationToken ct = default);
    /// <summary>查询运单（POST /cgi-bin/express/business/order/get）</summary>
    Task<GetExpressOrderResponse> GetOrderAsync(GetExpressOrderRequest request, CancellationToken ct = default);
    /// <summary>获取运单轨迹（POST /cgi-bin/express/business/path/get）</summary>
    Task<GetExpressPathResponse> GetPathAsync(GetExpressPathRequest request, CancellationToken ct = default);
}

