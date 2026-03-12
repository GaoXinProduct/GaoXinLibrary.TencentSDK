using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 公众号素材管理服务接口
/// </summary>
public interface IOfficialMaterialService
{
    /// <summary>获取素材总数</summary>
    Task<MaterialCountResponse> GetCountAsync(CancellationToken ct = default);
    /// <summary>获取永久素材</summary>
    Task<WechatBaseResponse> GetMaterialAsync(string mediaId, CancellationToken ct = default);
    /// <summary>删除永久素材</summary>
    Task<DeleteMaterialResponse> DeleteMaterialAsync(string mediaId, CancellationToken ct = default);
    /// <summary>获取素材列表</summary>
    Task<BatchGetMaterialResponse> BatchGetAsync(BatchGetMaterialRequest request, CancellationToken ct = default);
    /// <summary>上传临时素材（图片/语音/视频/缩略图）</summary>
    Task<UploadMediaResponse> UploadTempMaterialAsync(Stream fileStream, string fileName, string type, CancellationToken ct = default);
    /// <summary>上传临时素材（ReadOnlyMemory 版本）</summary>
    Task<UploadMediaResponse> UploadTempMaterialAsync(ReadOnlyMemory<byte> fileBytes, string fileName, string type, CancellationToken ct = default);
    /// <summary>下载临时素材字节流</summary>
    Task<byte[]> DownloadTempMaterialBytesAsync(string mediaId, CancellationToken ct = default);
    /// <summary>下载临时素材（ReadOnlyMemory 版本）</summary>
    Task<ReadOnlyMemory<byte>> DownloadTempMaterialReadOnlyAsync(string mediaId, CancellationToken ct = default);
    /// <summary>新增永久素材（图片/语音/视频/缩略图）</summary>
    Task<AddMaterialResponse> AddPermanentMaterialAsync(Stream fileStream, string fileName, string type, CancellationToken ct = default);
    /// <summary>新增永久素材（ReadOnlyMemory 版本）</summary>
    Task<AddMaterialResponse> AddPermanentMaterialAsync(ReadOnlyMemory<byte> fileBytes, string fileName, string type, CancellationToken ct = default);
}

