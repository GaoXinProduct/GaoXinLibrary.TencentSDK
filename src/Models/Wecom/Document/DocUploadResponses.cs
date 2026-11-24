using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Document;

/// <summary>上传文档图片响应</summary>
public sealed class UploadDocImageResponse : WecomBaseResponse
{
    /// <summary>图片链接</summary>
    [JsonPropertyName("url")] public string? Url { get; set; }

    /// <summary>图片宽度，单位为像素</summary>
    [JsonPropertyName("width"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Width { get; set; }

    /// <summary>图片高度，单位为像素</summary>
    [JsonPropertyName("height"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Height { get; set; }

    /// <summary>图片大小，单位为字节</summary>
    [JsonPropertyName("size"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Size { get; set; }
}

/// <summary>上传文档文件响应</summary>
public sealed class UploadDocFileResponse : WecomBaseResponse
{
    /// <summary>文件链接</summary>
    [JsonPropertyName("file_url")] public string? FileUrl { get; set; }
}

/// <summary>初始化文档文件分块上传响应</summary>
public sealed class InitDocFileUploadResponse : WecomBaseResponse
{
    /// <summary>是否命中秒传</summary>
    [JsonPropertyName("hit_exist")] public bool HitExist { get; set; }

    /// <summary>分块上传凭证，未命中秒传时返回</summary>
    [JsonPropertyName("upload_key")] public string? UploadKey { get; set; }

    /// <summary>文件链接，命中秒传时返回</summary>
    [JsonPropertyName("file_url")] public string? FileUrl { get; set; }
}
