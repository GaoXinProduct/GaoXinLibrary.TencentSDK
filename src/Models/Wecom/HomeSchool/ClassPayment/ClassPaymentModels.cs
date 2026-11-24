using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.ClassPayment;

public record GetStudentPaymentResultRequest
{
    /// <summary>班级收款项目 ID。</summary>
    [JsonPropertyName("payment_id")] public string PaymentId { get; init; } = string.Empty;
    [Obsolete("请传入班级收款项目 PaymentId。"), JsonIgnore] public string OrderId { get; init; } = string.Empty;
    /// <summary>可选的本地结果筛选条件。</summary>
    [JsonIgnore] public string StudentUserid { get; init; } = string.Empty;
}

public class GetStudentPaymentResultResponse : WecomBaseResponse
{
    [JsonPropertyName("project_name")] public string? ProjectName { get; set; }
    [JsonPropertyName("amount")] public int Amount { get; set; }
    [JsonPropertyName("payment_result")] public StudentPaymentResult[]? PaymentResult { get; set; }
    [Obsolete("付款时间由 GetOrderDetailAsync 返回。"), JsonIgnore] public long? PayTime { get; set; }
    /// <summary>传入 StudentUserid 时，对应学生的付款状态。</summary>
    [JsonIgnore] public int PayStatus { get; set; }
}

public sealed record StudentPaymentResult
{
    [JsonPropertyName("student_userid")] public string? StudentUserid { get; init; }
    [JsonPropertyName("trade_state")] public int TradeState { get; init; }
    [JsonPropertyName("trade_no")] public string? TradeNo { get; init; }
    [JsonPropertyName("payer_parent_userid")] public string? PayerParentUserid { get; init; }
}

public record GetOrderDetailRequest
{
    [JsonPropertyName("payment_id")] public string PaymentId { get; init; } = string.Empty;
    [JsonPropertyName("trade_no")] public string TradeNo { get; init; } = string.Empty;
    [JsonIgnore] public string OrderId { get => TradeNo; init => TradeNo = value; }
}

public class GetOrderDetailResponse : WecomBaseResponse
{
    [JsonPropertyName("transaction_id")] public string? TransactionId { get; set; }
    [JsonPropertyName("pay_time")] public long? PayTime { get; set; }
    [Obsolete("请读取 TransactionId 和 PayTime。"), JsonIgnore] public OrderInfo? OrderInfo { get; set; }
}

public record OrderInfo
{
    [JsonPropertyName("order_id")] public string? OrderId { get; init; }
    [JsonPropertyName("order_name")] public string? OrderName { get; init; }
    [JsonPropertyName("total_amount")] public int TotalAmount { get; init; }
    [JsonPropertyName("pay_amount")] public int PayAmount { get; init; }
    [JsonPropertyName("status")] public int Status { get; init; }
    [JsonPropertyName("create_time")] public long CreateTime { get; init; }
}
