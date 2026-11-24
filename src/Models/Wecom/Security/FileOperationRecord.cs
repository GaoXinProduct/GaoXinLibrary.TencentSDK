namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>文件操作记录。</summary>
public sealed class FileOperationRecord
{
    /// <summary>操作时间，Unix 时间戳，单位为秒。</summary>
    [JsonPropertyName("time")] public long Time { get; set; }

    /// <summary>操作者为企业成员时的成员账号。</summary>
    [JsonPropertyName("userid")] public string? UserId { get; set; }

    /// <summary>操作者为企业外部人员时的账号信息。</summary>
    [JsonPropertyName("external_user")] public FileOperationExternalUser? ExternalUser { get; set; }

    /// <summary>操作类型和来源。</summary>
    [JsonPropertyName("operation")] public FileOperation? Operation { get; set; }

    /// <summary>文件操作说明。</summary>
    [JsonPropertyName("file_info")] public string? FileInfo { get; set; }

    /// <summary>文件大小，单位为字节。</summary>
    [JsonPropertyName("file_size")] public long? FileSize { get; set; }

    /// <summary>操作记录包含的文件 MD5。</summary>
    [JsonPropertyName("file_md5")] public string? FileMd5 { get; set; }

    /// <summary>申请下载的企业成员名称。</summary>
    [JsonPropertyName("applicant_name")] public string? ApplicantName { get; set; }

    /// <summary>设备类型。</summary>
    [JsonPropertyName("device_type")] public int? DeviceType { get; set; }

    /// <summary>设备标识。</summary>
    [JsonPropertyName("device_code")] public string? DeviceCode { get; set; }
}

/// <summary>文件操作记录中的外部用户。</summary>
public sealed class FileOperationExternalUser
{
    /// <summary>用户类型。</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>用户名称。</summary>
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>企业名称。</summary>
    [JsonPropertyName("corp_name")] public string? CorpName { get; set; }
}
