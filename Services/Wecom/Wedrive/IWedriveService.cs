using GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>微盘服务接口</summary>
public interface IWedriveService
{
    /// <summary>新建空间</summary>
    Task<string?> CreateSpaceAsync(string spaceName, string[] adminUserIds, CancellationToken ct = default);

    /// <summary>重命名空间</summary>
    Task RenameSpaceAsync(string spaceId, string spaceName, CancellationToken ct = default);

    /// <summary>解散空间</summary>
    Task DismissSpaceAsync(string spaceId, CancellationToken ct = default);

    /// <summary>获取空间信息</summary>
    Task<SpaceInfo?> GetSpaceInfoAsync(string spaceId, CancellationToken ct = default);

    /// <summary>获取文件列表</summary>
    Task<GetFileListResponse> GetFileListAsync(string spaceId, string fatherId, int sortType = 1, int start = 0, int limit = 100, CancellationToken ct = default);

    /// <summary>新建文件夹/文档</summary>
    Task<CreateFileResponse> CreateFileAsync(string spaceId, string fatherId, int fileType, string fileName, CancellationToken ct = default);

    /// <summary>重命名文件</summary>
    Task RenameFileAsync(string fileId, string newName, CancellationToken ct = default);

    /// <summary>删除文件</summary>
    Task DeleteFileAsync(string[] fileIds, CancellationToken ct = default);

    /// <summary>移动文件</summary>
    Task MoveFileAsync(string[] fileIds, string fatherId, CancellationToken ct = default);
}
