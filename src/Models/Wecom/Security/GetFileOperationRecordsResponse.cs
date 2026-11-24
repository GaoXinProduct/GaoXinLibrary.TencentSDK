using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Security;

/// <summary>一页文件操作记录。</summary>
public class GetFileOperationRecordsResponse : WecomBaseResponse
{
    /// <summary>是否还有更多记录。</summary>
    [JsonPropertyName("has_more")] public bool HasMore { get; set; }

    /// <summary>下一页查询使用的游标。</summary>
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; set; }

    /// <summary>文件操作记录列表。</summary>
    [JsonPropertyName("record_list")] public FileOperationRecord[]? RecordList { get; set; }
}
