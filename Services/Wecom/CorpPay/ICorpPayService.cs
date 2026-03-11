using GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>企业支付服务接口</summary>
public interface ICorpPayService
{
    /// <summary>获取对外收款记录</summary>
    Task<GetBillListResponse> GetBillListAsync(long beginTime, long endTime, string? payeeUserId = null, string? cursor = null, int limit = 100, CancellationToken ct = default);

    /// <summary>获取收款项目的商户单号</summary>
    Task<GetBillListResponse> GetProjectBillListAsync(string projectId, string? cursor = null, int limit = 100, CancellationToken ct = default);
}
