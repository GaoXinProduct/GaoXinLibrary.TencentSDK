using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Document;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>文档服务实现</summary>
public class DocumentService : IDocumentService
{
    private readonly WecomHttpClient _http;

    public DocumentService(WecomHttpClient http) => _http = http;

    public async Task<CreateDocResponse> CreateDocAsync(CreateDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CreateDocResponse>("/cgi-bin/wedoc/create_doc", request, ct);

    public async Task<GetDocBaseInfoResponse> GetDocBaseInfoAsync(DocIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetDocBaseInfoResponse>("/cgi-bin/wedoc/get_doc_base_info", request, ct);

    public async Task RenameDocAsync(RenameDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/rename_doc", request, ct);

    public async Task DeleteDocAsync(DocIdRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/del_doc", request, ct);

    public async Task ShareDocAsync(ShareDocRequest request, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/doc_share", request, ct);
}
