using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>微盘服务实现</summary>
public class WedriveService : IWedriveService
{
    private readonly WecomHttpClient _http;

    public WedriveService(WecomHttpClient http) => _http = http;

    public async Task<string?> CreateSpaceAsync(string spaceName, string[] adminUserIds, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateSpaceResponse>("/cgi-bin/wedrive/space_create",
            new { space_name = spaceName, auth_info = adminUserIds.Select(u => new { type = 1, userid = u }).ToArray() }, ct);
        return resp.SpaceId;
    }

    public async Task RenameSpaceAsync(string spaceId, string spaceName, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/space_rename",
            new { spaceid = spaceId, space_name = spaceName }, ct);

    public async Task DismissSpaceAsync(string spaceId, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/space_dismiss",
            new { spaceid = spaceId }, ct);

    public async Task<SpaceInfo?> GetSpaceInfoAsync(string spaceId, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetSpaceInfoResponse>("/cgi-bin/wedrive/space_info",
            new { spaceid = spaceId }, ct);
        return resp.SpaceInfo;
    }

    public async Task<GetFileListResponse> GetFileListAsync(string spaceId, string fatherId, int sortType = 1, int start = 0, int limit = 100, CancellationToken ct = default)
        => await _http.PostAsync<GetFileListResponse>("/cgi-bin/wedrive/file_list",
            new { spaceid = spaceId, fatherid = fatherId, sort_type = sortType, start, limit }, ct);

    public async Task<CreateFileResponse> CreateFileAsync(string spaceId, string fatherId, int fileType, string fileName, CancellationToken ct = default)
        => await _http.PostAsync<CreateFileResponse>("/cgi-bin/wedrive/file_create",
            new { spaceid = spaceId, fatherid = fatherId, file_type = fileType, file_name = fileName }, ct);

    public async Task RenameFileAsync(string fileId, string newName, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_rename",
            new { fileid = fileId, new_name = newName }, ct);

    public async Task DeleteFileAsync(string[] fileIds, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_delete",
            new { fileid = fileIds }, ct);

    public async Task MoveFileAsync(string[] fileIds, string fatherId, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_move",
            new { fileid = fileIds, fatherid = fatherId }, ct);
}
