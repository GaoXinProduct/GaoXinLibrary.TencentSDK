using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.QQConnect;

/// <summary>
/// QQ OpenAPI 基础响应（ret/msg 格式）
/// </summary>
public class QQOpenApiBaseResponse
{
    /// <summary>返回码，0 表示正确</summary>
    [JsonPropertyName("ret")] public int Ret { get; set; }

    /// <summary>错误信息，正确时为空</summary>
    [JsonPropertyName("msg")] public string? Msg { get; set; }
}

