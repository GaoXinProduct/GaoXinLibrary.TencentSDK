using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

/// <summary>分块上传响应</summary>
/// <remarks>对应文档：https://developer.work.weixin.qq.com/document/path/98004</remarks>
public class ChunkedUploadChunkResponse : WecomBaseResponse
{
    /// <summary>已上传的分块序号列表</summary>
    [JsonPropertyName("chunk_list")]
    public int[]? ChunkList { get; set; }
}