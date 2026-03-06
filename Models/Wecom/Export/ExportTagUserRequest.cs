using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Export;

/// <summary>导出标签成员请求</summary>
public class ExportTagUserRequest : ExportRequest
{
    /// <summary>需要导出的标签 ID</summary>
    [JsonPropertyName("tagid")] public int TagId { get; set; }
}

