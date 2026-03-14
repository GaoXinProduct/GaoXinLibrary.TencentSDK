using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>上传完成响应体</summary>
public class WsUploadMediaFinishResponseBody
{
    /// <summary>文件类型</summary>
    [JsonPropertyName("type")] public string Type { get; set; } = string.Empty;

    /// <summary>媒体文件上传后获取的唯一标识，3 天内有效</summary>
    [JsonPropertyName("media_id")] public string MediaId { get; set; } = string.Empty;

    /// <summary>媒体文件上传时间戳</summary>
    [JsonPropertyName("created_at")] public long CreatedAt { get; set; }
}
