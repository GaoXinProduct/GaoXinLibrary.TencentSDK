using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Document;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>文档服务实现</summary>
public sealed class DocumentService
{
    private const int MaxInlineFileSize = 10 * 1024 * 1024;

    /// <summary>分块上传时每个完整分块的字节数</summary>
    public const int FileUploadBlockSize = 2 * 1024 * 1024;

    private readonly WecomHttpClient _http;

    public DocumentService(WecomHttpClient http) => _http = http;

    /// <summary>新建文档</summary>
    public async Task<CreateDocResponse> CreateDocAsync(CreateDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateDocResponse>("/cgi-bin/wedoc/create_doc", request, ct).ConfigureAwait(false);

    /// <summary>获取文档基础信息</summary>
    public async Task<GetDocBaseInfoResponse> GetDocBaseInfoAsync(DocIdRequest request, CancellationToken ct = default)
        => await _http.PostQueryAsync<GetDocBaseInfoResponse>("/cgi-bin/wedoc/get_doc_base_info", request, ct).ConfigureAwait(false);

    /// <summary>重命名文档</summary>
    public async Task RenameDocAsync(RenameDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/rename_doc", request, ct).ConfigureAwait(false);

    /// <summary>删除文档</summary>
    public async Task DeleteDocAsync(DocIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/del_doc", request, ct).ConfigureAwait(false);

    /// <summary>获取文档分享链接。使用 <see cref="GetDocShareLinkAsync"/> 读取链接。</summary>
    public Task ShareDocAsync(ShareDocRequest request, CancellationToken ct = default)
        => GetDocShareLinkAsync(request, ct);

    /// <summary>获取文档分享链接</summary>
    public Task<ShareDocResponse> GetDocShareLinkAsync(ShareDocRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<ShareDocResponse>("/cgi-bin/wedoc/doc_share", request, ct);

    /// <summary>获取文档的加入规则、成员权限及安全设置</summary>
    public Task<GetDocPermissionResponse> GetDocPermissionAsync(DocIdRequest request, CancellationToken ct = default)
        => _http.PostQueryAsync<GetDocPermissionResponse>("/cgi-bin/wedoc/doc_get_auth", request, ct);

    /// <summary>修改文档加入规则</summary>
    public Task ModifyDocJoinRuleAsync(ModifyDocJoinRuleRequest request, CancellationToken ct = default)
        => _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/mod_doc_join_rule", request, ct);

    /// <summary>新增、更新或移除文档成员</summary>
    public Task ModifyDocMembersAsync(ModifyDocMembersRequest request, CancellationToken ct = default)
        => _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/mod_doc_member", request, ct);

    /// <summary>修改文档安全设置</summary>
    public Task ModifyDocSecuritySettingsAsync(ModifyDocSecuritySettingsRequest request, CancellationToken ct = default)
        => _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/mod_doc_safty_setting", request, ct);

    /// <summary>上传文档图片</summary>
    public Task<UploadDocImageResponse> UploadDocImageAsync(UploadDocImageRequest request, CancellationToken ct = default)
        => _http.PostAsync<UploadDocImageResponse>("/cgi-bin/wedoc/image_upload", request, ct);

    /// <summary>上传不超过 10 MiB 的文档文件。较大的文件使用分块上传。</summary>
    public async Task<UploadDocFileResponse> UploadDocFileAsync(UploadDocFileRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (request.Content?.Length > MaxInlineFileSize)
            throw new ArgumentOutOfRangeException(nameof(request), "超过 10 MiB 的文件需使用分块上传。");

        return await _http.PostAsync<UploadDocFileResponse>("/cgi-bin/wedoc/file_upload", request, ct).ConfigureAwait(false);
    }

    /// <summary>初始化文档文件分块上传。命中秒传时可直接使用返回的文件链接。</summary>
    public Task<InitDocFileUploadResponse> InitDocFileUploadAsync(InitDocFileUploadRequest request, CancellationToken ct = default)
        => _http.PostAsync<InitDocFileUploadResponse>("/cgi-bin/wedoc/file_upload_init", request, ct);

    /// <summary>上传文档文件分块。分块序号从 1 开始。</summary>
    public async Task UploadDocFilePartAsync(UploadDocFilePartRequest request, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (request.Index < 1)
            throw new ArgumentOutOfRangeException(nameof(request), "分块序号必须大于等于 1。");
        if (request.Content?.Length > FileUploadBlockSize)
            throw new ArgumentOutOfRangeException(nameof(request), "文档文件分块不得超过 2 MiB。");

        await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/file_upload_part", request, ct).ConfigureAwait(false);
    }

    /// <summary>完成文档文件分块上传，获取文件链接</summary>
    public Task<UploadDocFileResponse> FinishDocFileUploadAsync(FinishDocFileUploadRequest request, CancellationToken ct = default)
        => _http.PostAsync<UploadDocFileResponse>("/cgi-bin/wedoc/file_upload_finish", request, ct);
}
