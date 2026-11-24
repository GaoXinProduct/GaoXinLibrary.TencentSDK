using System.Globalization;
using System.Net;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Media;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public sealed class MediaService
{
    private const string TempMediaPath = "/cgi-bin/media/get";
    private const int RangeRequiredErrorCode = 830002;
    private const int MaxRangeSize = 20 * 1024 * 1024;

    private readonly WecomHttpClient _http;
    private readonly WecomHttpClient _mediaHttp;

    public MediaService(WecomHttpClient http, AccessTokenProvider tokenProvider, HttpClient rawHttpClient, string baseUrl)
        : this(http)
        => _mediaHttp = http.WithTransport(rawHttpClient, tokenProvider, baseUrl);

    internal MediaService(WecomHttpClient http)
    {
        _http = http;
        _mediaHttp = http;
    }

    // 手动拼接 multipart/form-data 原始字节，完全绕过 .NET 的 MultipartFormDataContent
    // 及其 RFC 5987 filename* 编码，保证发送给企业微信的字节与文档格式完全一致：
    // Content-Disposition: form-data; name="media"; filename="xxx"; filelength=yyy
    private static ByteArrayContent BuildMediaForm(string fileName, ReadOnlyMemory<byte> fileData)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
        if (fileName.Any(char.IsControl))
            throw new ArgumentException("文件名不能包含控制字符。", nameof(fileName));

        var escapedFileName = fileName.Replace("\\", "\\\\", StringComparison.Ordinal)
                                      .Replace("\"", "\\\"", StringComparison.Ordinal);
        var boundary = Guid.NewGuid().ToString("N");
        var partHeader = Encoding.UTF8.GetBytes(
            $"--{boundary}\r\n" +
            $"Content-Disposition: form-data; name=\"media\"; filename=\"{escapedFileName}\"; filelength={fileData.Length}\r\n" +
            $"Content-Type: application/octet-stream\r\n\r\n");
        var partFooter = Encoding.UTF8.GetBytes($"\r\n--{boundary}--\r\n");

        var body = new byte[partHeader.Length + fileData.Length + partFooter.Length];
        partHeader.CopyTo(body, 0);
        fileData.Span.CopyTo(body.AsSpan(partHeader.Length));
        partFooter.CopyTo(body.AsSpan(partHeader.Length + fileData.Length));

        var content = new ByteArrayContent(body);
        content.Headers.TryAddWithoutValidation("Content-Type", $"multipart/form-data; boundary={boundary}");
        return content;
    }

    /// <summary>上传临时素材，返回 media_id（有效期3天）</summary>
    public async Task<string> UploadTempMediaAsync(string type, string fileName, ReadOnlyMemory<byte> fileData, CancellationToken ct = default)
    {
        using var form = BuildMediaForm(fileName, fileData);
        var result = await _mediaHttp.PostRawFormAsync<UploadMediaResponse>(
            "/cgi-bin/media/upload", form, new() { ["type"] = type }, ct).ConfigureAwait(false);
        return result.MediaId ?? string.Empty;
    }

    /// <summary>上传图片素材，返回永久 URL（不受10MB限制，上限2048px）</summary>
    public async Task<string> UploadImageAsync(string fileName, ReadOnlyMemory<byte> fileData, CancellationToken ct = default)
    {
        using var form = BuildMediaForm(fileName, fileData);
        var result = await _mediaHttp.PostRawFormAsync<UploadImageResponse>(
            "/cgi-bin/media/uploadimg", form, ct: ct).ConfigureAwait(false);
        return result.Url ?? string.Empty;
    }

    /// <summary>获取临时素材，返回文件字节</summary>
    public async Task<byte[]> GetTempMediaAsync(string mediaId, CancellationToken ct = default)
    {
        using var destination = new MemoryStream();
        await DownloadTempMediaAsync(mediaId, destination, ct).ConfigureAwait(false);
        return destination.ToArray();
    }

    /// <summary>将临时素材写入目标流。服务端要求分块时会按 Range 连续下载。</summary>
    /// <remarks>目标流由调用方管理，下载失败时可能已经写入部分内容。</remarks>
    public async Task DownloadTempMediaAsync(string mediaId, Stream destination, CancellationToken ct = default)
    {
        ValidateDownload(mediaId, destination);
        try
        {
            await DownloadMediaAsync(TempMediaPath, mediaId, destination, ct).ConfigureAwait(false);
            return;
        }
        catch (TencentException ex) when (ex.ErrCode == RangeRequiredErrorCode)
        {
            // 企业微信以 830002 指示该素材需要分块，请求出错时没有写入目标流。
        }

        var range = await DownloadRangeAsync(mediaId, destination, 0, MaxRangeSize, null, ct).ConfigureAwait(false);
        while (range.End + 1 < range.TotalLength)
        {
            range = await DownloadRangeAsync(
                mediaId, destination, range.End + 1, MaxRangeSize, range.TotalLength, ct).ConfigureAwait(false);
        }
    }

    /// <summary>将临时素材指定的单个分块写入目标流，并返回服务端实际提供的范围。</summary>
    /// <param name="mediaId">临时素材 ID</param>
    /// <param name="destination">接收分块的可写流，由调用方管理</param>
    /// <param name="offset">要读取的起始字节位置，从 0 开始</param>
    /// <param name="length">请求长度，最多 20 MiB。加密素材要求分块长度为 16 的倍数。</param>
    /// <param name="ct">取消令牌</param>
    public Task<MediaDownloadRange> DownloadTempMediaRangeAsync(
        string mediaId, Stream destination, long offset, int length, CancellationToken ct = default)
    {
        ValidateDownload(mediaId, destination);
        ArgumentOutOfRangeException.ThrowIfNegative(offset);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(length);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(length, MaxRangeSize);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(offset, long.MaxValue - (length - 1L));
        return DownloadRangeAsync(mediaId, destination, offset, length, null, ct);
    }

    /// <summary>获取高清语音素材（JSSDK 专用），返回文件字节</summary>
    public async Task<byte[]> GetJsSdkVoiceAsync(string mediaId, CancellationToken ct = default)
    {
        using var destination = new MemoryStream();
        await DownloadJsSdkVoiceAsync(mediaId, destination, ct).ConfigureAwait(false);
        return destination.ToArray();
    }

    /// <summary>将 JSSDK 高清语音素材写入目标流，目标流由调用方管理。</summary>
    public Task DownloadJsSdkVoiceAsync(string mediaId, Stream destination, CancellationToken ct = default)
    {
        ValidateDownload(mediaId, destination);
        return DownloadMediaAsync("/cgi-bin/media/get/jssdk", mediaId, destination, ct);
    }

    private Task DownloadMediaAsync(string path, string mediaId, Stream destination, CancellationToken ct)
        => _mediaHttp.GetWithTokenAsync(path, new() { ["media_id"] = mediaId }, async (response, responseCt) =>
        {
            await CheckDownloadErrorAsync(response, responseCt).ConfigureAwait(false);
            await response.Content.CopyToAsync(destination, responseCt).ConfigureAwait(false);
            return true;
        }, ct);

    private Task<MediaDownloadRange> DownloadRangeAsync(
        string mediaId, Stream destination, long offset, int length, long? expectedTotalLength, CancellationToken ct)
    {
        var requestedEnd = offset + (length - 1L);
        return _mediaHttp.GetWithTokenAsync(TempMediaPath, new() { ["media_id"] = mediaId }, async (response, responseCt) =>
        {
            await CheckDownloadErrorAsync(response, responseCt).ConfigureAwait(false);
            var headers = response.Content.Headers;
            if (response.StatusCode != HttpStatusCode.PartialContent ||
                headers.ContentRange is not { From: long start, To: long end, Length: long totalLength } contentRange ||
                !string.Equals(contentRange.Unit, "bytes", StringComparison.OrdinalIgnoreCase) ||
                start != offset || end < start || end > requestedEnd || end >= totalLength ||
                (expectedTotalLength.HasValue && expectedTotalLength.Value != totalLength))
            {
                throw new TencentException("临时素材分块响应的 Content-Range 与请求不符。");
            }

            var expectedLength = end - start + 1;
            if (headers.ContentLength is { } contentLength && contentLength != expectedLength)
                throw new TencentException("临时素材分块响应的 Content-Length 与 Content-Range 不符。");

            var source = await response.Content.ReadAsStreamAsync(responseCt).ConfigureAwait(false);
            await CopyRangeAsync(source, destination, expectedLength, responseCt).ConfigureAwait(false);
            return new MediaDownloadRange(start, end, totalLength);
        }, ct, request => request.Headers.Range = new RangeHeaderValue(offset, requestedEnd));
    }

    private Task CheckDownloadErrorAsync(HttpResponseMessage response, CancellationToken ct)
        => string.Equals(response.Content.Headers.ContentDisposition?.DispositionType, "attachment", StringComparison.OrdinalIgnoreCase)
            ? Task.CompletedTask
            : _mediaHttp.ThrowIfApiErrorAsync(response, ct);

    private static async Task CopyRangeAsync(Stream source, Stream destination, long length, CancellationToken ct)
    {
        var buffer = new byte[(int)Math.Min(length, 81920)];
        while (length > 0)
        {
            var count = await source.ReadAsync(buffer.AsMemory(0, (int)Math.Min(length, buffer.Length)), ct).ConfigureAwait(false);
            if (count == 0)
                throw new EndOfStreamException("临时素材分块响应提前结束。");

            await destination.WriteAsync(buffer.AsMemory(0, count), ct).ConfigureAwait(false);
            length -= count;
        }

        if (await source.ReadAsync(buffer.AsMemory(0, 1), ct).ConfigureAwait(false) != 0)
            throw new InvalidDataException("临时素材分块响应超出 Content-Range 声明的长度。");
    }

    private static void ValidateDownload(string mediaId, Stream destination)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(mediaId);
        ArgumentNullException.ThrowIfNull(destination);
        if (!destination.CanWrite)
            throw new ArgumentException("目标流必须可写。", nameof(destination));
    }

    /// <summary>异步上传临时素材（通过 URL），返回 jobid</summary>
    public async Task<string> UploadByUrlAsync(UploadByUrlRequest request, CancellationToken ct = default)
    {
        var result = await _http.PostAsync<UploadByUrlResponse>(
            "/cgi-bin/media/upload_by_url", request, ct).ConfigureAwait(false);
        return result.JobId ?? string.Empty;
    }

    /// <summary>获取异步上传临时素材的结果</summary>
    public async Task<GetUploadByUrlResultResponse> GetUploadByUrlResultAsync(string jobId, CancellationToken ct = default)
    {
        return await _http.PostQueryAsync<GetUploadByUrlResultResponse>(
            "/cgi-bin/media/get_upload_by_url_result",
            new GetUploadByUrlResultRequest { JobId = jobId }, ct).ConfigureAwait(false);
    }

    /// <summary>上传附件资源（客户联系专用），返回 media_id</summary>
    public async Task<string> UploadAttachmentAsync(string mediaType, int attachmentType, string fileName, ReadOnlyMemory<byte> fileData, CancellationToken ct = default)
    {
        using var form = BuildMediaForm(fileName, fileData);
        var result = await _mediaHttp.PostRawFormAsync<UploadAttachmentResponse>(
            "/cgi-bin/media/upload_attachment", form,
            new() { ["media_type"] = mediaType, ["attachment_type"] = attachmentType.ToString(CultureInfo.InvariantCulture) }, ct).ConfigureAwait(false);
        return result.MediaId ?? string.Empty;
    }
}
