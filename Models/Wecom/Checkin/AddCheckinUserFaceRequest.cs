using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>录入打卡人员人脸信息请求</summary>
public class AddCheckinUserFaceRequest
{
    /// <summary>需要录入的用户 userid</summary>
    [JsonPropertyName("userid")] public string UserId { get; set; } = string.Empty;

    /// <summary>人脸图片数据（base64 编码）</summary>
    [JsonPropertyName("userface")] public string UserFace { get; set; } = string.Empty;
}

