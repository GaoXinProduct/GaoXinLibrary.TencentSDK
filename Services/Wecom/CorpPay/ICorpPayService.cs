using GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 企业支付服务接口
/// <para>
/// <see cref="GetBillListAsync"/> 和 <see cref="GetProjectBillListAsync"/> 均调用
/// <c>/cgi-bin/externalpay/get_bill_list</c> 接口，通过不同的请求参数区分查询方式：<br/>
/// • <see cref="GetBillListAsync"/>: 按时间范围查询收款记录（可选指定收款人）<br/>
/// • <see cref="GetProjectBillListAsync"/>: 按收款项目ID查询商户单号
/// </para>
/// </summary>
public interface ICorpPayService
{
    /// <summary>
    /// 获取对外收款记录（按时间范围查询）
    /// <para>调用接口: <c>POST /cgi-bin/externalpay/get_bill_list</c></para>
    /// </summary>
    Task<GetBillListResponse> GetBillListAsync(GetBillListRequest request, CancellationToken ct = default);

    /// <summary>
    /// 获取收款项目的商户单号（按项目ID查询）
    /// <para>调用接口: <c>POST /cgi-bin/externalpay/get_bill_list</c>，与 <see cref="GetBillListAsync"/> 共用同一端点，仅查询参数不同。</para>
    /// </summary>
    Task<GetBillListResponse> GetProjectBillListAsync(GetProjectBillListRequest request, CancellationToken ct = default);
}
