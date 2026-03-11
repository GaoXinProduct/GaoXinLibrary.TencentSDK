using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.OperationLog;

/// <summary>操作记录</summary>
public class OperationRecord
{
    /// <summary>操作人userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>操作类型</summary>
    [JsonPropertyName("operatetype")] public int OperateType { get; set; }

    /// <summary>操作时间戳</summary>
    [JsonPropertyName("operatetime")] public long OperateTime { get; set; }

    /// <summary>操作数据</summary>
    [JsonPropertyName("data")] public string? Data { get; set; }
}
