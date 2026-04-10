using GaoXinLibrary.TencentSDK.Wecom.Models.Webhook;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>
/// 群机器人（Webhook）消息推送服务接口
/// <para>
/// 群机器人通过 Webhook 向企业微信群发送消息，无需 access_token。<br/>
/// 注册时通过 <c>AddWecomWebHookService</c> 绑定固定的 Webhook Key，注入后无需每次传入 Key。
/// </para>
/// </summary>
public interface IWebhookService
{
    /// <summary>
    /// 发送任意类型的 Webhook 消息
    /// <para>对应接口：POST /cgi-bin/webhook/send?key={webhookKey}</para>
    /// </summary>
    /// <param name="request">消息体，需设置 MsgType 及对应内容字段</param>
    /// <param name="ct">取消令牌</param>
    Task SendAsync(WebhookMessageRequest request, CancellationToken ct = default);

    /// <summary>
    /// 发送文本消息，支持 @指定成员
    /// </summary>
    /// <param name="content">消息内容，最长不超过2048字节</param>
    /// <param name="mentionedList">需要 @的成员 UserId 列表；使用 <c>"@all"</c> 可 @所有人</param>
    /// <param name="mentionedMobileList">需要 @的成员手机号列表；使用 <c>"@all"</c> 可 @所有人</param>
    /// <param name="ct">取消令牌</param>
    Task SendTextAsync(string content, string[]? mentionedList = null, string[]? mentionedMobileList = null, CancellationToken ct = default);

    /// <summary>
    /// 发送 Markdown 消息（支持企业微信 Markdown 语法）
    /// </summary>
    /// <param name="content">Markdown 内容，最长不超过4096字节</param>
    /// <param name="ct">取消令牌</param>
    Task SendMarkdownAsync(string content, CancellationToken ct = default);

    /// <summary>
    /// 发送图文消息（图文链接卡片列表）
    /// </summary>
    /// <param name="articles">图文卡片数组，最多8条</param>
    /// <param name="ct">取消令牌</param>
    Task SendNewsAsync(WebhookNewsArticle[] articles, CancellationToken ct = default);

    /// <summary>
    /// 发送图片消息（Base64 编码）
    /// </summary>
    /// <param name="base64">图片 Base64 编码内容，不超过2MB</param>
    /// <param name="md5">图片内容的 MD5 值，用于校验</param>
    /// <param name="ct">取消令牌</param>
    Task SendImageAsync(string base64, string md5, CancellationToken ct = default);

    /// <summary>
    /// 发送文件消息（通过 media_id 引用已上传的素材）
    /// </summary>
    /// <param name="mediaId">通过素材上传接口获取的 media_id</param>
    /// <param name="ct">取消令牌</param>
    Task SendFileAsync(string mediaId, CancellationToken ct = default);
}
