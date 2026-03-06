using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Export;

/// <summary>导出数据文件信息</summary>
public class ExportDataItem
{
    /// <summary>数据文件下载地址（使用 AES 加密，需用 EncodingAESKey 解密）</summary>
    [JsonPropertyName("url")] public string Url { get; set; } = string.Empty;

    /// <summary>数据文件大小（字节）</summary>
    [JsonPropertyName("size")] public long Size { get; set; }

    /// <summary>数据文件 MD5 校验值</summary>
    [JsonPropertyName("md5")] public string Md5 { get; set; } = string.Empty;
}

