using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Media;

/// <summary>获取异步上传临时素材结果响应</summary>
public class GetUploadByUrlResultResponse : WecomBaseResponse
{
    /// <summary>任务状态。1-处理中；2-完成；3-异常失败</summary>
    [JsonPropertyName("status")] public int Status { get; set; }

    /// <summary>上传结果详情（status 为 2 时有效）</summary>
    [JsonPropertyName("detail")] public UploadByUrlResultDetail? Detail { get; set; }
}

