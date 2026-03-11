using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取文件列表响应</summary>
public class GetFileListResponse : WecomBaseResponse
{
    /// <summary>文件列表</summary>
    [JsonPropertyName("file_list")] public WedriveFileInfo[]? FileList { get; set; }

    /// <summary>是否还有更多</summary>
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }

    /// <summary>分页游标</summary>
    [JsonPropertyName("next_start")] public int? NextStart { get; set; }
}
