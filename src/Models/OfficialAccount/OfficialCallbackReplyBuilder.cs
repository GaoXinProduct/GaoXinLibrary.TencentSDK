using System.Xml.Linq;
using GaoXinLibrary.TencentSDK.Wechat.Core;

namespace GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 微信公众号被动回复消息构建器
/// <para>
/// 用于构造回复给微信服务器的 XML 消息明文（加密前或明文模式直接返回）。<br/>
/// 参考文档：<see href="https://developers.weixin.qq.com/doc/offiaccount/Message_Management/Passive_user_reply_message.html"/>
/// </para>
/// </summary>
public static class OfficialCallbackReplyBuilder
{
    /// <summary>
    /// 构建文本回复消息 XML
    /// </summary>
    /// <param name="toUserName">接收方（发送消息的用户 OpenID）</param>
    /// <param name="fromUserName">发送方（公众号原始 ID）</param>
    /// <param name="content">回复的文本内容</param>
    /// <returns>XML 明文字符串</returns>
    public static string BuildText(string toUserName, string fromUserName, string content)
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return $"""
            <xml>
            <ToUserName><![CDATA[{toUserName}]]></ToUserName>
            <FromUserName><![CDATA[{fromUserName}]]></FromUserName>
            <CreateTime>{timestamp}</CreateTime>
            <MsgType><![CDATA[text]]></MsgType>
            <Content><![CDATA[{content}]]></Content>
            </xml>
            """;
    }

    /// <summary>
    /// 构建图片回复消息 XML
    /// </summary>
    /// <param name="toUserName">接收方</param>
    /// <param name="fromUserName">发送方</param>
    /// <param name="mediaId">通过素材管理中的接口上传多媒体文件，得到的 ID</param>
    /// <returns>XML 明文字符串</returns>
    public static string BuildImage(string toUserName, string fromUserName, string mediaId)
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return $"""
            <xml>
            <ToUserName><![CDATA[{toUserName}]]></ToUserName>
            <FromUserName><![CDATA[{fromUserName}]]></FromUserName>
            <CreateTime>{timestamp}</CreateTime>
            <MsgType><![CDATA[image]]></MsgType>
            <Image>
            <MediaId><![CDATA[{mediaId}]]></MediaId>
            </Image>
            </xml>
            """;
    }

    /// <summary>
    /// 构建语音回复消息 XML
    /// </summary>
    /// <param name="toUserName">接收方</param>
    /// <param name="fromUserName">发送方</param>
    /// <param name="mediaId">通过素材管理接口上传多媒体文件，得到的 ID</param>
    /// <returns>XML 明文字符串</returns>
    public static string BuildVoice(string toUserName, string fromUserName, string mediaId)
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return $"""
            <xml>
            <ToUserName><![CDATA[{toUserName}]]></ToUserName>
            <FromUserName><![CDATA[{fromUserName}]]></FromUserName>
            <CreateTime>{timestamp}</CreateTime>
            <MsgType><![CDATA[voice]]></MsgType>
            <Voice>
            <MediaId><![CDATA[{mediaId}]]></MediaId>
            </Voice>
            </xml>
            """;
    }

    /// <summary>
    /// 构建视频回复消息 XML
    /// </summary>
    /// <param name="toUserName">接收方</param>
    /// <param name="fromUserName">发送方</param>
    /// <param name="mediaId">通过素材管理接口上传多媒体文件，得到的 ID</param>
    /// <param name="title">视频消息的标题</param>
    /// <param name="description">视频消息的描述</param>
    /// <returns>XML 明文字符串</returns>
    public static string BuildVideo(string toUserName, string fromUserName, string mediaId, string? title = null, string? description = null)
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return $"""
            <xml>
            <ToUserName><![CDATA[{toUserName}]]></ToUserName>
            <FromUserName><![CDATA[{fromUserName}]]></FromUserName>
            <CreateTime>{timestamp}</CreateTime>
            <MsgType><![CDATA[video]]></MsgType>
            <Video>
            <MediaId><![CDATA[{mediaId}]]></MediaId>
            <Title><![CDATA[{title ?? string.Empty}]]></Title>
            <Description><![CDATA[{description ?? string.Empty}]]></Description>
            </Video>
            </xml>
            """;
    }

    /// <summary>
    /// 构建音乐回复消息 XML
    /// </summary>
    /// <param name="toUserName">接收方</param>
    /// <param name="fromUserName">发送方</param>
    /// <param name="thumbMediaId">缩略图的媒体 ID</param>
    /// <param name="title">音乐标题</param>
    /// <param name="description">音乐描述</param>
    /// <param name="musicUrl">音乐链接</param>
    /// <param name="hqMusicUrl">高质量音乐链接</param>
    /// <returns>XML 明文字符串</returns>
    public static string BuildMusic(string toUserName, string fromUserName, string thumbMediaId,
        string? title = null, string? description = null, string? musicUrl = null, string? hqMusicUrl = null)
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return $"""
            <xml>
            <ToUserName><![CDATA[{toUserName}]]></ToUserName>
            <FromUserName><![CDATA[{fromUserName}]]></FromUserName>
            <CreateTime>{timestamp}</CreateTime>
            <MsgType><![CDATA[music]]></MsgType>
            <Music>
            <Title><![CDATA[{title ?? string.Empty}]]></Title>
            <Description><![CDATA[{description ?? string.Empty}]]></Description>
            <MusicUrl><![CDATA[{musicUrl ?? string.Empty}]]></MusicUrl>
            <HQMusicUrl><![CDATA[{hqMusicUrl ?? string.Empty}]]></HQMusicUrl>
            <ThumbMediaId><![CDATA[{thumbMediaId}]]></ThumbMediaId>
            </Music>
            </xml>
            """;
    }

    /// <summary>
    /// 构建图文回复消息 XML
    /// </summary>
    /// <param name="toUserName">接收方</param>
    /// <param name="fromUserName">发送方</param>
    /// <param name="articles">图文消息列表（最多 8 条）</param>
    /// <returns>XML 明文字符串</returns>
    public static string BuildNews(string toUserName, string fromUserName, OfficialCallbackReplyNewsArticle[] articles)
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var items = string.Join("\n", articles.Select(a => $"""
            <item>
            <Title><![CDATA[{a.Title}]]></Title>
            <Description><![CDATA[{a.Description ?? string.Empty}]]></Description>
            <PicUrl><![CDATA[{a.PicUrl ?? string.Empty}]]></PicUrl>
            <Url><![CDATA[{a.Url ?? string.Empty}]]></Url>
            </item>
            """));
        return $"""
            <xml>
            <ToUserName><![CDATA[{toUserName}]]></ToUserName>
            <FromUserName><![CDATA[{fromUserName}]]></FromUserName>
            <CreateTime>{timestamp}</CreateTime>
            <MsgType><![CDATA[news]]></MsgType>
            <ArticleCount>{articles.Length}</ArticleCount>
            <Articles>
            {items}
            </Articles>
            </xml>
            """;
    }
}

