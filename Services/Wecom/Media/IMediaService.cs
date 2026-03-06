using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Media;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;


/// <summary>素材管理服务接口</summary>
public interface IMediaService
{
    /// <summary>上传临时素材，返回 media_id（有效期3天）</summary>
    Task<string> UploadTempMediaAsync(string type, string fileName, ReadOnlyMemory<byte> fileData, CancellationToken ct = default);

    /// <summary>上传图片素材，返回永久 URL（不受10MB限制，上限2048px）</summary>
    Task<string> UploadImageAsync(string fileName, ReadOnlyMemory<byte> fileData, CancellationToken ct = default);

    /// <summary>获取临时素材，返回文件字节</summary>
    Task<byte[]> GetTempMediaAsync(string mediaId, CancellationToken ct = default);

    /// <summary>获取高清语音素材（JSSDK 专用），返回文件字节</summary>
    Task<byte[]> GetJsSdkVoiceAsync(string mediaId, CancellationToken ct = default);

    /// <summary>异步上传临时素材（通过 URL），返回 jobid</summary>
    Task<string> UploadByUrlAsync(UploadByUrlRequest request, CancellationToken ct = default);

    /// <summary>获取异步上传临时素材的结果</summary>
    Task<GetUploadByUrlResultResponse> GetUploadByUrlResultAsync(string jobId, CancellationToken ct = default);

    /// <summary>上传附件资源（客户联系专用），返回 media_id</summary>
    Task<string> UploadAttachmentAsync(string mediaType, int attachmentType, string fileName, ReadOnlyMemory<byte> fileData, CancellationToken ct = default);
}
