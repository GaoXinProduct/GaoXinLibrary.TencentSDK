using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

/// <summary>删除永久素材请求（POST /cgi-bin/material/del_material）</summary>
public class DeleteMaterialRequest
{
    [JsonPropertyName("media_id")] public required string MediaId { get; set; }
}

