using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Wedrive;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>微盘服务实现</summary>
public class WedriveService : IWedriveService
{
    private readonly WecomHttpClient _http;

    public WedriveService(WecomHttpClient http) => _http = http;

    public async Task<string?> CreateSpaceAsync(CreateSpaceRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<CreateSpaceResponse>("/cgi-bin/wedrive/space_create", request, ct);
        return resp.SpaceId;
    }

    public async Task RenameSpaceAsync(RenameSpaceRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/space_rename", request, ct);

    public async Task DismissSpaceAsync(SpaceIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/space_dismiss", request, ct);

    public async Task<SpaceInfo?> GetSpaceInfoAsync(SpaceIdRequest request, CancellationToken ct = default)
    {
        var resp = await _http.PostAsync<GetSpaceInfoResponse>("/cgi-bin/wedrive/space_info", request, ct);
        return resp.SpaceInfo;
    }

    public async Task<GetFileListResponse> GetFileListAsync(GetFileListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetFileListResponse>("/cgi-bin/wedrive/file_list", request, ct);

    public async Task<CreateFileResponse> CreateFileAsync(CreateFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateFileResponse>("/cgi-bin/wedrive/file_create", request, ct);

    public async Task RenameFileAsync(RenameFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_rename", request, ct);

    public async Task DeleteFileAsync(DeleteFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_delete", request, ct);

    public async Task MoveFileAsync(MoveFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedrive/file_move", request, ct);
}
