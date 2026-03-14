using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>上传初始化响应体</summary>
public class WsUploadMediaInitResponseBody
{
    /// <summary>本次上传操作的 ID</summary>
    [JsonPropertyName("upload_id")] public string UploadId { get; set; } = string.Empty;
}
