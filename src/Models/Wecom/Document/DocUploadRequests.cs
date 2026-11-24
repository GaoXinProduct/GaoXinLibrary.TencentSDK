namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>上传文档图片请求</summary>
public sealed class UploadDocImageRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;

    /// <summary>原始图片字节。发送时编码为 Base64。</summary>
    [JsonPropertyName("base64_content")] public byte[] Content { get; set; } = [];
}

/// <summary>上传文档文件请求</summary>
public sealed class UploadDocFileRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;

    /// <summary>文件名</summary>
    [JsonPropertyName("file_name")] public string FileName { get; set; } = string.Empty;

    /// <summary>原始文件字节。发送时编码为 Base64。</summary>
    [JsonPropertyName("file_base64_content")] public byte[] Content { get; set; } = [];
}

/// <summary>初始化文档文件分块上传请求</summary>
public sealed class InitDocFileUploadRequest
{
    /// <summary>文档 ID</summary>
    [JsonPropertyName("docid")] public string DocId { get; set; } = string.Empty;

    /// <summary>文件名</summary>
    [JsonPropertyName("file_name")] public string FileName { get; set; } = string.Empty;

    /// <summary>文件字节数</summary>
    [JsonPropertyName("size")] public ulong Size { get; set; }

    /// <summary>按 2 MiB 分块计算的累积 SHA-1 值</summary>
    /// <remarks>计算方式见 <see href="https://github.com/wecomopen/file_block_digest">企业微信分块文件摘要示例</see>。</remarks>
    [JsonPropertyName("block_sha")] public string[] BlockSha { get; set; } = [];
}

/// <summary>上传文档文件分块请求</summary>
public sealed class UploadDocFilePartRequest
{
    /// <summary>初始化时获取的上传凭证</summary>
    [JsonPropertyName("upload_key")] public string UploadKey { get; set; } = string.Empty;

    /// <summary>从 1 开始的分块序号</summary>
    [JsonPropertyName("index")] public int Index { get; set; }

    /// <summary>原始分块字节。发送时编码为 Base64。</summary>
    [JsonPropertyName("file_base64_content")] public byte[] Content { get; set; } = [];
}

/// <summary>完成文档文件分块上传请求</summary>
public sealed class FinishDocFileUploadRequest
{
    /// <summary>初始化时获取的上传凭证</summary>
    [JsonPropertyName("upload_key")] public string UploadKey { get; set; } = string.Empty;
}
