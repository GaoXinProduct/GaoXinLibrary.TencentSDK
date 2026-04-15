using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Document;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>文档服务实现</summary>
public class DocumentService
{
    private readonly WecomHttpClient _http;

    public DocumentService(WecomHttpClient http) => _http = http;

    /// <summary>新建文档</summary>
    public async Task<CreateDocResponse> CreateDocAsync(CreateDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateDocResponse>("/cgi-bin/wedoc/create_doc", request, ct);

    /// <summary>获取文档基础信息</summary>
    public async Task<GetDocBaseInfoResponse> GetDocBaseInfoAsync(DocIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDocBaseInfoResponse>("/cgi-bin/wedoc/get_doc_base_info", request, ct);

    /// <summary>重命名文档</summary>
    public async Task RenameDocAsync(RenameDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/rename_doc", request, ct);

    /// <summary>删除文档</summary>
    public async Task DeleteDocAsync(DocIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/del_doc", request, ct);

    /// <summary>分享文档</summary>
    public async Task ShareDocAsync(ShareDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/doc_share", request, ct);
}
