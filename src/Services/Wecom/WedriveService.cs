using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>微盘服务实现</summary>
public sealed class WedriveService
{
    private readonly WecomHttpClient _http;

    public WedriveService(WecomHttpClient http) => _http = http;

    /// <summary>新建空间</summary>
    public async Task<string?> CreateSpaceAsync(CreateSpaceRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateSpaceResponse>("/cgi-bin/wedrive/space_create", request, ct).ConfigureAwait(false);
        return resp.SpaceId;
    }

    /// <summary>重命名空间</summary>
    public async Task RenameSpaceAsync(RenameSpaceRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/space_rename", request, ct).ConfigureAwait(false);

    /// <summary>解散空间</summary>
    public async Task DismissSpaceAsync(SpaceIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/space_dismiss", request, ct).ConfigureAwait(false);

    /// <summary>获取空间信息</summary>
    public async Task<SpaceInfo?> GetSpaceInfoAsync(SpaceIdRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetSpaceInfoResponse>("/cgi-bin/wedrive/space_info", request, ct).ConfigureAwait(false);
        return resp.SpaceInfo;
    }

    /// <summary>添加微盘空间成员和部门</summary>
    public Task<AddSpaceMemberResponse> AddSpaceMembersAsync(AddSpaceMemberRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (request.AuthList is not { Length: > 0 })
            throw new ArgumentException("至少指定一个空间成员或部门。", nameof(request));

        return _http.PostAsync<AddSpaceMemberResponse>("/cgi-bin/wedrive/space_acl_add", request, ct);
    }

    /// <summary>移除微盘空间成员和部门</summary>
    public Task<RemoveSpaceMemberResponse> RemoveSpaceMembersAsync(RemoveSpaceMemberRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (request.AuthInfo is null && request.AuthIdList is not null)
        {
            var members = request.AuthIdList.Select(id => request.Type switch
            {
                1 => new SpaceMemberIdentity { Type = 1, UserId = id },
                2 when uint.TryParse(id, out var departmentId) => new SpaceMemberIdentity { Type = 2, DepartmentId = departmentId },
                _ => throw new ArgumentException("空间成员类型或部门 ID 无效。", nameof(request))
            }).ToArray();
            request = request with { AuthInfo = members };
        }

        if (request.AuthInfo is not { Length: > 0 })
            throw new ArgumentException("至少指定一个空间成员或部门。", nameof(request));

        return _http.PostAsync<RemoveSpaceMemberResponse>("/cgi-bin/wedrive/space_acl_del", request, ct);
    }

    /// <summary>获取微盘空间的邀请链接</summary>
    public Task<GetSpaceInviteLinkResponse> GetSpaceInviteLinkAsync(GetSpaceInviteLinkRequest request, CancellationToken ct = default)
        => _http.PostAsync<GetSpaceInviteLinkResponse>("/cgi-bin/wedrive/space_share", request, ct);

    /// <summary>修改微盘空间的安全设置</summary>
    public Task<SetSpaceSecurityResponse> UpdateSpaceSecurityAsync(UpdateSpaceSecurityRequest request, CancellationToken ct = default)
        => _http.PostAsync<SetSpaceSecurityResponse>("/cgi-bin/wedrive/space_setting", request, ct);

    /// <summary>获取文件列表</summary>
    public async Task<GetFileListResponse> GetFileListAsync(GetFileListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetFileListResponse>("/cgi-bin/wedrive/file_list", request, ct).ConfigureAwait(false);

    /// <summary>上传普通文件至微盘</summary>
    public Task<UploadFileResponse> UploadFileAsync(UploadFileRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ValidateUploadDestination(request.SpaceId, request.FatherId, request.SelectedTicket);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.FileName);
        ArgumentNullException.ThrowIfNull(request.FileContent);

        return _http.PostAsync<UploadFileResponse>("/cgi-bin/wedrive/file_upload", request, ct);
    }

    /// <summary>获取微盘文件的下载链接和 Cookie</summary>
    /// <remarks>对响应中的下载链接发起 GET，并在 Cookie 标头中附上返回的名称和值。</remarks>
    public Task<DownloadFileResponse> DownloadFileAsync(DownloadFileRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if ((request.FileId is null) == (request.SelectedTicket is null))
            throw new ArgumentException("文件 ID 和文件选择凭证必须且只能指定一项。", nameof(request));

        ArgumentException.ThrowIfNullOrWhiteSpace(request.FileId ?? request.SelectedTicket, nameof(request));
        return _http.PostAsync<DownloadFileResponse>("/cgi-bin/wedrive/file_download", request, ct);
    }

    /// <summary>初始化微盘文件分块上传</summary>
    /// <remarks>命中秒传时直接使用返回的文件 ID，否则用上传凭证继续上传分块。</remarks>
    public Task<ChunkedUploadInitResponse> InitializeChunkedUploadAsync(ChunkedUploadInitRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ValidateUploadDestination(request.SpaceId, request.FatherId, request.SelectedTicket);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.FileName);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(request.FileSize);

        var expectedBlockCount = (request.FileSize - 1) / ChunkedUploadChunkRequest.BlockSizeBytes + 1;
        if (request.BlockSha is null || request.BlockSha.Length != expectedBlockCount ||
            request.BlockSha.Any(sha => sha is not { Length: 40 } || !sha.All(Uri.IsHexDigit)))
        {
            throw new ArgumentException("须按 2 MiB 分块为文件提供完整的累积 SHA-1 列表。", nameof(request));
        }

        return _http.PostAsync<ChunkedUploadInitResponse>("/cgi-bin/wedrive/file_upload_init", request, ct);
    }

    /// <summary>提交一个微盘文件分块</summary>
    public Task<ChunkedUploadChunkResponse> UploadChunkAsync(ChunkedUploadChunkRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.UploadKey);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(request.Index);
        if (request.FileContent is null || request.FileContent.Length == 0 ||
            request.FileContent.Length > ChunkedUploadChunkRequest.BlockSizeBytes)
        {
            throw new ArgumentException("微盘文件分块必须包含最多 2 MiB 的数据。", nameof(request));
        }

        return _http.PostAsync<ChunkedUploadChunkResponse>("/cgi-bin/wedrive/file_upload_part", request, ct);
    }

    /// <summary>确认分块上传完成，获取文件 ID</summary>
    public Task<ChunkedUploadFinishResponse> FinishChunkedUploadAsync(ChunkedUploadFinishRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentException.ThrowIfNullOrWhiteSpace(request.UploadKey);
        return _http.PostAsync<ChunkedUploadFinishResponse>("/cgi-bin/wedrive/file_upload_finish", request, ct);
    }

    /// <summary>新建文件夹/文档</summary>
    public async Task<CreateFileResponse> CreateFileAsync(CreateFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateFileResponse>("/cgi-bin/wedrive/file_create", request, ct).ConfigureAwait(false);

    /// <summary>重命名文件</summary>
    public async Task RenameFileAsync(RenameFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_rename", request, ct).ConfigureAwait(false);

    /// <summary>删除文件</summary>
    public async Task DeleteFileAsync(DeleteFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_delete", request, ct).ConfigureAwait(false);

    /// <summary>移动文件</summary>
    public async Task MoveFileAsync(MoveFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_move", request, ct).ConfigureAwait(false);

    private static void ValidateUploadDestination(string? spaceId, string? fatherId, string? selectedTicket)
    {
        if (selectedTicket is null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(spaceId);
            ArgumentException.ThrowIfNullOrWhiteSpace(fatherId);
            return;
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(selectedTicket);
        if (spaceId is not null || fatherId is not null)
            throw new ArgumentException("空间和父目录 ID 不能与位置选择凭证同时指定。");
    }
}
