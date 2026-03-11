using System.Text.Json.Serialization;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>微盘文件信息</summary>
public class WedriveFileInfo
{
    /// <summary>文件ID</summary>
    [JsonPropertyName("fileid")] public string? FileId { get; set; }

    /// <summary>文件名</summary>
    [JsonPropertyName("file_name")] public string? FileName { get; set; }

    /// <summary>文件类型，1-文件夹，2-文件，3-微文档</summary>
    [JsonPropertyName("file_type")] public int FileType { get; set; }

    /// <summary>文件大小（字节）</summary>
    [JsonPropertyName("file_size")] public long FileSize { get; set; }

    /// <summary>创建时间（Unix时间戳）</summary>
    [JsonPropertyName("ctime")] public long CTime { get; set; }

    /// <summary>修改时间（Unix时间戳）</summary>
    [JsonPropertyName("mtime")] public long MTime { get; set; }

    /// <summary>创建者userid</summary>
    [JsonPropertyName("creator_userid")] public string? CreatorUserId { get; set; }

    /// <summary>修改者userid</summary>
    [JsonPropertyName("modifier_userid")] public string? ModifierUserId { get; set; }

    /// <summary>所属空间ID</summary>
    [JsonPropertyName("spaceid")] public string? SpaceId { get; set; }

    /// <summary>父文件夹ID</summary>
    [JsonPropertyName("fatherid")] public string? FatherId { get; set; }
}
