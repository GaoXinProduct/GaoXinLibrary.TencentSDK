using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>行驶证 OCR 响应（POST /cv/ocr/driving）</summary>
public class OcrDrivingResponse : WechatBaseResponse
{
    /// <summary>车牌号</summary>
    [JsonPropertyName("plate_num")] public string? PlateNum { get; set; }
    /// <summary>车辆类型</summary>
    [JsonPropertyName("vehicle_type")] public string? VehicleType { get; set; }
    /// <summary>所有人</summary>
    [JsonPropertyName("owner")] public string? Owner { get; set; }
    /// <summary>住址</summary>
    [JsonPropertyName("addr")] public string? Addr { get; set; }
    /// <summary>使用性质</summary>
    [JsonPropertyName("use_character")] public string? UseCharacter { get; set; }
    /// <summary>品牌型号</summary>
    [JsonPropertyName("model")] public string? Model { get; set; }
    /// <summary>车辆识别代号</summary>
    [JsonPropertyName("vin")] public string? Vin { get; set; }
    /// <summary>发动机号</summary>
    [JsonPropertyName("engine_num")] public string? EngineNum { get; set; }
    /// <summary>注册日期</summary>
    [JsonPropertyName("register_date")] public string? RegisterDate { get; set; }
    /// <summary>发证日期</summary>
    [JsonPropertyName("issue_date")] public string? IssueDate { get; set; }
}

