using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay;
using GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion;
using GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.ExternalAccount;
using GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.NormalPay;
using GaoXinLibrary.TencentSDK.Wecom.Models.CorpPay.Expansion.Refund;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>企业支付服务实现</summary>
/// <remarks>
/// <see cref="GetBillListAsync"/> 和 <see cref="GetProjectBillListAsync"/> 均调用同一企业微信 API 端点
/// <c>/cgi-bin/externalpay/get_bill_list</c>，通过不同的请求体字段区分查询方式。
/// </remarks>
public class CorpPayService
{
    private readonly WecomHttpClient _http;

    public CorpPayService(WecomHttpClient http) => _http = http;

    /// <summary>
    /// 获取对外收款记录（按时间范围查询）
    /// <para>调用接口: <c>POST /cgi-bin/externalpay/get_bill_list</c></para>
    /// </summary>
    public async Task<GetBillListResponse> GetBillListAsync(GetBillListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetBillListResponse>("/cgi-bin/externalpay/get_bill_list", request, ct);

    /// <summary>
    /// 获取收款项目的商户单号（按项目ID查询）
    /// <para>调用接口: <c>POST /cgi-bin/externalpay/get_bill_list</c>，与 <see cref="GetBillListAsync"/> 共用同一端点，仅查询参数不同。</para>
    /// </summary>
    public async Task<GetBillListResponse> GetProjectBillListAsync(GetProjectBillListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetBillListResponse>("/cgi-bin/externalpay/get_bill_list", request, ct);

    public async Task<SendRedpackResponse> SendRedpackAsync(SendRedpackRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SendRedpackResponse>("/cgi-bin/externalpay/send_redpack", request, ct);

    public async Task<GetRedpackRecordResponse> GetRedpackRecordAsync(GetRedpackRecordRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetRedpackRecordResponse>("/cgi-bin/externalpay/get_redpack_record", request, ct);

    public async Task<PayToEmployeeResponse> PayToEmployeeAsync(PayToEmployeeRequest request, CancellationToken ct = default)
        => await _http.PostAsync<PayToEmployeeResponse>("/cgi-bin/externalpay/pay_to_employee", request, ct);

    public async Task<GetPayToEmployeeRecordResponse> GetPayToEmployeeRecordAsync(GetPayToEmployeeRecordRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetPayToEmployeeRecordResponse>("/cgi-bin/externalpay/get_pay_to_employee_record", request, ct);

    public async Task<ReceiveFromEmployeeResponse> ReceiveFromEmployeeAsync(ReceiveFromEmployeeRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ReceiveFromEmployeeResponse>("/cgi-bin/externalpay/receive_from_employee", request, ct);

    public async Task<GetReceiveFromEmployeeRecordResponse> GetReceiveFromEmployeeRecordAsync(GetReceiveFromEmployeeRecordRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetReceiveFromEmployeeRecordResponse>("/cgi-bin/externalpay/get_receive_from_employee_record", request, ct);

    public async Task<GetExternalPaymentRecordResponse> GetExternalPaymentRecordAsync(GetExternalPaymentRecordRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetExternalPaymentRecordResponse>("/cgi-bin/externalpay/get_external_payment_record", request, ct);

    public async Task<GetMerchantOrderResponse> GetMerchantOrderAsync(GetMerchantOrderRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetMerchantOrderResponse>("/cgi-bin/externalpay/get_merchant_order", request, ct);

    public async Task<GetFundFlowResponse> GetFundFlowAsync(GetFundFlowRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetFundFlowResponse>("/cgi-bin/externalpay/get_fund_flow", request, ct);

    public async Task<SubmitCreateAccountResponse> SubmitCreateAccountAsync(SubmitCreateAccountRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SubmitCreateAccountResponse>("/cgi-bin/externalpay/submit_create_account", request, ct);

    public async Task<QueryCreateAccountStatusResponse> QueryCreateAccountStatusAsync(QueryCreateAccountStatusRequest request, CancellationToken ct = default)
        => await _http.PostAsync<QueryCreateAccountStatusResponse>("/cgi-bin/externalpay/query_create_account_status", request, ct);

    public async Task<SubmitAccountImageResponse> SubmitAccountImageAsync(SubmitAccountImageRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SubmitAccountImageResponse>("/cgi-bin/externalpay/submit_account_image", request, ct);

    public async Task<MiniProgramOrderResponse> CreateMiniProgramOrderAsync(MiniProgramOrderRequest request, CancellationToken ct = default)
        => await _http.PostAsync<MiniProgramOrderResponse>("/cgi-bin/externalpay/mini_program_order", request, ct);

    public async Task<QueryOrderResponse> QueryOrderAsync(QueryOrderRequest request, CancellationToken ct = default)
        => await _http.PostAsync<QueryOrderResponse>("/cgi-bin/externalpay/query_order", request, ct);

    public async Task<CloseOrderResponse> CloseOrderAsync(CloseOrderRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CloseOrderResponse>("/cgi-bin/externalpay/close_order", request, ct);

    public async Task<GetPaySignatureResponse> GetPaySignatureAsync(GetPaySignatureRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetPaySignatureResponse>("/cgi-bin/externalpay/get_pay_signature", request, ct);

    public async Task<ApplyRefundResponse> ApplyRefundAsync(ApplyRefundRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ApplyRefundResponse>("/cgi-bin/externalpay/apply_refund", request, ct);

    public async Task<QueryRefundResponse> QueryRefundAsync(QueryRefundRequest request, CancellationToken ct = default)
        => await _http.PostAsync<QueryRefundResponse>("/cgi-bin/externalpay/query_refund", request, ct);
}
