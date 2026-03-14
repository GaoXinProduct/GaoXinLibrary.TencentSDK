using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.SmartRobot;

/// <summary>
/// aibot_upload_media_finish 上传完成请求体
/// </summary>
public class WsUploadMediaFinishBody
{
    /// <summary>上传 ID（初始化时返回）</summary>
    [JsonPropertyName("upload_id")] public string UploadId { get; set; } = string.Empty;
}
