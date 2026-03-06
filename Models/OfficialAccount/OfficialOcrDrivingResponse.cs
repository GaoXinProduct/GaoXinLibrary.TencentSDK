using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>OCR — 行驶证识别响应</summary>
public class OfficialOcrDrivingResponse : WechatBaseResponse
{
    [JsonPropertyName("plate_num")] public string? PlateNum { get; set; }
    [JsonPropertyName("vehicle_type")] public string? VehicleType { get; set; }
    [JsonPropertyName("owner")] public string? Owner { get; set; }
    [JsonPropertyName("addr")] public string? Addr { get; set; }
    [JsonPropertyName("use_character")] public string? UseCharacter { get; set; }
    [JsonPropertyName("model")] public string? Model { get; set; }
    [JsonPropertyName("vin")] public string? Vin { get; set; }
    [JsonPropertyName("engine_num")] public string? EngineNum { get; set; }
    [JsonPropertyName("register_date")] public string? RegisterDate { get; set; }
    [JsonPropertyName("issue_date")] public string? IssueDate { get; set; }
}

