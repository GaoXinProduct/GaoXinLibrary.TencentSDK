
namespace GaoXinLibrary.TencentSDK.Wecom.Models.OperationLog;

/// <summary>操作记录</summary>
public sealed class OperationRecord
{
    /// <summary>操作人userid</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>操作类型</summary>
    [JsonPropertyName("oper_type")] public int OperateType { get; set; }

    /// <summary>操作时间戳</summary>
    [JsonPropertyName("time")] public long OperateTime { get; set; }

    /// <summary>操作数据</summary>
    [JsonPropertyName("detail_info")] public string? Data { get; set; }

    /// <summary>操作来源 IP。</summary>
    [JsonPropertyName("ip")] public string? Ip { get; set; }

    /// <summary>管理端操作的详细类型。</summary>
    [JsonPropertyName("detail_type")] public int? DetailType { get; set; }

    [JsonInclude]
    [JsonPropertyName("operatetype")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    private int LegacyOperateType
    {
        get => default;
        set => OperateType = value;
    }

    [JsonInclude]
    [JsonPropertyName("operatetime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    private long LegacyOperateTime
    {
        get => default;
        set => OperateTime = value;
    }

    [JsonInclude]
    [JsonPropertyName("data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    private string? LegacyData
    {
        get => null;
        set => Data = value;
    }
}
