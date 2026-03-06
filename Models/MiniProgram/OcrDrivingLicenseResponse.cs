using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>驾驶证 OCR 响应（POST /cv/ocr/drivinglicense）</summary>
public class OcrDrivingLicenseResponse : WechatBaseResponse
{
    /// <summary>证号</summary>
    [JsonPropertyName("id_num")] public string? IdNum { get; set; }
    /// <summary>姓名</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }
    /// <summary>性别</summary>
    [JsonPropertyName("sex")] public string? Sex { get; set; }
    /// <summary>国籍</summary>
    [JsonPropertyName("nationality")] public string? Nationality { get; set; }
    /// <summary>住址</summary>
    [JsonPropertyName("addr")] public string? Addr { get; set; }
    /// <summary>出生日期</summary>
    [JsonPropertyName("birth_date")] public string? BirthDate { get; set; }
    /// <summary>初次领证日期</summary>
    [JsonPropertyName("issue_date")] public string? IssueDate { get; set; }
    /// <summary>准驾车型</summary>
    [JsonPropertyName("car_class")] public string? CarClass { get; set; }
    /// <summary>有效期起始日期</summary>
    [JsonPropertyName("valid_from")] public string? ValidFrom { get; set; }
    /// <summary>有效期截止日期</summary>
    [JsonPropertyName("valid_to")] public string? ValidTo { get; set; }
}

