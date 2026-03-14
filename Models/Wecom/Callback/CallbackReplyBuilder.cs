using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 被动回复消息构建器
/// <para>用于构造回复给企业微信的 XML 消息明文（加密前）</para>
/// </summary>
public static class CallbackReplyBuilder
{
    /// <summary>
    /// 构建文本回复消息 XML
    /// </summary>
    /// <param name="toUserName">接收方（发送消息的用户 UserID）</param>
    /// <param name="fromUserName">发送方（企业 CorpID）</param>
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
    /// <param name="mediaId">图片媒体文件 ID</param>
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
    /// <param name="mediaId">语音媒体文件 ID</param>
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
    /// <param name="mediaId">视频媒体文件 ID</param>
    /// <param name="title">视频标题（非必填）</param>
    /// <param name="description">视频描述（非必填）</param>
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
    /// 构建图文回复消息 XML
    /// </summary>
    /// <param name="toUserName">接收方</param>
    /// <param name="fromUserName">发送方</param>
    /// <param name="articles">图文消息列表（最多8条）</param>
    /// <returns>XML 明文字符串</returns>
    public static string BuildNews(string toUserName, string fromUserName, CallbackReplyNewsArticle[] articles)
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

    /// <summary>
    /// 构建 Markdown 回复消息 XML（智能机器人专用）
    /// <para>参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101031"/></para>
    /// </summary>
    /// <param name="toUserName">接收方</param>
    /// <param name="fromUserName">发送方</param>
    /// <param name="content">Markdown 格式内容</param>
    /// <returns>XML 明文字符串</returns>
    public static string BuildMarkdown(string toUserName, string fromUserName, string content)
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return $"""
            <xml>
            <ToUserName><![CDATA[{toUserName}]]></ToUserName>
            <FromUserName><![CDATA[{fromUserName}]]></FromUserName>
            <CreateTime>{timestamp}</CreateTime>
            <MsgType><![CDATA[markdown]]></MsgType>
            <Markdown>
            <Content><![CDATA[{content}]]></Content>
            </Markdown>
            </xml>
            """;
    }

    /// <summary>
    /// 构建模版卡片回复消息 XML（智能机器人专用）
    /// <para>
    /// 支持 text_notice / news_notice / button_interaction / vote_interaction / multiple_interaction 等卡片类型。
    /// 参考文档：<see href="https://developer.work.weixin.qq.com/document/path/101032"/>
    /// </para>
    /// </summary>
    /// <param name="toUserName">接收方</param>
    /// <param name="fromUserName">发送方</param>
    /// <param name="templateCardXmlBody">模版卡片 XML 内容片段（TemplateCard 节点的完整内容）</param>
    /// <returns>XML 明文字符串</returns>
    public static string BuildTemplateCard(string toUserName, string fromUserName, string templateCardXmlBody)
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return $"""
            <xml>
            <ToUserName><![CDATA[{toUserName}]]></ToUserName>
            <FromUserName><![CDATA[{fromUserName}]]></FromUserName>
            <CreateTime>{timestamp}</CreateTime>
            <MsgType><![CDATA[template_card]]></MsgType>
            {templateCardXmlBody}
            </xml>
            """;
    }
}

