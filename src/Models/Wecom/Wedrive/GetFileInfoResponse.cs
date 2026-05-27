using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>获取文件信息响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/97886</remarks>
public class GetFileInfoResponse : WecomBaseResponse
{
    /// <summary>文件信息列表</summary>
    [JsonPropertyName("file_info")]
    public FileInfo[]? FileInfo { get; set; }
}