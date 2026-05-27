using System.Text.Encodings.Web;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public class OfficialAccountModelTests
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    // ═══════════════════════════════════════════════════════════════════════
    // OAuth Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void OAuthAccessTokenResponse_DeserializesCorrectly()
    {
        var json = "{\"access_token\":\"token123\",\"expires_in\":7200,\"refresh_token\":\"refresh456\"," +
                   "\"openid\":\"openid789\",\"scope\":\"snsapi_userinfo\",\"unionid\":\"unionid000\"}";

        var resp = JsonSerializer.Deserialize<OAuthAccessTokenResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("token123", resp.AccessToken);
        Assert.Equal(7200, resp.ExpiresIn);
        Assert.Equal("refresh456", resp.RefreshToken);
        Assert.Equal("openid789", resp.OpenId);
        Assert.Equal("snsapi_userinfo", resp.Scope);
        Assert.Equal("unionid000", resp.UnionId);
    }

    [Fact]
    public void OAuthAccessTokenResponse_InheritsWechatBaseResponse()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"access_token\":\"t\",\"expires_in\":7200}";

        var resp = JsonSerializer.Deserialize<OAuthAccessTokenResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("ok", resp.ErrMsg);
    }

    [Fact]
    public void OAuthUserInfoResponse_DeserializesCorrectly()
    {
        var json = "{\"openid\":\"o123\",\"nickname\":\"TestUser\",\"sex\":1," +
                   "\"province\":\"Guangdong\",\"city\":\"Shenzhen\",\"country\":\"CN\"," +
                   "\"headimgurl\":\"https://example.com/avatar.jpg\"," +
                   "\"privilege\":[\"PRIVILEGE1\",\"PRIVILEGE2\"],\"unionid\":\"u456\"}";

        var resp = JsonSerializer.Deserialize<OAuthUserInfoResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("o123", resp.OpenId);
        Assert.Equal("TestUser", resp.Nickname);
        Assert.Equal(1, resp.Sex);
        Assert.Equal("Guangdong", resp.Province);
        Assert.Equal("Shenzhen", resp.City);
        Assert.Equal("CN", resp.Country);
        Assert.Equal("https://example.com/avatar.jpg", resp.HeadImgUrl);
        Assert.NotNull(resp.Privilege);
        Assert.Equal(2, resp.Privilege.Count);
        Assert.Equal("PRIVILEGE1", resp.Privilege[0]);
        Assert.Equal("u456", resp.UnionId);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Menu Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void CreateMenuRequest_SerializesCorrectly()
    {
        var req = new CreateMenuRequest
        {
            Button =
            [
                new MenuButton { Name = "menu1", Type = "click", Key = "key1" },
                new MenuButton { Name = "menu2", Type = "view", Url = "https://example.com" }
            ]
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"button\":[", json);
        Assert.Contains("\"name\":\"menu1\"", json);
        Assert.Contains("\"type\":\"click\"", json);
        Assert.Contains("\"key\":\"key1\"", json);
        Assert.Contains("\"name\":\"menu2\"", json);
        Assert.Contains("\"type\":\"view\"", json);
        Assert.Contains("\"url\":\"https://example.com\"", json);
    }

    [Fact]
    public void MenuButton_SerializesWithSubButtonsCorrectly()
    {
        var button = new MenuButton
        {
            Name = "main",
            SubButton =
            [
                new MenuButton { Name = "sub1", Type = "click", Key = "sub_key1" },
                new MenuButton { Name = "sub2", Type = "miniprogram", Url = "https://mp.com", AppId = "wx123", PagePath = "pages/index" }
            ]
        };

        var json = JsonSerializer.Serialize(button, JsonOptions);

        Assert.Contains("\"name\":\"main\"", json);
        Assert.Contains("\"sub_button\":[", json);
        Assert.Contains("\"name\":\"sub1\"", json);
        Assert.Contains("\"key\":\"sub_key1\"", json);
        Assert.Contains("\"name\":\"sub2\"", json);
        Assert.Contains("\"appid\":\"wx123\"", json);
        Assert.Contains("\"pagepath\":\"pages/index\"", json);
    }

    [Fact]
    public void MenuButton_SerializesMediaIdCorrectly()
    {
        var button = new MenuButton
        {
            Name = "image",
            Type = "media_id",
            MediaId = "media_abc123"
        };

        var json = JsonSerializer.Serialize(button, JsonOptions);

        Assert.Contains("\"name\":\"image\"", json);
        Assert.Contains("\"type\":\"media_id\"", json);
        Assert.Contains("\"media_id\":\"media_abc123\"", json);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Template Message Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void SendTemplateMessageRequest_SerializesCorrectly()
    {
        var req = new SendTemplateMessageRequest
        {
            ToUser = "openid123",
            TemplateId = "tmpl_abc",
            Url = "https://example.com/detail",
            Data = new Dictionary<string, TemplateDataValue>
            {
                ["first"] = new TemplateDataValue { Value = "Hello", Color = "#173177" },
                ["remark"] = new TemplateDataValue { Value = "Thank you" }
            }
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        Assert.Equal("openid123", root.GetProperty("touser").GetString());
        Assert.Equal("tmpl_abc", root.GetProperty("template_id").GetString());
        Assert.Equal("https://example.com/detail", root.GetProperty("url").GetString());
        Assert.True(root.TryGetProperty("data", out var data));
        Assert.Equal("Hello", data.GetProperty("first").GetProperty("value").GetString());
        Assert.Equal("#173177", data.GetProperty("first").GetProperty("color").GetString());
        Assert.Equal("Thank you", data.GetProperty("remark").GetProperty("value").GetString());
    }

    [Fact]
    public void SendTemplateMessageRequest_SerializesWithMiniProgram()
    {
        var req = new SendTemplateMessageRequest
        {
            ToUser = "openid456",
            TemplateId = "tmpl_xyz",
            MiniProgram = new TemplateMiniProgram { AppId = "wxappid", PagePath = "pages/detail" },
            Data = new Dictionary<string, TemplateDataValue>
            {
                ["keyword1"] = new TemplateDataValue { Value = "data1" }
            },
            ClientMsgId = "msg_id_001"
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        Assert.Equal("openid456", root.GetProperty("touser").GetString());
        Assert.Equal("tmpl_xyz", root.GetProperty("template_id").GetString());
        Assert.Equal("wxappid", root.GetProperty("miniprogram").GetProperty("appid").GetString());
        Assert.Equal("pages/detail", root.GetProperty("miniprogram").GetProperty("pagepath").GetString());
        Assert.Equal("msg_id_001", root.GetProperty("client_msg_id").GetString());
        Assert.Equal("data1", root.GetProperty("data").GetProperty("keyword1").GetProperty("value").GetString());
    }

    [Fact]
    public void TemplateMiniProgram_SerializesCorrectly()
    {
        var mp = new TemplateMiniProgram { AppId = "wx123", PagePath = "pages/home" };

        var json = JsonSerializer.Serialize(mp, JsonOptions);

        Assert.Contains("\"appid\":\"wx123\"", json);
        Assert.Contains("\"pagepath\":\"pages/home\"", json);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // User Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void UserInfoResponse_DeserializesCorrectly()
    {
        var json = "{\"subscribe\":1,\"openid\":\"openid123\",\"language\":\"zh_CN\"," +
                   "\"subscribe_time\":1609459200,\"unionid\":\"unionid456\"," +
                   "\"remark\":\"test remark\",\"groupid\":10," +
                   "\"tagid_list\":[100,101],\"subscribe_scene\":\"ADD_SCENE_QR_CODE\"," +
                   "\"qr_scene\":123,\"qr_scene_str\":\"scene_str_abc\"}";

        var resp = JsonSerializer.Deserialize<UserInfoResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal(1, resp.Subscribe);
        Assert.Equal("openid123", resp.OpenId);
        Assert.Equal("zh_CN", resp.Language);
        Assert.Equal(1609459200L, resp.SubscribeTime);
        Assert.Equal("unionid456", resp.UnionId);
        Assert.Equal("test remark", resp.Remark);
        Assert.Equal(10, resp.GroupId);
        Assert.NotNull(resp.TagIdList);
        Assert.Equal(2, resp.TagIdList.Count);
        Assert.Equal(100, resp.TagIdList[0]);
        Assert.Equal("ADD_SCENE_QR_CODE", resp.SubscribeScene);
        Assert.Equal(123, resp.QrScene);
        Assert.Equal("scene_str_abc", resp.QrSceneStr);
    }

    [Fact]
    public void BatchGetUserInfoRequest_SerializesCorrectly()
    {
        var req = new BatchGetUserInfoRequest
        {
            UserList =
            [
                new BatchGetUserItem { OpenId = "openid1", Lang = "zh_CN" },
                new BatchGetUserItem { OpenId = "openid2" }
            ]
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"user_list\":[", json);
        Assert.Contains("\"openid\":\"openid1\"", json);
        Assert.Contains("\"lang\":\"zh_CN\"", json);
        Assert.Contains("\"openid\":\"openid2\"", json);
    }

    [Fact]
    public void BatchGetUserInfoResponse_DeserializesCorrectly()
    {
        var json = "{\"user_info_list\":[" +
                   "{\"subscribe\":1,\"openid\":\"o1\",\"language\":\"zh_CN\",\"subscribe_time\":1000}," +
                   "{\"subscribe\":0,\"openid\":\"o2\"}" +
                   "]}";

        var resp = JsonSerializer.Deserialize<BatchGetUserInfoResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.NotNull(resp.UserInfoList);
        Assert.Equal(2, resp.UserInfoList.Count);
        Assert.Equal("o1", resp.UserInfoList[0].OpenId);
        Assert.Equal(1, resp.UserInfoList[0].Subscribe);
        Assert.Equal("o2", resp.UserInfoList[1].OpenId);
        Assert.Equal(0, resp.UserInfoList[1].Subscribe);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Material Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void AddMaterialResponse_DeserializesCorrectly()
    {
        var json = "{\"media_id\":\"media_abc\",\"url\":\"https://example.com/img.jpg\"}";

        var resp = JsonSerializer.Deserialize<AddMaterialResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("media_abc", resp.MediaId);
        Assert.Equal("https://example.com/img.jpg", resp.Url);
    }

    [Fact]
    public void BatchGetMaterialRequest_SerializesCorrectly()
    {
        var req = new BatchGetMaterialRequest
        {
            Type = "image",
            Offset = 0,
            Count = 10
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"type\":\"image\"", json);
        Assert.Contains("\"offset\":0", json);
        Assert.Contains("\"count\":10", json);
    }

    [Fact]
    public void BatchGetMaterialResponse_DeserializesCorrectly()
    {
        var json = "{\"total_count\":5,\"item_count\":2,\"item\":[" +
                   "{\"media_id\":\"m1\",\"name\":\"img1.png\",\"update_time\":1609459200,\"url\":\"https://example.com/img1.png\"}," +
                   "{\"media_id\":\"m2\",\"name\":\"img2.png\",\"update_time\":1609459300,\"url\":\"https://example.com/img2.png\"}" +
                   "]}";

        var resp = JsonSerializer.Deserialize<BatchGetMaterialResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal(5, resp.TotalCount);
        Assert.Equal(2, resp.ItemCount);
        Assert.NotNull(resp.Item);
        Assert.Equal(2, resp.Item.Count);
        Assert.Equal("m1", resp.Item[0].MediaId);
        Assert.Equal("img1.png", resp.Item[0].Name);
        Assert.Equal(1609459200L, resp.Item[0].UpdateTime);
        Assert.Equal("https://example.com/img1.png", resp.Item[0].Url);
        Assert.Equal("m2", resp.Item[1].MediaId);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Draft Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void AddDraftRequest_SerializesCorrectly()
    {
        var req = new AddDraftRequest
        {
            Articles =
            [
                new DraftArticle
                {
                    Title = "Test Title",
                    Author = "Author",
                    Digest = "Digest summary",
                    Content = "<p>Content here</p>",
                    ContentSourceUrl = "https://example.com/source",
                    ThumbMediaId = "thumb_media_123",
                    ShowCoverPic = 1,
                    NeedOpenComment = 1,
                    OnlyFansCanComment = 0
                }
            ]
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        using var doc = JsonDocument.Parse(json);
        var articles = doc.RootElement.GetProperty("articles");
        var article = articles[0];

        Assert.Equal("Test Title", article.GetProperty("title").GetString());
        Assert.Equal("Author", article.GetProperty("author").GetString());
        Assert.Equal("Digest summary", article.GetProperty("digest").GetString());
        Assert.Equal("<p>Content here</p>", article.GetProperty("content").GetString());
        Assert.Equal("https://example.com/source", article.GetProperty("content_source_url").GetString());
        Assert.Equal("thumb_media_123", article.GetProperty("thumb_media_id").GetString());
        Assert.Equal(1, article.GetProperty("show_cover_pic").GetInt32());
        Assert.Equal(1, article.GetProperty("need_open_comment").GetInt32());
        Assert.Equal(0, article.GetProperty("only_fans_can_comment").GetInt32());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Publish Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void SubmitPublishRequest_SerializesCorrectly()
    {
        var req = new SubmitPublishRequest { MediaId = "media_publish_123" };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"media_id\":\"media_publish_123\"", json);
    }

    [Fact]
    public void SubmitPublishResponse_DeserializesCorrectly()
    {
        var json = "{\"publish_id\":\"pub_12345\"}";

        var resp = JsonSerializer.Deserialize<SubmitPublishResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("pub_12345", resp.PublishId);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Comment Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void ListCommentRequest_SerializesCorrectly()
    {
        var req = new ListCommentRequest
        {
            MsgDataId = 1234567890,
            Index = 1,
            Begin = 0,
            Count = 20,
            Type = 0
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"msg_data_id\":1234567890", json);
        Assert.Contains("\"index\":1", json);
        Assert.Contains("\"begin\":0", json);
        Assert.Contains("\"count\":20", json);
        Assert.Contains("\"type\":0", json);
    }

    [Fact]
    public void ListCommentResponse_DeserializesCorrectly()
    {
        var json = "{\"total\":2,\"comment\":[" +
                   "{\"user_comment_id\":1,\"openid\":\"openid_c1\",\"create_time\":1609459200," +
                   "\"content\":\"评论内容1\",\"comment_type\":0," +
                   "\"reply\":{\"content\":\"回复内容\",\"create_time\":1609459300}}," +
                   "{\"user_comment_id\":2,\"openid\":\"openid_c2\",\"create_time\":1609459400," +
                   "\"content\":\"评论内容2\",\"comment_type\":1}" +
                   "]}";

        var resp = JsonSerializer.Deserialize<ListCommentResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal(2, resp.Total);
        Assert.NotNull(resp.Comment);
        Assert.Equal(2, resp.Comment.Count);

        Assert.Equal(1L, resp.Comment[0].UserCommentId);
        Assert.Equal("openid_c1", resp.Comment[0].OpenId);
        Assert.Equal(1609459200L, resp.Comment[0].CreateTime);
        Assert.Equal("评论内容1", resp.Comment[0].Content);
        Assert.Equal(0, resp.Comment[0].CommentType);
        Assert.NotNull(resp.Comment[0].Reply);
        Assert.Equal("回复内容", resp.Comment[0].Reply!.Content);
        Assert.Equal(1609459300L, resp.Comment[0].Reply!.CreateTime);

        Assert.Equal(2L, resp.Comment[1].UserCommentId);
        Assert.Equal(1, resp.Comment[1].CommentType);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // QR Code Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void CreateQrCodeResponse_DeserializesCorrectly()
    {
        var json = "{\"ticket\":\"gQH47joAAAAAAAAAASxodHRw...\",\"expire_seconds\":2592000," +
                   "\"url\":\"https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=gQH47...\"}";

        var resp = JsonSerializer.Deserialize<CreateQrCodeResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("gQH47joAAAAAAAAAASxodHRw...", resp.Ticket);
        Assert.Equal(2592000, resp.ExpireSeconds);
        Assert.Equal("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=gQH47...", resp.Url);
    }

    [Fact]
    public void CreateQrCodeResponse_DeserializesPermanentQrCode()
    {
        var json = "{\"ticket\":\"gQGq7joAAAAAAAAAASxodHRw...\"," +
                   "\"url\":\"https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=gQGq7...\"}";

        var resp = JsonSerializer.Deserialize<CreateQrCodeResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("gQGq7joAAAAAAAAAASxodHRw...", resp.Ticket);
        Assert.NotNull(resp.Url);
        Assert.Null(resp.ExpireSeconds); // permanent QR codes have no expire_seconds
    }

    [Fact]
    public void DraftArticle_SerializesCorrectly()
    {
        var article = new DraftArticle
        {
            Title = "Article Title",
            Author = "Author Name",
            Digest = "Digest text",
            Content = "<p>Article content</p>",
            ContentSourceUrl = "https://source.com",
            ThumbMediaId = "thumb_001",
            ShowCoverPic = 1,
            NeedOpenComment = 1,
            OnlyFansCanComment = 1
        };

        var json = JsonSerializer.Serialize(article, JsonOptions);

        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        Assert.Equal("Article Title", root.GetProperty("title").GetString());
        Assert.Equal("Author Name", root.GetProperty("author").GetString());
        Assert.Equal("Digest text", root.GetProperty("digest").GetString());
        Assert.Equal("<p>Article content</p>", root.GetProperty("content").GetString());
        Assert.Equal("https://source.com", root.GetProperty("content_source_url").GetString());
        Assert.Equal("thumb_001", root.GetProperty("thumb_media_id").GetString());
        Assert.Equal(1, root.GetProperty("show_cover_pic").GetInt32());
        Assert.Equal(1, root.GetProperty("need_open_comment").GetInt32());
        Assert.Equal(1, root.GetProperty("only_fans_can_comment").GetInt32());
    }

    [Fact]
    public void PublishArticleItem_DeserializesCorrectly()
    {
        var json = "{\"idx\":1,\"article_url\":\"https://mp.weixin.qq.com/s/article1\"}";

        var item = JsonSerializer.Deserialize<PublishArticleItem>(json, JsonOptions);

        Assert.NotNull(item);
        Assert.Equal(1, item.Idx);
        Assert.Equal("https://mp.weixin.qq.com/s/article1", item.ArticleUrl);
    }

    [Fact]
    public void DraftItem_DeserializesCorrectly()
    {
        var json = "{\"media_id\":\"draft_media_001\"," +
                   "\"content\":{\"news_item\":[{\"title\":\"文章标题\",\"author\":\"作者名\"," +
                   "\"digest\":\"摘要文字\",\"content\":\"<p>内容</p>\"," +
                   "\"content_source_url\":\"https://source.com\",\"thumb_media_id\":\"thumb_1\"," +
                   "\"show_cover_pic\":1,\"need_open_comment\":0,\"only_fans_can_comment\":0}]}," +
                   "\"update_time\":1700000000}";

        var item = JsonSerializer.Deserialize<DraftItem>(json, JsonOptions);

        Assert.NotNull(item);
        Assert.Equal("draft_media_001", item.MediaId);
        Assert.Equal(1700000000L, item.UpdateTime);
        Assert.NotNull(item.Content);
        Assert.NotNull(item.Content.NewsItem);
        Assert.Single(item.Content.NewsItem);
        Assert.Equal("文章标题", item.Content.NewsItem[0].Title);
        Assert.Equal("作者名", item.Content.NewsItem[0].Author);
        Assert.Equal("<p>内容</p>", item.Content.NewsItem[0].Content);
    }

    [Fact]
    public void OAuthAccessTokenResponse_HandlesNullFields()
    {
        var json = "{\"access_token\":\"token_only\",\"expires_in\":3600}";

        var resp = JsonSerializer.Deserialize<OAuthAccessTokenResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("token_only", resp.AccessToken);
        Assert.Equal(3600, resp.ExpiresIn);
        Assert.Null(resp.RefreshToken);
        Assert.Null(resp.OpenId);
        Assert.Null(resp.Scope);
    }

    [Fact]
    public void MenuButton_SerializesArticleIdCorrectly()
    {
        var button = new MenuButton
        {
            Name = "article",
            Type = "article_id",
            ArticleId = "art_001"
        };

        var json = JsonSerializer.Serialize(button, JsonOptions);

        Assert.Contains("\"name\":\"article\"", json);
        Assert.Contains("\"type\":\"article_id\"", json);
        Assert.Contains("\"article_id\":\"art_001\"", json);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Tag Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void CreateTagRequest_SerializesCorrectly()
    {
        var req = new CreateTagRequest
        {
            Tag = new TagItem { Name = "test_tag_name" }
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        using var doc = JsonDocument.Parse(json);
        var tag = doc.RootElement.GetProperty("tag");

        Assert.Equal(0, tag.GetProperty("id").GetInt32());
        Assert.Equal("test_tag_name", tag.GetProperty("name").GetString());
    }

    [Fact]
    public void CreateTagResponse_DeserializesCorrectly()
    {
        var json = "{\"tag\":{\"id\":100,\"name\":\"新标签\"}}";

        var resp = JsonSerializer.Deserialize<CreateTagResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.NotNull(resp.Tag);
        Assert.Equal(100, resp.Tag.Id);
        Assert.Equal("新标签", resp.Tag.Name);
    }

    [Fact]
    public void GetTagsResponse_DeserializesCorrectly()
    {
        var json = "{\"tags\":[" +
                   "{\"id\":1,\"name\":\"标签1\",\"count\":100}," +
                   "{\"id\":2,\"name\":\"标签2\",\"count\":50}" +
                   "]}";

        var resp = JsonSerializer.Deserialize<GetTagsResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.NotNull(resp.Tags);
        Assert.Equal(2, resp.Tags.Count);
        Assert.Equal(1, resp.Tags[0].Id);
        Assert.Equal("标签1", resp.Tags[0].Name);
        Assert.Equal(100, resp.Tags[0].Count);
        Assert.Equal(2, resp.Tags[1].Id);
        Assert.Equal("标签2", resp.Tags[1].Name);
        Assert.Equal(50, resp.Tags[1].Count);
    }

    [Fact]
    public void TagItem_SerializesCorrectly()
    {
        var tag = new TagItem { Id = 42, Name = "vip_tag", Count = 999 };

        var json = JsonSerializer.Serialize(tag, JsonOptions);

        using var doc = JsonDocument.Parse(json);
        Assert.Equal(42, doc.RootElement.GetProperty("id").GetInt32());
        Assert.Equal("vip_tag", doc.RootElement.GetProperty("name").GetString());
        Assert.Equal(999, doc.RootElement.GetProperty("count").GetInt32());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Custom Message Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void OfficialCustomMessageRequest_SerializesTextMessage()
    {
        var req = new OfficialCustomMessageRequest
        {
            ToUser = "openid123",
            MsgType = "text",
            Text = new CustomMsgText { Content = "Hello from customer service" }
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        using var doc = JsonDocument.Parse(json);
        Assert.Equal("openid123", doc.RootElement.GetProperty("touser").GetString());
        Assert.Equal("text", doc.RootElement.GetProperty("msgtype").GetString());
        Assert.Equal("Hello from customer service", doc.RootElement.GetProperty("text").GetProperty("content").GetString());
    }

    [Fact]
    public void OfficialCustomMessageRequest_SerializesImageMessage()
    {
        var req = new OfficialCustomMessageRequest
        {
            ToUser = "openid456",
            MsgType = "image",
            Image = new CustomMsgMedia { MediaId = "media_img_001" }
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"touser\":\"openid456\"", json);
        Assert.Contains("\"msgtype\":\"image\"", json);
        Assert.Contains("\"image\":{\"media_id\":\"media_img_001\"}", json);
    }

    [Fact]
    public void OfficialCustomMessageRequest_SerializesWithCustomService()
    {
        var req = new OfficialCustomMessageRequest
        {
            ToUser = "openid789",
            MsgType = "text",
            Text = new CustomMsgText { Content = "指定客服发送" },
            CustomService = new CustomServiceAccount { KfAccount = "kf001@test" }
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"touser\":\"openid789\"", json);
        Assert.Contains("\"msgtype\":\"text\"", json);
        Assert.Contains("\"customservice\":{\"kf_account\":\"kf001@test\"}", json);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // User Management (additional)
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void UserListResponse_DeserializesCorrectly()
    {
        var json = "{\"total\":500,\"count\":50,\"data\":{\"openid\":[\"o1\",\"o2\",\"o3\"]}," +
                   "\"next_openid\":\"NEXT_OPENID\"}";

        var resp = JsonSerializer.Deserialize<UserListResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal(500, resp.Total);
        Assert.Equal(50, resp.Count);
        Assert.NotNull(resp.Data);
        Assert.NotNull(resp.Data.OpenId);
        Assert.Equal(3, resp.Data.OpenId.Count);
        Assert.Equal("o1", resp.Data.OpenId[0]);
        Assert.Equal("o3", resp.Data.OpenId[2]);
        Assert.Equal("NEXT_OPENID", resp.NextOpenId);
    }

    [Fact]
    public void UpdateRemarkRequest_SerializesCorrectly()
    {
        var req = new UpdateRemarkRequest
        {
            OpenId = "openid_remark",
            Remark = "remark_note"
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        using var doc = JsonDocument.Parse(json);
        Assert.Equal("openid_remark", doc.RootElement.GetProperty("openid").GetString());
        Assert.Equal("remark_note", doc.RootElement.GetProperty("remark").GetString());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Material (additional)
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void MaterialCountResponse_DeserializesCorrectly()
    {
        var json = "{\"voice_count\":10,\"video_count\":5,\"image_count\":100,\"news_count\":20}";

        var resp = JsonSerializer.Deserialize<MaterialCountResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal(10, resp.VoiceCount);
        Assert.Equal(5, resp.VideoCount);
        Assert.Equal(100, resp.ImageCount);
        Assert.Equal(20, resp.NewsCount);
    }

    [Fact]
    public void UploadMediaResponse_DeserializesCorrectly()
    {
        var json = "{\"type\":\"image\",\"media_id\":\"media_up_001\",\"created_at\":1609459200}";

        var resp = JsonSerializer.Deserialize<UploadMediaResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("image", resp.Type);
        Assert.Equal("media_up_001", resp.MediaId);
        Assert.Equal(1609459200L, resp.CreatedAt);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // OAuth (additional)
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void OAuthRefreshTokenResponse_DeserializesCorrectly()
    {
        var json = "{\"access_token\":\"new_token\",\"expires_in\":7200," +
                   "\"refresh_token\":\"new_refresh\",\"openid\":\"o123\",\"scope\":\"snsapi_userinfo\"}";

        var resp = JsonSerializer.Deserialize<OAuthRefreshTokenResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("new_token", resp.AccessToken);
        Assert.Equal(7200, resp.ExpiresIn);
        Assert.Equal("new_refresh", resp.RefreshToken);
        Assert.Equal("o123", resp.OpenId);
        Assert.Equal("snsapi_userinfo", resp.Scope);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Reply Comment Model
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void ReplyCommentRequest_SerializesCorrectly()
    {
        var req = new ReplyCommentRequest
        {
            MsgDataId = 1234567890,
            Index = 1,
            UserCommentId = 100,
            Content = "official_reply_content"
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        using var doc = JsonDocument.Parse(json);
        Assert.Equal(1234567890L, doc.RootElement.GetProperty("msg_data_id").GetInt64());
        Assert.Equal(1, doc.RootElement.GetProperty("index").GetInt32());
        Assert.Equal(100L, doc.RootElement.GetProperty("user_comment_id").GetInt64());
        Assert.Equal("official_reply_content", doc.RootElement.GetProperty("content").GetString());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Data Analysis Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void OfficialDataAnalysisRequest_SerializesCorrectly()
    {
        var req = new OfficialDataAnalysisRequest
        {
            BeginDate = "2024-01-01",
            EndDate = "2024-01-31"
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"begin_date\":\"2024-01-01\"", json);
        Assert.Contains("\"end_date\":\"2024-01-31\"", json);
    }

    [Fact]
    public void UserCumulateResponse_DeserializesCorrectly()
    {
        var json = "{\"list\":[" +
                   "{\"ref_date\":\"2024-01-01\",\"cumulate_user\":10000}," +
                   "{\"ref_date\":\"2024-01-02\",\"cumulate_user\":10100}" +
                   "]}";

        var resp = JsonSerializer.Deserialize<UserCumulateResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.NotNull(resp.List);
        Assert.Equal(2, resp.List.Count);
        Assert.Equal("2024-01-01", resp.List[0].RefDate);
        Assert.Equal(10000, resp.List[0].CumulateUser);
        Assert.Equal("2024-01-02", resp.List[1].RefDate);
        Assert.Equal(10100, resp.List[1].CumulateUser);
    }

    [Fact]
    public void UserReadResponse_DeserializesCorrectly()
    {
        var json = "{\"list\":[" +
                   "{\"ref_date\":\"2024-01-01\",\"int_page_read_user\":500,\"int_page_read_count\":800," +
                   "\"ori_page_read_user\":300,\"ori_page_read_count\":400," +
                   "\"share_user\":100,\"share_count\":150,\"add_to_fav_user\":50,\"add_to_fav_count\":60}" +
                   "]}";

        var resp = JsonSerializer.Deserialize<UserReadResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.NotNull(resp.List);
        Assert.Single(resp.List);
        Assert.Equal("2024-01-01", resp.List[0].RefDate);
        Assert.Equal(500, resp.List[0].IntPageReadUser);
        Assert.Equal(800, resp.List[0].IntPageReadCount);
        Assert.Equal(300, resp.List[0].OriPageReadUser);
        Assert.Equal(400, resp.List[0].OriPageReadCount);
        Assert.Equal(100, resp.List[0].ShareUser);
        Assert.Equal(150, resp.List[0].ShareCount);
        Assert.Equal(50, resp.List[0].AddToFavUser);
        Assert.Equal(60, resp.List[0].AddToFavCount);
    }

    [Fact]
    public void ArticleTotalResponse_DeserializesCorrectly()
    {
        var json = "{\"list\":[" +
                   "{\"ref_date\":\"2024-01-01\",\"msgid\":\"msg_001\",\"title\":\"图文标题\"," +
                   "\"details\":[{\"stat_date\":\"2024-01-01\",\"target_user\":100,\"int_page_read_user\":80}]}" +
                   "]}";

        var resp = JsonSerializer.Deserialize<ArticleTotalResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.NotNull(resp.List);
        Assert.Single(resp.List);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // AI / OCR Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void SemanticSearchRequest_SerializesCorrectly()
    {
        var req = new SemanticSearchRequest
        {
            Query = "nearby hotels",
            City = "Beijing",
            Category = "hotel",
            Uid = "openid_ai_001"
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        using var doc = JsonDocument.Parse(json);
        Assert.Equal("nearby hotels", doc.RootElement.GetProperty("query").GetString());
        Assert.Equal("Beijing", doc.RootElement.GetProperty("city").GetString());
        Assert.Equal("hotel", doc.RootElement.GetProperty("category").GetString());
        Assert.Equal("openid_ai_001", doc.RootElement.GetProperty("uid").GetString());
    }

    [Fact]
    public void SemanticSearchResponse_DeserializesCorrectly()
    {
        var json = "{\"query\":\"附近的酒店\",\"type\":\"hotel\",\"semantic\":{\"details\":{}}}";

        var resp = JsonSerializer.Deserialize<SemanticSearchResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("附近的酒店", resp.Query);
        Assert.Equal("hotel", resp.Type);
        Assert.NotNull(resp.Semantic);
    }

    [Fact]
    public void OfficialOcrRequest_SerializesCorrectly()
    {
        var req = new OfficialOcrRequest
        {
            ImgUrl = "https://example.com/idcard.jpg"
        };

        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"img_url\":\"https://example.com/idcard.jpg\"", json);
    }

    [Fact]
    public void OfficialOcrIdCardResponse_DeserializesCorrectly()
    {
        var json = "{\"type\":\"Front\",\"name\":\"张三\",\"id\":\"110101199001011234\"," +
                   "\"addr\":\"北京市东城区\",\"gender\":\"男\",\"nationality\":\"汉\"}";

        var resp = JsonSerializer.Deserialize<OfficialOcrIdCardResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("Front", resp.Type);
        Assert.Equal("张三", resp.Name);
        Assert.Equal("110101199001011234", resp.Id);
        Assert.Equal("北京市东城区", resp.Addr);
        Assert.Equal("男", resp.Gender);
        Assert.Equal("汉", resp.Nationality);
    }

    [Fact]
    public void OfficialOcrBankCardResponse_DeserializesCorrectly()
    {
        var json = "{\"number\":\"6222021234567890\"}";

        var resp = JsonSerializer.Deserialize<OfficialOcrBankCardResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("6222021234567890", resp.Number);
    }

    [Fact]
    public void OfficialOcrBizLicenseResponse_DeserializesCorrectly()
    {
        var json = "{\"reg_num\":\"110000000000001\",\"serial\":\"100000000000001\"," +
                   "\"legal_representative\":\"李四\",\"enterprise_name\":\"测试公司\"," +
                   "\"type_of_organization\":\"有限责任公司\",\"address\":\"北京市海淀区\"," +
                   "\"type_of_enterprise\":\"企业法人\",\"business_scope\":\"软件开发\"," +
                   "\"registered_capital\":\"1000000\",\"paid_in_capital\":\"1000000\"," +
                   "\"valid_period\":\"2020-01-01至2050-01-01\",\"registered_date\":\"2020-01-01\"}";

        var resp = JsonSerializer.Deserialize<OfficialOcrBizLicenseResponse>(json, JsonOptions);

        Assert.NotNull(resp);
        Assert.Equal("110000000000001", resp.RegNum);
        Assert.Equal("100000000000001", resp.Serial);
        Assert.Equal("李四", resp.LegalRepresentative);
        Assert.Equal("测试公司", resp.EnterpriseName);
        Assert.Equal("有限责任公司", resp.TypeOfOrganization);
        Assert.Equal("北京市海淀区", resp.Address);
        Assert.Equal("企业法人", resp.TypeOfEnterprise);
        Assert.Equal("软件开发", resp.BusinessScope);
        Assert.Equal("1000000", resp.RegisteredCapital);
        Assert.Equal("1000000", resp.PaidInCapital);
        Assert.Equal("2020-01-01至2050-01-01", resp.ValidPeriod);
        Assert.Equal("2020-01-01", resp.RegisteredDate);
    }
}
