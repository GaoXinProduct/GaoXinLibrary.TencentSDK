using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Document;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>文档服务实现</summary>
public class DocumentService : IDocumentService
{
    private readonly WecomHttpClient _http;

    public DocumentService(WecomHttpClient http) => _http = http;

    public async Task<CreateDocResponse> CreateDocAsync(string docName, int docType = 1, string? folderId = null, CancellationToken ct = default)
        => await _http.PostAsync<CreateDocResponse>("/cgi-bin/wedoc/create_doc",
            new { doc_name = docName, doc_type = docType, folderId }, ct);

    public async Task<GetDocBaseInfoResponse> GetDocBaseInfoAsync(string docId, CancellationToken ct = default)
        => await _http.PostAsync<GetDocBaseInfoResponse>("/cgi-bin/wedoc/get_doc_base_info",
            new { docid = docId }, ct);

    public async Task RenameDocAsync(string docId, string docName, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/rename_doc",
            new { docid = docId, doc_name = docName }, ct);

    public async Task DeleteDocAsync(string docId, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/del_doc",
            new { docid = docId }, ct);

    public async Task ShareDocAsync(string docId, string[] userIds, CancellationToken ct = default)
        => await _http.PostAsync<WecomBaseResponse>("/cgi-bin/wedoc/doc_share",
            new { docid = docId, userid_list = userIds }, ct);
}
