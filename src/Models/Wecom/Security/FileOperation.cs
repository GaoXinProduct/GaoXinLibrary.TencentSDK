namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>文件操作类型及来源。</summary>
public sealed class FileOperation
{
    /// <summary>操作类型。</summary>
    [JsonPropertyName("type")] public int Type { get; set; }

    /// <summary>操作来源。</summary>
    [JsonPropertyName("source")] public int? Source { get; set; }
}
