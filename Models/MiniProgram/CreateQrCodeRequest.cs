using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;

/// <summary>
/// 获取小程序二维码请求（POST /cgi-bin/wxaapp/createwxaqrcode）
/// </summary>
public class CreateQrCodeRequest
{
    /// <summary>扫码进入的小程序页面路径，最大长度 128 字节</summary>
    [JsonPropertyName("path")] public required string Path { get; set; }

    /// <summary>二维码宽度（单位 px），默认 430px</summary>
    [JsonPropertyName("width")] public int? Width { get; set; }
}

