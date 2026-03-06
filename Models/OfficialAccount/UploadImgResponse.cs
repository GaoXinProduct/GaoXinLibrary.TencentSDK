using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>上传图文消息内的图片响应（POST /cgi-bin/media/uploadimg）</summary>
public class UploadImgResponse : WechatBaseResponse
{
    [JsonPropertyName("url")] public string? Url { get; set; }
}

