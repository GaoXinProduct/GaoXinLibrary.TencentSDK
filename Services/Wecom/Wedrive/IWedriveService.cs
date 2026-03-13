using GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>微盘服务接口</summary>
public interface IWedriveService
{
    /// <summary>新建空间</summary>
    Task<string?> CreateSpaceAsync(CreateSpaceRequest request, CancellationToken ct = default);

    /// <summary>重命名空间</summary>
    Task RenameSpaceAsync(RenameSpaceRequest request, CancellationToken ct = default);

    /// <summary>解散空间</summary>
    Task DismissSpaceAsync(SpaceIdRequest request, CancellationToken ct = default);

    /// <summary>获取空间信息</summary>
    Task<SpaceInfo?> GetSpaceInfoAsync(SpaceIdRequest request, CancellationToken ct = default);

    /// <summary>获取文件列表</summary>
    Task<GetFileListResponse> GetFileListAsync(GetFileListRequest request, CancellationToken ct = default);

    /// <summary>新建文件夹/文档</summary>
    Task<CreateFileResponse> CreateFileAsync(CreateFileRequest request, CancellationToken ct = default);

    /// <summary>重命名文件</summary>
    Task RenameFileAsync(RenameFileRequest request, CancellationToken ct = default);

    /// <summary>删除文件</summary>
    Task DeleteFileAsync(DeleteFileRequest request, CancellationToken ct = default);

    /// <summary>移动文件</summary>
    Task MoveFileAsync(MoveFileRequest request, CancellationToken ct = default);
}
