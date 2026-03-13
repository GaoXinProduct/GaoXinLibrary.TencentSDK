using GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>电子发票服务接口</summary>
public interface IInvoiceService
{
    /// <summary>查询电子发票</summary>
    Task<InvoiceInfo?> GetInvoiceInfoAsync(GetInvoiceInfoRequest request, CancellationToken ct = default);

    /// <summary>批量查询电子发票</summary>
    Task<InvoiceInfo[]> BatchGetInvoiceInfoAsync(BatchGetInvoiceInfoRequest request, CancellationToken ct = default);

    /// <summary>更新发票状态</summary>
    Task UpdateInvoiceStatusAsync(UpdateInvoiceStatusRequest request, CancellationToken ct = default);

    /// <summary>批量更新发票状态</summary>
    Task BatchUpdateInvoiceStatusAsync(BatchUpdateInvoiceStatusRequest request, CancellationToken ct = default);
}
