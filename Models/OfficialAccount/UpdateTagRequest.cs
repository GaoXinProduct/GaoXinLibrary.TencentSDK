using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>编辑标签请求（POST /cgi-bin/tags/update）</summary>
public class UpdateTagRequest
{
    [JsonPropertyName("tag")] public required TagItem Tag { get; set; }
}

