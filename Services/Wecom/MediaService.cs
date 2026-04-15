using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Media;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public class MediaService
{
    private readonly WecomHttpClient _http;
    private readonly AccessTokenProvider _tokenProvider;
    private readonly HttpClient _rawHttpClient;
    private readonly string _baseUrl;

    public MediaService(WecomHttpClient http, AccessTokenProvider tokenProvider, HttpClient rawHttpClient, string baseUrl)
    {
        _http = http;
        _tokenProvider = tokenProvider;
        _rawHttpClient = rawHttpClient;
        _baseUrl = baseUrl.TrimEnd('/');
    }

    // 手动拼接 multipart/form-data 原始字节，完全绕过 .NET 的 MultipartFormDataContent
    // 及其 RFC 5987 filename* 编码，保证发送给企业微信的字节与文档格式完全一致：
    // Content-Disposition: form-data; name="media"; filename="xxx"; filelength=yyy
    private static ByteArrayContent BuildMediaForm(string fileName, ReadOnlyMemory<byte> fileData)
    {
        var boundary = System.Guid.NewGuid().ToString("N");
        var partHeader = System.Text.Encoding.UTF8.GetBytes(
            $"--{boundary}\r\n" +
            $"Content-Disposition: form-data; name=\"media\"; filename=\"{fileName}\"; filelength={fileData.Length}\r\n" +
            $"Content-Type: application/octet-stream\r\n\r\n");
        var partFooter = System.Text.Encoding.UTF8.GetBytes($"\r\n--{boundary}--\r\n");

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
        var token = await _tokenProvider.GetTokenAsync(ct);
        var url = $"{_baseUrl}/cgi-bin/media/upload?access_token={token}&type={type}";
        using var form = BuildMediaForm(fileName, fileData);
        var response = await _rawHttpClient.PostAsync(url, form, ct);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(ct);
        var result = System.Text.Json.JsonSerializer.Deserialize<UploadMediaResponse>(json, WecomHttpClient.JsonOptions)
                     ?? throw new TencentException("上传素材响应为空");
        if (result.ErrCode != 0) throw new TencentException(result.ErrCode, result.ErrMsg ?? string.Empty, "企业微信");
        return result.MediaId ?? string.Empty;
    }

    /// <summary>上传图片素材，返回永久 URL（不受10MB限制，上限2048px）</summary>
    public async Task<string> UploadImageAsync(string fileName, ReadOnlyMemory<byte> fileData, CancellationToken ct = default)
    {
        var token = await _tokenProvider.GetTokenAsync(ct);
        var url = $"{_baseUrl}/cgi-bin/media/uploadimg?access_token={token}";
        using var form = BuildMediaForm(fileName, fileData);
        var response = await _rawHttpClient.PostAsync(url, form, ct);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(ct);
        var result = System.Text.Json.JsonSerializer.Deserialize<UploadImageResponse>(json, WecomHttpClient.JsonOptions)
                     ?? throw new TencentException("上传图片响应为空");
        if (result.ErrCode != 0) throw new TencentException(result.ErrCode, result.ErrMsg ?? string.Empty, "企业微信");
        return result.Url ?? string.Empty;
    }

    /// <summary>获取临时素材，返回文件字节</summary>
    public async Task<byte[]> GetTempMediaAsync(string mediaId, CancellationToken ct = default)
    {
        var token = await _tokenProvider.GetTokenAsync(ct);
        var url = $"{_baseUrl}/cgi-bin/media/get?access_token={token}&media_id={mediaId}";
        var response = await _rawHttpClient.GetAsync(url, ct);
        response.EnsureSuccessStatusCode();
        // 企业微信在出错时以 HTTP 200 返回 JSON 错误体，需要区分文件流与错误响应
        if (response.Content.Headers.ContentType?.MediaType == "application/json")
        {
            var json = await response.Content.ReadAsStringAsync(ct);
            var error = System.Text.Json.JsonSerializer.Deserialize<WecomBaseResponse>(json, WecomHttpClient.JsonOptions)
                        ?? throw new TencentException("获取临时素材响应为空");
            throw new TencentException(error.ErrCode, error.ErrMsg ?? string.Empty, "企业微信");
        }
        return await response.Content.ReadAsByteArrayAsync(ct);
    }

    /// <summary>获取高清语音素材（JSSDK 专用），返回文件字节</summary>
    public async Task<byte[]> GetJsSdkVoiceAsync(string mediaId, CancellationToken ct = default)
    {
        var token = await _tokenProvider.GetTokenAsync(ct);
        var url = $"{_baseUrl}/cgi-bin/media/get/jssdk?access_token={token}&media_id={mediaId}";
        var response = await _rawHttpClient.GetAsync(url, ct);
        response.EnsureSuccessStatusCode();
        // 企业微信在出错时以 HTTP 200 返回 JSON 错误体，需要区分文件流与错误响应
        if (response.Content.Headers.ContentType?.MediaType == "application/json")
        {
            var json = await response.Content.ReadAsStringAsync(ct);
            var error = System.Text.Json.JsonSerializer.Deserialize<WecomBaseResponse>(json, WecomHttpClient.JsonOptions)
                        ?? throw new TencentException("获取高清语音素材响应为空");
            throw new TencentException(error.ErrCode, error.ErrMsg ?? string.Empty, "企业微信");
        }
        return await response.Content.ReadAsByteArrayAsync(ct);
    }

    /// <summary>异步上传临时素材（通过 URL），返回 jobid</summary>
    public async Task<string> UploadByUrlAsync(UploadByUrlRequest request, CancellationToken ct = default)
    {
        var result = await _http.PostAsync<UploadByUrlResponse>(
            "/cgi-bin/media/upload_by_url", request, ct);
        return result.JobId ?? string.Empty;
    }

    /// <summary>获取异步上传临时素材的结果</summary>
    public async Task<GetUploadByUrlResultResponse> GetUploadByUrlResultAsync(string jobId, CancellationToken ct = default)
    {
        return await _http.PostAsync<GetUploadByUrlResultResponse>(
            "/cgi-bin/media/get_upload_by_url_result",
            new GetUploadByUrlResultRequest { JobId = jobId }, ct);
    }

    /// <summary>上传附件资源（客户联系专用），返回 media_id</summary>
    public async Task<string> UploadAttachmentAsync(string mediaType, int attachmentType, string fileName, ReadOnlyMemory<byte> fileData, CancellationToken ct = default)
    {
        var token = await _tokenProvider.GetTokenAsync(ct);
        var url = $"{_baseUrl}/cgi-bin/media/upload_attachment?access_token={token}&media_type={mediaType}&attachment_type={attachmentType}";
        using var form = BuildMediaForm(fileName, fileData);
        var response = await _rawHttpClient.PostAsync(url, form, ct);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(ct);
        var result = System.Text.Json.JsonSerializer.Deserialize<UploadAttachmentResponse>(json, WecomHttpClient.JsonOptions)
                     ?? throw new TencentException("上传附件资源响应为空");
        if (result.ErrCode != 0) throw new TencentException(result.ErrCode, result.ErrMsg ?? string.Empty, "企业微信");
        return result.MediaId ?? string.Empty;
    }
}
