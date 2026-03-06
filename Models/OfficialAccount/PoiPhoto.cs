using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>门店图片</summary>
public class PoiPhoto
{
    [JsonPropertyName("photo_url")] public required string PhotoUrl { get; set; }
}

