using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取文件列表请求</summary>
public class GetFileListRequest
{
    /// <summary>空间 ID</summary>
    [JsonPropertyName("spaceid")]
    public string SpaceId { get; set; } = string.Empty;

    /// <summary>父目录 ID</summary>
    [JsonPropertyName("fatherid")]
    public string FatherId { get; set; } = string.Empty;

    /// <summary>排序方式，1-名称，2-大小，3-修改时间</summary>
    [JsonPropertyName("sort_type")]
    public int SortType { get; set; } = 1;

    /// <summary>起始位置</summary>
    [JsonPropertyName("start")]
    public int Start { get; set; }

    /// <summary>每页大小</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 100;
}
