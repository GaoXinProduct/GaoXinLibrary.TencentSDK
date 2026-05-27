namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>客户群opengid转换请求</summary>
public sealed class ConvertOpengIdRequest
{
    [JsonPropertyName("opengid")] public string OpenGId { get; set; } = string.Empty;
}
