using GaoXinLibrary.TencentSDK.Wecom.Models.Document;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>文档服务接口</summary>
public interface IDocumentService
{
    /// <summary>新建文档</summary>
    Task<CreateDocResponse> CreateDocAsync(CreateDocRequest request, CancellationToken ct = default);

    /// <summary>获取文档基础信息</summary>
    Task<GetDocBaseInfoResponse> GetDocBaseInfoAsync(DocIdRequest request, CancellationToken ct = default);

    /// <summary>重命名文档</summary>
    Task RenameDocAsync(RenameDocRequest request, CancellationToken ct = default);

    /// <summary>删除文档</summary>
    Task DeleteDocAsync(DocIdRequest request, CancellationToken ct = default);

    /// <summary>分享文档</summary>
    Task ShareDocAsync(ShareDocRequest request, CancellationToken ct = default);
}
