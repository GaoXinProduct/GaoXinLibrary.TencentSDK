using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

/// <summary>公众号留言管理服务实现</summary>
public class OfficialCommentService
{
    private readonly WechatHttpClient _http;
    public OfficialCommentService(WechatHttpClient http) => _http = http;

    /// <summary>打开已群发文章评论</summary>
    public Task<CommentOperationResponse> OpenAsync(CommentOperationRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/open", request, ct);

    /// <summary>关闭已群发文章评论</summary>
    public Task<CommentOperationResponse> CloseAsync(CommentOperationRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/close", request, ct);

    /// <summary>查看指定文章的评论数据</summary>
    public Task<ListCommentResponse> ListAsync(ListCommentRequest request, CancellationToken ct = default)
        => _http.PostAsync<ListCommentResponse>("/cgi-bin/comment/list", request, ct);

    /// <summary>回复评论</summary>
    public Task<CommentOperationResponse> ReplyAsync(ReplyCommentRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/reply/add", request, ct);

    /// <summary>删除评论</summary>
    public Task<CommentOperationResponse> DeleteAsync(DeleteCommentRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/delete", request, ct);

    /// <summary>删除评论回复</summary>
    public Task<CommentOperationResponse> DeleteReplyAsync(DeleteCommentReplyRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/reply/delete", request, ct);

    /// <summary>将评论标记为精选</summary>
    public Task<CommentOperationResponse> MarkElectAsync(MarkElectCommentRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/markelect", request, ct);

    /// <summary>将评论取消精选</summary>
    public Task<CommentOperationResponse> UnmarkElectAsync(MarkElectCommentRequest request, CancellationToken ct = default)
        => _http.PostAsync<CommentOperationResponse>("/cgi-bin/comment/unmarkelect", request, ct);
}
