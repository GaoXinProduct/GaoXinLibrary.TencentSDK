using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>微盘服务实现</summary>
public class WedriveService
{
    private readonly WecomHttpClient _http;

    public WedriveService(WecomHttpClient http) => _http = http;

    /// <summary>新建空间</summary>
    public async Task<string?> CreateSpaceAsync(CreateSpaceRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateSpaceResponse>("/cgi-bin/wedrive/space_create", request, ct);
        return resp.SpaceId;
    }

    /// <summary>重命名空间</summary>
    public async Task RenameSpaceAsync(RenameSpaceRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/space_rename", request, ct);

    /// <summary>解散空间</summary>
    public async Task DismissSpaceAsync(SpaceIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/space_dismiss", request, ct);

    /// <summary>获取空间信息（通过 SpaceIdRequest）</summary>
    public async Task<SpaceInfo?> GetSpaceInfoAsync(SpaceIdRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetSpaceInfoResponse>("/cgi-bin/wedrive/space_info", request, ct);
        return resp.SpaceInfo;
    }

    /// <summary>获取文件列表</summary>
    public async Task<GetFileListResponse> GetFileListAsync(GetFileListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetFileListResponse>("/cgi-bin/wedrive/file_list", request, ct);

    /// <summary>新建文件夹/文档</summary>
    public async Task<CreateFileResponse> CreateFileAsync(CreateFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateFileResponse>("/cgi-bin/wedrive/file_create", request, ct);

    /// <summary>重命名文件</summary>
    public async Task RenameFileAsync(RenameFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_rename", request, ct);

    /// <summary>删除文件</summary>
    public async Task DeleteFileAsync(DeleteFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_delete", request, ct);

    /// <summary>移动文件</summary>
    public async Task MoveFileAsync(MoveFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_move", request, ct);

    /// <summary>上传文件</summary>
    public async Task<UploadFileResponse> UploadFileAsync(UploadFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<UploadFileResponse>("/cgi-bin/wedrive/file_upload", request, ct);

    /// <summary>分块上传初始化</summary>
    public async Task<ChunkedUploadInitResponse> InitChunkedUploadAsync(ChunkedUploadInitRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ChunkedUploadInitResponse>("/cgi-bin/wedrive/upload_init", request, ct);

    /// <summary>分块上传</summary>
    public async Task<ChunkedUploadChunkResponse> UploadChunkAsync(ChunkedUploadChunkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ChunkedUploadChunkResponse>("/cgi-bin/wedrive/upload_chunk", request, ct);

    /// <summary>分块上传完成</summary>
    public async Task<ChunkedUploadFinishResponse> FinishChunkedUploadAsync(ChunkedUploadFinishRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ChunkedUploadFinishResponse>("/cgi-bin/wedrive/upload_finish", request, ct);

    /// <summary>下载文件</summary>
    public async Task<DownloadFileResponse> DownloadFileAsync(DownloadFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<DownloadFileResponse>("/cgi-bin/wedrive/file_download", request, ct);

    /// <summary>新建文件夹/文档</summary>
    public async Task<CreateFolderResponse> CreateFolderAsync(CreateFolderRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateFolderResponse>("/cgi-bin/wedrive/folder_create", request, ct);

    /// <summary>获取文件信息</summary>
    public async Task<GetFileInfoResponse> GetFileInfoAsync(GetFileInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetFileInfoResponse>("/cgi-bin/wedrive/file_info", request, ct);

    /// <summary>新增文件成员</summary>
    public async Task<AddFileMemberResponse> AddFileMemberAsync(AddFileMemberRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddFileMemberResponse>("/cgi-bin/wedrive/file_member_add", request, ct);

    /// <summary>删除文件成员</summary>
    public async Task RemoveFileMemberAsync(RemoveFileMemberRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_member_remove", request, ct);

    /// <summary>设置文件分享设置</summary>
    public async Task SetFileShareSettingAsync(SetFileShareSettingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_share_set", request, ct);

    /// <summary>获取文件分享链接</summary>
    public async Task<GetFileShareLinkResponse> GetFileShareLinkAsync(GetFileShareLinkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetFileShareLinkResponse>("/cgi-bin/wedrive/file_share_link", request, ct);

    /// <summary>获取文件权限信息</summary>
    public async Task<GetFilePermissionInfoResponse> GetFilePermissionInfoAsync(GetFilePermissionInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetFilePermissionInfoResponse>("/cgi-bin/wedrive/file_permission_info", request, ct);

    /// <summary>修改文件安全设置</summary>
    public async Task ModifyFileSecuritySettingAsync(ModifyFileSecuritySettingRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_security_set", request, ct);

    /// <summary>添加空间成员/部门</summary>
    public async Task<AddSpaceMemberResponse> AddSpaceMemberAsync(AddSpaceMemberRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AddSpaceMemberResponse>("/cgi-bin/wedrive/space_member_add", request, ct);

    /// <summary>移除空间成员/部门</summary>
    public async Task RemoveSpaceMemberAsync(RemoveSpaceMemberRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/space_member_remove", request, ct);

    /// <summary>设置空间安全设置</summary>
    public async Task SetSpaceSecurityAsync(SetSpaceSecurityRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/space_security_set", request, ct);

    /// <summary>获取空间邀请链接</summary>
    public async Task<GetSpaceInviteLinkResponse> GetSpaceInviteLinkAsync(GetSpaceInviteLinkRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetSpaceInviteLinkResponse>("/cgi-bin/wedrive/space_invite_link", request, ct);

    /// <summary>获取空间信息</summary>
    public async Task<GetSpaceInfoResponse> GetSpaceDetailInfoAsync(GetSpaceInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetSpaceInfoResponse>("/cgi-bin/wedrive/space_info_detail", request, ct);
}