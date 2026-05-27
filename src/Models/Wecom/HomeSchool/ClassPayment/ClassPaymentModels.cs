using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.HomeSchool.ClassPayment;

public record GetStudentPaymentResultRequest
{
    [JsonPropertyName("order_id")] public string OrderId { get; init; } = string.Empty;
    [JsonPropertyName("student_userid")] public string StudentUserid { get; init; } = string.Empty;
}

public class GetStudentPaymentResultResponse : WecomBaseResponse
{
    [JsonPropertyName("pay_time")] public long? PayTime { get; set; }
    [JsonPropertyName("pay_status")] public int PayStatus { get; set; }
}

public record GetOrderDetailRequest
{
    [JsonPropertyName("order_id")] public string OrderId { get; init; } = string.Empty;
}

public class GetOrderDetailResponse : WecomBaseResponse
{
    [JsonPropertyName("order_info")] public OrderInfo? OrderInfo { get; set; }
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