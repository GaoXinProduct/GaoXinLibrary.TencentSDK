using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号留言管理服务实现</summary>
public class OfficialCommentService : IOfficialCommentService
{
    private readonly WechatHttpClient _http;
    public OfficialCommentService(WechatHttpClient http) => _http = http;

    public Task<CommentOperationResponse> OpenAsync(CommentOperationRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/open", request, ct);

    public Task<CommentOperationResponse> CloseAsync(CommentOperationRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/close", request, ct);

    public Task<ListCommentResponse> ListAsync(ListCommentRequest request, CancellationToken ct = default)
        => _http.PostAsync<ListCommentResponse>("/cgi-bin/comment/list", request, ct);

    public Task<CommentOperationResponse> ReplyAsync(ReplyCommentRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/reply/add", request, ct);

    public Task<CommentOperationResponse> DeleteAsync(DeleteCommentRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/delete", request, ct);

    public Task<CommentOperationResponse> DeleteReplyAsync(DeleteCommentReplyRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/reply/delete", request, ct);

    public Task<CommentOperationResponse> MarkElectAsync(MarkElectCommentRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/markelect", request, ct);

    public Task<CommentOperationResponse> UnmarkElectAsync(MarkElectCommentRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/unmarkelect", request, ct);
}

// ═══════════════════════════════════════════════════════════════════════════
//  公众号客服消息服务

