using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.AsyncImport;

/// <summary>异步导入请求基类</summary>
public class AsyncImportRequest
{
    /// <summary>上传的csv文件的media_id</summary>
    [JsonPropertyName("media_id")] public string MediaId { get; set; } = string.Empty;

    /// <summary>是否邀请新建的成员使用企业微信</summary>
    [JsonPropertyName("to_invite")] public bool? ToInvite { get; set; }

    /// <summary>回调信息</summary>
    [JsonPropertyName("callback")] public AsyncImportCallback? Callback { get; set; }
}
