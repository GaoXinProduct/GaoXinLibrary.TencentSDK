using GaoXinLibrary.TencentSDK.Wecom.Models.Document;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>文档服务接口</summary>
public interface IDocumentService
{
    /// <summary>新建文档</summary>
    Task<CreateDocResponse> CreateDocAsync(string docName, int docType = 1, string? folderId = null, CancellationToken ct = default);

    /// <summary>获取文档基础信息</summary>
    Task<GetDocBaseInfoResponse> GetDocBaseInfoAsync(string docId, CancellationToken ct = default);

    /// <summary>重命名文档</summary>
    Task RenameDocAsync(string docId, string docName, CancellationToken ct = default);

    /// <summary>删除文档</summary>
    Task DeleteDocAsync(string docId, CancellationToken ct = default);

    /// <summary>分享文档</summary>
    Task ShareDocAsync(string docId, string[] userIds, CancellationToken ct = default);
}
