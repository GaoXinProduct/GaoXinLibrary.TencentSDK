using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>分块上传初始化请求</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/98004</remarks>
public record ChunkedUploadInitRequest
{
    /// <summary>空间 ID，与父目录 ID 一起使用，或改用选择凭证</summary>
    [JsonPropertyName("spaceid")]
    public string? SpaceId { get; init; }

    /// <summary>父目录 ID</summary>
    [JsonPropertyName("fatherid")]
    public string? FatherId { get; init; }

    /// <summary>选中的微盘位置凭证</summary>
    [JsonPropertyName("selected_ticket")]
    public string? SelectedTicket { get; init; }

    /// <summary>文件名称</summary>
    [JsonPropertyName("file_name")]
    public required string FileName { get; init; }

    /// <summary>文件总大小（字节）</summary>
    [JsonPropertyName("size")]
    public required long FileSize { get; init; }

    /// <summary>按 2 MiB 分块计算的累积 SHA-1，按分块顺序传递</summary>
    /// <remarks>计算方式见 https://github.com/wecomopen/file_block_digest/blob/main/demo/README.md 。</remarks>
    [JsonPropertyName("block_sha")]
    public string[]? BlockSha { get; init; }

    /// <summary>上传完成后是否跳过企业微信通知卡片</summary>
    [JsonPropertyName("skip_push_card")]
    public bool? SkipPushCard { get; init; }

    /// <summary>旧模型中的单个文件校验值</summary>
    [Obsolete("微盘分块上传要求为每个块提供累积 SHA-1，请使用 BlockSha。")]
    [JsonIgnore]
    public string? FileHash { get; init; }

    /// <summary>旧模型的上传者字段</summary>
    [Obsolete("微盘上传接口通过应用凭证授权。")]
    [JsonIgnore]
    public string? UploadUserId { get; init; }
}
