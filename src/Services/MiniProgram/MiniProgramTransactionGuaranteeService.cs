using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>
/// 小程序交易保障服务实现
/// <para>
/// 提供交易评价管理、投诉处理等接口。
/// </para>
/// </summary>
public sealed class MiniProgramTransactionGuaranteeService
{
    private readonly WechatHttpClient _http;

    /// <summary>
    /// 初始化交易保障服务
    /// </summary>
    /// <param name="http">微信HTTP客户端</param>
    public MiniProgramTransactionGuaranteeService(WechatHttpClient http) => _http = http;

    // ==================== 基础能力 ====================

    /// <summary>
    /// 获取小程序交易体验分违规记录（POST /wxa/guarantee/get_penalty_list）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetPenaltyListResponse> GetPenaltyListAsync(GetPenaltyListRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetPenaltyListResponse>("/wxa/guarantee/get_penalty_list", request, ct);

    /// <summary>
    /// 获取交易保障标状态（POST /wxa/guarantee/get_guarantee_status）
    /// </summary>
    /// <param name="ct">取消令牌</param>
    public Task<GetGuaranteeStatusResponse> GetGuaranteeStatusAsync(CancellationToken ct = default)
        => _http.PostAsync<GetGuaranteeStatusResponse>("/wxa/guarantee/get_guarantee_status", EmptyRequest.Instance, ct);

    // ==================== 交易评价管理 ====================

    /// <summary>
    /// 查询评价列表（POST /wxa/comment/get_comment_list）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetCommentListResponse> GetCommentListAsync(GetCommentListRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetCommentListResponse>("/wxa/comment/get_comment_list", request, ct);

    /// <summary>
    /// 查询评论列表（POST /wxa/comment/get_comment_reply_list）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetCommentReplyListResponse> GetCommentReplyListAsync(GetCommentReplyListRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetCommentReplyListResponse>("/wxa/comment/get_comment_reply_list", request, ct);

    /// <summary>
    /// 查询评价详情（POST /wxa/comment/get_comment_info）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetCommentInfoResponse> GetCommentInfoAsync(GetCommentInfoRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetCommentInfoResponse>("/wxa/comment/get_comment_info", request, ct);

    /// <summary>
    /// 创建评论（POST /wxa/comment/add_reply）
    /// <para>商家回复用户评价。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<AddReplyResponse> AddReplyAsync(AddReplyRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddReplyResponse>("/wxa/comment/add_reply", request, ct);

    /// <summary>
    /// 删除评论（POST /wxa/comment/delete_reply）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<DeleteReplyResponse> DeleteReplyAsync(DeleteReplyRequest request, CancellationToken ct = default)
        => _http.PostAsync<DeleteReplyResponse>("/wxa/comment/delete_reply", request, ct);

    /// <summary>
    /// 创建回复（POST /wxa/comment/add_comment_reply）
    /// <para>针对用户评论的回复。</para>
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<AddCommentReplyResponse> AddCommentReplyAsync(AddCommentReplyRequest request, CancellationToken ct = default)
        => _http.PostAsync<AddCommentReplyResponse>("/wxa/comment/add_comment_reply", request, ct);

    /// <summary>
    /// 删除回复（POST /wxa/comment/delete_comment_reply）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<DeleteCommentReplyResponse> DeleteCommentReplyAsync(DeleteCommentReplyRequest request, CancellationToken ct = default)
        => _http.PostAsync<DeleteCommentReplyResponse>("/wxa/comment/delete_comment_reply", request, ct);

    /// <summary>
    /// 重置Api客服quota（POST /wxa/comment/reset_api_kf_quota）
    /// </summary>
    /// <param name="ct">取消令牌</param>
    public Task<ResetApiKfQuotaResponse> ResetApiKfQuotaAsync(CancellationToken ct = default)
        => _http.PostAsync<ResetApiKfQuotaResponse>("/wxa/comment/reset_api_kf_quota", EmptyRequest.Instance, ct);

    /// <summary>
    /// 确认和解（POST /wxa/comment/confirm_compromise）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<ConfirmCompromiseResponse> ConfirmCompromiseAsync(ConfirmCompromiseRequest request, CancellationToken ct = default)
        => _http.PostAsync<ConfirmCompromiseResponse>("/wxa/comment/confirm_compromise", request, ct);

    // ==================== 交易投诉处理 ====================

    /// <summary>
    /// 商家回应投诉（POST /wxa/feedback/respond_complaint）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<RespondComplaintResponse> RespondComplaintAsync(RespondComplaintRequest request, CancellationToken ct = default)
        => _http.PostAsync<RespondComplaintResponse>("/wxa/feedback/respond_complaint", request, ct);

    /// <summary>
    /// 商家补充凭证（POST /wxa/feedback/supply_proof）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<SupplyProofResponse> SupplyProofAsync(SupplyProofRequest request, CancellationToken ct = default)
        => _http.PostAsync<SupplyProofResponse>("/wxa/feedback/supply_proof", request, ct);

    /// <summary>
    /// 商家提交退款凭证（POST /wxa/feedback/submit_refund）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<SubmitRefundResponse> SubmitRefundAsync(SubmitRefundRequest request, CancellationToken ct = default)
        => _http.PostAsync<SubmitRefundResponse>("/wxa/feedback/submit_refund", request, ct);

    /// <summary>
    /// 查询投诉单详情（POST /wxa/feedback/get_order_detail）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<GetOrderDetailResponse> GetOrderDetailAsync(GetOrderDetailRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetOrderDetailResponse>("/wxa/feedback/get_order_detail", request, ct);

    /// <summary>
    /// 商家申诉（POST /wxa/feedback/busi_appeal）
    /// </summary>
    /// <param name="request">请求参数</param>
    /// <param name="ct">取消令牌</param>
    public Task<BusiAppealResponse> BusiAppealAsync(BusiAppealRequest request, CancellationToken ct = default)
        => _http.PostAsync<BusiAppealResponse>("/wxa/feedback/busi_appeal", request, ct);
}
