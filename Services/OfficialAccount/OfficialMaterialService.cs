using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号素材管理服务实现</summary>
public class OfficialMaterialService : IOfficialMaterialService
{
    private readonly WechatHttpClient _http;

    public OfficialMaterialService(WechatHttpClient http)
    {
        _http = http;
    }

    /// <inheritdoc/>
    public Task<MaterialCountResponse> GetCountAsync(CancellationToken ct = default)
        => _http.GetAsync<MaterialCountResponse>("/cgi-bin/material/get_materialcount", ct: ct);

    /// <inheritdoc/>
    public Task<WechatBaseResponse> GetMaterialAsync(string mediaId, CancellationToken ct = default)
        => _http.PostAsync<WechatBaseResponse>("/cgi-bin/material/get_material", new GetMaterialRequest { MediaId = mediaId }, ct);

    /// <inheritdoc/>
    public Task<DeleteMaterialResponse> DeleteMaterialAsync(string mediaId, CancellationToken ct = default)
        => _http.PostAsync<DeleteMaterialResponse>("/cgi-bin/material/del_material", new DeleteMaterialRequest { MediaId = mediaId }, ct);

    /// <inheritdoc/>
    public Task<BatchGetMaterialResponse> BatchGetAsync(BatchGetMaterialRequest request, CancellationToken ct = default)
        => _http.PostAsync<BatchGetMaterialResponse>("/cgi-bin/material/batchget_material", request, ct);
    /// <inheritdoc/>
    public async Task<UploadMediaResponse> UploadTempMaterialAsync(Stream fileStream, string fileName, string type, CancellationToken ct = default)
    {
        using var ms = new MemoryStream();
        await fileStream.CopyToAsync(ms, ct);
        using var form = BuildMediaForm(fileName, ms.ToArray());
        return await _http.PostRawFormAsync<UploadMediaResponse>(
            "/cgi-bin/media/upload",
            form,
            new Dictionary<string, string?> { ["type"] = type },
            ct);
    }

    /// <inheritdoc/>
    public async Task<UploadMediaResponse> UploadTempMaterialAsync(ReadOnlyMemory<byte> fileBytes, string fileName, string type, CancellationToken ct = default)
    {
        using var form = BuildMediaForm(fileName, fileBytes);
        return await _http.PostRawFormAsync<UploadMediaResponse>(
            "/cgi-bin/media/upload",
            form,
            new Dictionary<string, string?> { ["type"] = type },
            ct);
    }

    /// <inheritdoc/>
    public Task<byte[]> DownloadTempMaterialBytesAsync(string mediaId, CancellationToken ct = default)
        => _http.GetForBytesAsync("/cgi-bin/media/get", new Dictionary<string, string?> { ["media_id"] = mediaId }, ct);

    /// <inheritdoc/>
    public async Task<ReadOnlyMemory<byte>> DownloadTempMaterialReadOnlyAsync(string mediaId, CancellationToken ct = default)
        => await _http.GetForBytesAsync("/cgi-bin/media/get", new Dictionary<string, string?> { ["media_id"] = mediaId }, ct);

    /// <inheritdoc/>
    public async Task<AddMaterialResponse> AddPermanentMaterialAsync(Stream fileStream, string fileName, string type, CancellationToken ct = default)
    {
        using var ms = new MemoryStream();
        await fileStream.CopyToAsync(ms, ct);
        using var form = BuildMediaForm(fileName, ms.ToArray());
        return await _http.PostRawFormAsync<AddMaterialResponse>(
            "/cgi-bin/material/add_material",
            form,
            new Dictionary<string, string?> { ["type"] = type },
            ct);
    }

    /// <inheritdoc/>
    public async Task<AddMaterialResponse> AddPermanentMaterialAsync(ReadOnlyMemory<byte> fileBytes, string fileName, string type, CancellationToken ct = default)
    {
        using var form = BuildMediaForm(fileName, fileBytes);
        return await _http.PostRawFormAsync<AddMaterialResponse>(
            "/cgi-bin/material/add_material",
            form,
            new Dictionary<string, string?> { ["type"] = type },
            ct);
    }

    // 手动拼接 multipart/form-data 原始字节，完全绕过 .NET 的 MultipartFormDataContent
    // 及其 RFC 5987 filename* 编码，保证发送给微信的字节与文档格式完全一致：
    // Content-Disposition: form-data; name="media"; filename="xxx"
    private static ByteArrayContent BuildMediaForm(string fileName, ReadOnlyMemory<byte> fileData)
    {
        var boundary = Guid.NewGuid().ToString("N");
        var mimeType = GetMimeType(fileName);
        var partHeader = Encoding.UTF8.GetBytes(
            $"--{boundary}\r\n" +
            $"Content-Disposition: form-data; name=\"media\"; filename=\"{fileName}\"\r\n" +
            $"Content-Type: {mimeType}\r\n\r\n");
        var partFooter = Encoding.UTF8.GetBytes($"\r\n--{boundary}--\r\n");

        var body = new byte[partHeader.Length + fileData.Length + partFooter.Length];
        partHeader.AsSpan().CopyTo(body.AsSpan());
        fileData.Span.CopyTo(body.AsSpan(partHeader.Length));
        partFooter.AsSpan().CopyTo(body.AsSpan(partHeader.Length + fileData.Length));

        var content = new ByteArrayContent(body);
        content.Headers.TryAddWithoutValidation("Content-Type", $"multipart/form-data; boundary={boundary}");
        return content;
    }

    private static string GetMimeType(string fileName) =>
        Path.GetExtension(fileName).ToLowerInvariant() switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png"            => "image/png",
            ".gif"            => "image/gif",
            ".bmp"            => "image/bmp",
            ".webp"           => "image/webp",
            ".amr"            => "audio/amr",
            ".mp3"            => "audio/mpeg",
            ".mp4"            => "video/mp4",
            _                 => "application/octet-stream"
        };
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号 JS-SDK 服务

