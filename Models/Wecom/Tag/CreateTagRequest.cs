using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Tag;

#region 请求模型

/// <summary>创建标签请求</summary>
public class CreateTagRequest
{
    [JsonPropertyName("tagname")] public string TagName { get; set; } = string.Empty;
    [JsonPropertyName("tagid")] public int? TagId { get; set; }
}

#endregion
