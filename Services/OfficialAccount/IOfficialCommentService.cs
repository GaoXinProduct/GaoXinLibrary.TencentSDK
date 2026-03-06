using System.Security.Cryptography;
using System.Text;
using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

namespace GaoXinLibrary.TencentSDK.Wechat.Services;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>公众号留言管理服务接口</summary>
public interface IOfficialCommentService
{
    /// <summary>打开已群发文章评论</summary>
    Task<CommentOperationResponse> OpenAsync(CommentOperationRequest request, CancellationToken ct = default);
    /// <summary>关闭已群发文章评论</summary>
    Task<CommentOperationResponse> CloseAsync(CommentOperationRequest request, CancellationToken ct = default);
    /// <summary>查看指定文章的评论数据</summary>
    Task<ListCommentResponse> ListAsync(ListCommentRequest request, CancellationToken ct = default);
    /// <summary>回复评论</summary>
    Task<CommentOperationResponse> ReplyAsync(ReplyCommentRequest request, CancellationToken ct = default);
    /// <summary>删除评论</summary>
    Task<CommentOperationResponse> DeleteAsync(DeleteCommentRequest request, CancellationToken ct = default);
    /// <summary>删除评论回复</summary>
    Task<CommentOperationResponse> DeleteReplyAsync(DeleteCommentReplyRequest request, CancellationToken ct = default);
    /// <summary>将评论标记为精选</summary>
    Task<CommentOperationResponse> MarkElectAsync(MarkElectCommentRequest request, CancellationToken ct = default);
    /// <summary>将评论取消精选</summary>
    Task<CommentOperationResponse> UnmarkElectAsync(MarkElectCommentRequest request, CancellationToken ct = default);
}

