using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>身份证 OCR 响应（POST /cv/ocr/idcard）</summary>
public class OcrIdCardResponse : WechatBaseResponse
{
    /// <summary>正面/反面（Front / Back）</summary>
    [JsonPropertyName("type")] public string? Type { get; set; }
    /// <summary>姓名</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }
    /// <summary>身份证号</summary>
    [JsonPropertyName("id")] public string? Id { get; set; }
    /// <summary>地址</summary>
    [JsonPropertyName("addr")] public string? Addr { get; set; }
    /// <summary>性别</summary>
    [JsonPropertyName("gender")] public string? Gender { get; set; }
    /// <summary>民族</summary>
    [JsonPropertyName("nationality")] public string? Nationality { get; set; }
    /// <summary>签发机关（反面）</summary>
    [JsonPropertyName("authority")] public string? Authority { get; set; }
    /// <summary>有效期起始日期（反面）</summary>
    [JsonPropertyName("valid_date")] public string? ValidDate { get; set; }
}

