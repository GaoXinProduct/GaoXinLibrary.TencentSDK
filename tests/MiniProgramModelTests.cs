using System.Text.Encodings.Web;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wechat.Models.MiniProgram;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public class MiniProgramModelTests
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    // ═══════════════════════════════════════════════════════════════════════
    // 1. Auth Models — Code2Session
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void Code2SessionResponse_DeserializesCorrectly()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"openid\":\"oTest123\",\"session_key\":\"sk_abc\",\"unionid\":\"u_xyz\"}";
        var resp = JsonSerializer.Deserialize<Code2SessionResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("ok", resp.ErrMsg);
        Assert.Equal("oTest123", resp.OpenId);
        Assert.Equal("sk_abc", resp.SessionKey);
        Assert.Equal("u_xyz", resp.UnionId);
    }

    [Fact]
    public void Code2SessionResponse_SerializesSnakeCaseCorrectly()
    {
        var resp = new Code2SessionResponse
        {
            ErrCode = 0,
            ErrMsg = "ok",
            OpenId = "oTest123",
            SessionKey = "sk_abc",
            UnionId = "u_xyz"
        };
        var json = JsonSerializer.Serialize(resp, JsonOptions);
        Assert.Contains("\"errcode\":0", json);
        Assert.Contains("\"errmsg\":\"ok\"", json);
        Assert.Contains("\"openid\":\"oTest123\"", json);
        Assert.Contains("\"session_key\":\"sk_abc\"", json);
        Assert.Contains("\"unionid\":\"u_xyz\"", json);
    }

    [Fact]
    public void Code2SessionResponse_MissingOptionalFields_DeserializesToNull()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"openid\":\"oTest123\"}";
        var resp = JsonSerializer.Deserialize<Code2SessionResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal("oTest123", resp.OpenId);
        Assert.Null(resp.SessionKey);
        Assert.Null(resp.UnionId);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // 2. QrCode Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void CreateQrCodeRequest_SerializesCorrectly()
    {
        var req = new CreateQrCodeRequest
        {
            Path = "pages/index/index",
            Width = 430
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"path\":\"pages/index/index\"", json);
        Assert.Contains("\"width\":430", json);
    }

    [Fact]
    public void CreateQrCodeRequest_NullableFieldsSerializeAsNull()
    {
        var req = new CreateQrCodeRequest { Path = "pages/index/index" };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"path\":\"pages/index/index\"", json);
        Assert.Contains("\"width\":null", json);
    }

    [Fact]
    public void GetUnlimitedQrCodeRequest_SerializesCorrectly()
    {
        var req = new GetUnlimitedQrCodeRequest
        {
            Scene = "id=1",
            Page = "pages/index/index",
            CheckPath = true,
            EnvVersion = "release",
            Width = 600,
            AutoColor = false,
            LineColor = new QrCodeColor { R = 0, G = 100, B = 200 },
            IsHyaline = true
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"scene\":\"id=1\"", json);
        Assert.Contains("\"page\":\"pages/index/index\"", json);
        Assert.Contains("\"check_path\":true", json);
        Assert.Contains("\"env_version\":\"release\"", json);
        Assert.Contains("\"width\":600", json);
        Assert.Contains("\"auto_color\":false", json);
        Assert.Contains("\"line_color\":{\"r\":0,\"g\":100,\"b\":200}", json);
        Assert.Contains("\"is_hyaline\":true", json);
    }

    [Fact]
    public void GetQrCodeRequest_SerializesCorrectly()
    {
        var req = new GetQrCodeRequest
        {
            Path = "pages/index/index",
            Width = 800,
            AutoColor = true,
            EnvVersion = "develop"
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"path\":\"pages/index/index\"", json);
        Assert.Contains("\"width\":800", json);
        Assert.Contains("\"auto_color\":true", json);
        Assert.Contains("\"env_version\":\"develop\"", json);
    }

    [Fact]
    public void QrCodeColor_SerializesCorrectly()
    {
        var color = new QrCodeColor { R = 10, G = 20, B = 30 };
        var json = JsonSerializer.Serialize(color, JsonOptions);
        Assert.Contains("\"r\":10", json);
        Assert.Contains("\"g\":20", json);
        Assert.Contains("\"b\":30", json);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // 3. SubscribeMessage Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void SendSubscribeMessageRequest_SerializesCorrectly()
    {
        var req = new SendSubscribeMessageRequest
        {
            ToUser = "oTest123",
            TemplateId = "tmpl_abc",
            Page = "pages/index/index",
            Data = new Dictionary<string, SubscribeMessageDataValue>
            {
                ["thing1"] = new SubscribeMessageDataValue { Value = "Hello" },
                ["number2"] = new SubscribeMessageDataValue { Value = "42" }
            },
            MiniProgramState = "formal",
            Lang = "zh_CN"
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"touser\":\"oTest123\"", json);
        Assert.Contains("\"template_id\":\"tmpl_abc\"", json);
        Assert.Contains("\"page\":\"pages/index/index\"", json);
        Assert.Contains("\"data\":{", json);
        Assert.Contains("\"thing1\":{\"value\":\"Hello\"}", json);
        Assert.Contains("\"number2\":{\"value\":\"42\"}", json);
        Assert.Contains("\"miniprogram_state\":\"formal\"", json);
        Assert.Contains("\"lang\":\"zh_CN\"", json);
    }

    [Fact]
    public void SubscribeMessageDataValue_SerializesCorrectly()
    {
        var val = new SubscribeMessageDataValue { Value = "TestValue" };
        var json = JsonSerializer.Serialize(val, JsonOptions);
        Assert.Contains("\"value\":\"TestValue\"", json);
    }

    [Fact]
    public void SendSubscribeMessageResponse_ExtendsWechatBaseResponse()
    {
        var resp = new SendSubscribeMessageResponse { ErrCode = 0, ErrMsg = "ok" };
        var json = JsonSerializer.Serialize(resp, JsonOptions);
        Assert.Contains("\"errcode\":0", json);
        Assert.Contains("\"errmsg\":\"ok\"", json);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // 4. Security Models — MsgSecCheck
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void MsgSecCheckRequest_SerializesCorrectly()
    {
        var req = new MsgSecCheckRequest
        {
            Content = "Hello world",
            Version = 2,
            Scene = 1,
            OpenId = "oTest123",
            Title = "Greeting",
            Nickname = "User1",
            Signature = "MySig"
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"content\":\"Hello world\"", json);
        Assert.Contains("\"version\":2", json);
        Assert.Contains("\"scene\":1", json);
        Assert.Contains("\"openid\":\"oTest123\"", json);
        Assert.Contains("\"title\":\"Greeting\"", json);
        Assert.Contains("\"nickname\":\"User1\"", json);
        Assert.Contains("\"signature\":\"MySig\"", json);
    }

    [Fact]
    public void MsgSecCheckResponse_DeserializesCorrectly()
    {
        var json = """
        {
            "errcode": 0,
            "errmsg": "ok",
            "detail": [
                {
                    "strategy": "content_model",
                    "errcode": 0,
                    "suggest": "pass",
                    "label": 100,
                    "keyword": "normal",
                    "prob": 90
                }
            ],
            "result": {
                "suggest": "pass",
                "label": 100
            },
            "trace_id": "trace_abc_123"
        }
        """;
        var resp = JsonSerializer.Deserialize<MsgSecCheckResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("ok", resp.ErrMsg);
        Assert.NotNull(resp.Detail);
        Assert.Single(resp.Detail);
        Assert.Equal("content_model", resp.Detail[0].Strategy);
        Assert.Equal(0, resp.Detail[0].ErrCode);
        Assert.Equal("pass", resp.Detail[0].Suggest);
        Assert.Equal(100, resp.Detail[0].Label);
        Assert.Equal("normal", resp.Detail[0].Keyword);
        Assert.Equal(90, resp.Detail[0].Prob);
        Assert.NotNull(resp.Result);
        Assert.Equal("pass", resp.Result.Suggest);
        Assert.Equal(100, resp.Result.Label);
        Assert.Equal("trace_abc_123", resp.TraceId);
    }

    [Fact]
    public void MsgSecCheckDetail_SerializesCorrectly()
    {
        var detail = new MsgSecCheckDetail
        {
            Strategy = "content_model",
            ErrCode = 0,
            Suggest = "pass",
            Label = 100,
            Keyword = "normal",
            Prob = 95
        };
        var json = JsonSerializer.Serialize(detail, JsonOptions);
        Assert.Contains("\"strategy\":\"content_model\"", json);
        Assert.Contains("\"errcode\":0", json);
        Assert.Contains("\"suggest\":\"pass\"", json);
        Assert.Contains("\"label\":100", json);
        Assert.Contains("\"keyword\":\"normal\"", json);
        Assert.Contains("\"prob\":95", json);
    }

    [Fact]
    public void MsgSecCheckResult_SerializesCorrectly()
    {
        var result = new MsgSecCheckResult { Suggest = "risky", Label = 20001 };
        var json = JsonSerializer.Serialize(result, JsonOptions);
        Assert.Contains("\"suggest\":\"risky\"", json);
        Assert.Contains("\"label\":20001", json);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // 5. Security Models — MediaCheckAsync & UserRiskRank
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void MediaCheckAsyncRequest_SerializesCorrectly()
    {
        var req = new MediaCheckAsyncRequest
        {
            MediaUrl = "https://example.com/image.jpg",
            MediaType = 2,
            Version = 2,
            Scene = 1,
            OpenId = "oTest123"
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"media_url\":\"https://example.com/image.jpg\"", json);
        Assert.Contains("\"media_type\":2", json);
        Assert.Contains("\"version\":2", json);
        Assert.Contains("\"scene\":1", json);
        Assert.Contains("\"openid\":\"oTest123\"", json);
    }

    [Fact]
    public void MediaCheckAsyncResponse_DeserializesCorrectly()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"trace_id\":\"trace_xyz_456\"}";
        var resp = JsonSerializer.Deserialize<MediaCheckAsyncResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("ok", resp.ErrMsg);
        Assert.Equal("trace_xyz_456", resp.TraceId);
    }

    [Fact]
    public void GetUserRiskRankRequest_SerializesCorrectly()
    {
        var req = new GetUserRiskRankRequest
        {
            AppId = "wxapp123",
            OpenId = "oTest123",
            Scene = 1,
            MobileNo = "13800138000",
            ClientIp = "192.168.1.1",
            EmailAddress = "test@example.com",
            ExtendedInfo = "extra"
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"appid\":\"wxapp123\"", json);
        Assert.Contains("\"openid\":\"oTest123\"", json);
        Assert.Contains("\"scene\":1", json);
        Assert.Contains("\"mobile_no\":\"13800138000\"", json);
        Assert.Contains("\"client_ip\":\"192.168.1.1\"", json);
        Assert.Contains("\"email_address\":\"test@example.com\"", json);
        Assert.Contains("\"extended_info\":\"extra\"", json);
    }

    [Fact]
    public void GetUserRiskRankResponse_DeserializesCorrectly()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"risk_rank\":2,\"unoin_id\":12345}";
        var resp = JsonSerializer.Deserialize<GetUserRiskRankResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("ok", resp.ErrMsg);
        Assert.Equal(2, resp.RiskRank);
        Assert.Equal(12345, resp.UnoinId);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // 6. Link Models — GenerateScheme, GenerateUrlLink, GenerateShortLink
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void GenerateSchemeRequest_SerializesCorrectly()
    {
        var req = new GenerateSchemeRequest
        {
            JumpWxa = new JumpWxa { Path = "pages/index/index", Query = "id=1", EnvVersion = "release" },
            IsExpire = true,
            ExpireTime = 1715000000,
            ExpireInterval = 30,
            ExpireType = 0
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"jump_wxa\":{", json);
        Assert.Contains("\"path\":\"pages/index/index\"", json);
        Assert.Contains("\"query\":\"id=1\"", json);
        Assert.Contains("\"env_version\":\"release\"", json);
        Assert.Contains("\"is_expire\":true", json);
        Assert.Contains("\"expire_time\":1715000000", json);
        Assert.Contains("\"expire_interval\":30", json);
        Assert.Contains("\"expire_type\":0", json);
    }

    [Fact]
    public void GenerateSchemeResponse_DeserializesCorrectly()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"openlink\":\"https://wxaurl.cn/abc123\"}";
        var resp = JsonSerializer.Deserialize<GenerateSchemeResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("ok", resp.ErrMsg);
        Assert.Equal("https://wxaurl.cn/abc123", resp.OpenLink);
    }

    [Fact]
    public void GenerateUrlLinkRequest_SerializesCorrectly()
    {
        var req = new GenerateUrlLinkRequest
        {
            Path = "pages/index/index",
            Query = "id=1&name=test",
            IsExpire = true,
            ExpireTime = 1715000000,
            ExpireInterval = 7,
            ExpireType = 1,
            EnvVersion = "trial"
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"path\":\"pages/index/index\"", json);
        Assert.Contains("\"query\":\"id=1", json);
        Assert.Contains("name=test\"", json);
        Assert.Contains("\"is_expire\":true", json);
        Assert.Contains("\"expire_time\":1715000000", json);
        Assert.Contains("\"expire_interval\":7", json);
        Assert.Contains("\"expire_type\":1", json);
        Assert.Contains("\"env_version\":\"trial\"", json);
    }

    [Fact]
    public void GenerateUrlLinkResponse_DeserializesCorrectly()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"url_link\":\"https://wxaurl.cn/url_link_abc\"}";
        var resp = JsonSerializer.Deserialize<GenerateUrlLinkResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("ok", resp.ErrMsg);
        Assert.Equal("https://wxaurl.cn/url_link_abc", resp.UrlLink);
    }

    [Fact]
    public void JumpWxa_SerializesCorrectly()
    {
        var wxa = new JumpWxa { Path = "pages/detail/detail", Query = "id=42", EnvVersion = "develop" };
        var json = JsonSerializer.Serialize(wxa, JsonOptions);
        Assert.Contains("\"path\":\"pages/detail/detail\"", json);
        Assert.Contains("\"query\":\"id=42\"", json);
        Assert.Contains("\"env_version\":\"develop\"", json);
    }

    [Fact]
    public void GenerateShortLinkRequest_SerializesCorrectly()
    {
        var req = new GenerateShortLinkRequest
        {
            PageUrl = "pages/index/index",
            PageTitle = "测试页面",
            IsPermanent = false
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"page_url\":\"pages/index/index\"", json);
        Assert.Contains("\"page_title\":\"测试页面\"", json);
        Assert.Contains("\"is_permanent\":false", json);
    }

    [Fact]
    public void GenerateShortLinkResponse_DeserializesCorrectly()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"link\":\"https://wxaurl.cn/short_abc\"}";
        var resp = JsonSerializer.Deserialize<GenerateShortLinkResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("ok", resp.ErrMsg);
        Assert.Equal("https://wxaurl.cn/short_abc", resp.Link);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // 7. DataAnalysis Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void DataAnalysisRequest_SerializesCorrectly()
    {
        var req = new DataAnalysisRequest
        {
            BeginDate = "20240101",
            EndDate = "20240107"
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"begin_date\":\"20240101\"", json);
        Assert.Contains("\"end_date\":\"20240107\"", json);
    }

    [Fact]
    public void DailySummaryTrendResponse_DeserializesCorrectly()
    {
        var json = """
        {
            "errcode": 0,
            "errmsg": "ok",
            "list": [
                {
                    "ref_date": "20240101",
                    "visit_total": 15000,
                    "share_pv": 3200,
                    "share_uv": 800
                },
                {
                    "ref_date": "20240102",
                    "visit_total": 18000,
                    "share_pv": 4000,
                    "share_uv": 950
                }
            ]
        }
        """;
        var resp = JsonSerializer.Deserialize<DailySummaryTrendResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.NotNull(resp.List);
        Assert.Equal(2, resp.List.Count);
        Assert.Equal("20240101", resp.List[0].RefDate);
        Assert.Equal(15000, resp.List[0].VisitTotal);
        Assert.Equal(3200, resp.List[0].SharePv);
        Assert.Equal(800, resp.List[0].ShareUv);
        Assert.Equal("20240102", resp.List[1].RefDate);
        Assert.Equal(18000, resp.List[1].VisitTotal);
    }

    [Fact]
    public void DailySummaryTrendItem_SerializesCorrectly()
    {
        var item = new DailySummaryTrendItem
        {
            RefDate = "20240101",
            VisitTotal = 10000,
            SharePv = 2000,
            ShareUv = 500
        };
        var json = JsonSerializer.Serialize(item, JsonOptions);
        Assert.Contains("\"ref_date\":\"20240101\"", json);
        Assert.Contains("\"visit_total\":10000", json);
        Assert.Contains("\"share_pv\":2000", json);
        Assert.Contains("\"share_uv\":500", json);
    }

    [Fact]
    public void DailyVisitTrendResponse_DeserializesCorrectly()
    {
        var json = """
        {
            "errcode": 0,
            "errmsg": "ok",
            "list": [
                {
                    "ref_date": "20240101",
                    "session_cnt": 5000,
                    "visit_pv": 12000,
                    "visit_uv": 3000,
                    "visit_uv_new": 800,
                    "stay_time_uv": 120.5,
                    "stay_time_session": 45.2,
                    "visit_depth": 2.5
                }
            ]
        }
        """;
        var resp = JsonSerializer.Deserialize<DailyVisitTrendResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.NotNull(resp.List);
        Assert.Single(resp.List);
        Assert.Equal("20240101", resp.List[0].RefDate);
        Assert.Equal(5000, resp.List[0].SessionCnt);
        Assert.Equal(12000, resp.List[0].VisitPv);
        Assert.Equal(3000, resp.List[0].VisitUv);
        Assert.Equal(800, resp.List[0].VisitUvNew);
        Assert.Equal(120.5, resp.List[0].StayTimeUv);
        Assert.Equal(45.2, resp.List[0].StayTimeSession);
        Assert.Equal(2.5, resp.List[0].VisitDepth);
    }

    [Fact]
    public void DailyVisitTrendItem_SerializesCorrectly()
    {
        var item = new DailyVisitTrendItem
        {
            RefDate = "20240101",
            SessionCnt = 100,
            VisitPv = 500,
            VisitUv = 200,
            VisitUvNew = 50,
            StayTimeUv = 60.0,
            StayTimeSession = 30.0,
            VisitDepth = 3.0
        };
        var json = JsonSerializer.Serialize(item, JsonOptions);
        Assert.Contains("\"ref_date\":\"20240101\"", json);
        Assert.Contains("\"session_cnt\":100", json);
        Assert.Contains("\"visit_pv\":500", json);
        Assert.Contains("\"visit_uv\":200", json);
        Assert.Contains("\"visit_uv_new\":50", json);
        Assert.Contains("\"stay_time_uv\":60", json);
        Assert.Contains("\"stay_time_session\":30", json);
        Assert.Contains("\"visit_depth\":3", json);
    }

    [Fact]
    public void VisitPageResponse_DeserializesCorrectly()
    {
        var json = """
        {
            "errcode": 0,
            "errmsg": "ok",
            "ref_date": "20240101",
            "list": [
                {
                    "page_path": "pages/index/index",
                    "page_visit_pv": 5000,
                    "page_visit_uv": 2000,
                    "page_staytime_pv": 35.5,
                    "entrypage_pv": 800,
                    "exitpage_pv": 300,
                    "page_share_pv": 150,
                    "page_share_uv": 80
                }
            ]
        }
        """;
        var resp = JsonSerializer.Deserialize<VisitPageResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("20240101", resp.RefDate);
        Assert.NotNull(resp.List);
        Assert.Single(resp.List);
        Assert.Equal("pages/index/index", resp.List[0].PagePath);
        Assert.Equal(5000, resp.List[0].PageVisitPv);
        Assert.Equal(2000, resp.List[0].PageVisitUv);
        Assert.Equal(35.5, resp.List[0].PageStaytimePv);
        Assert.Equal(800, resp.List[0].EntrypagePv);
        Assert.Equal(300, resp.List[0].ExitpagePv);
        Assert.Equal(150, resp.List[0].PageSharePv);
        Assert.Equal(80, resp.List[0].PageShareUv);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // 10. CustomMessage Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void SendCustomMessageRequest_Text_SerializesCorrectly()
    {
        var req = new SendCustomMessageRequest
        {
            ToUser = "oTest123",
            MsgType = "text",
            Text = new CustomTextContent { Content = "你好，欢迎使用！" }
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"touser\":\"oTest123\"", json);
        Assert.Contains("\"msgtype\":\"text\"", json);
        Assert.Contains("\"text\":{\"content\":\"你好，欢迎使用！\"}", json);
    }

    [Fact]
    public void SendCustomMessageRequest_Image_SerializesCorrectly()
    {
        var req = new SendCustomMessageRequest
        {
            ToUser = "oTest123",
            MsgType = "image",
            Image = new CustomImageContent { MediaId = "media_abc123" }
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"touser\":\"oTest123\"", json);
        Assert.Contains("\"msgtype\":\"image\"", json);
        Assert.Contains("\"image\":{\"media_id\":\"media_abc123\"}", json);
    }

    [Fact]
    public void SendCustomMessageRequest_Link_SerializesCorrectly()
    {
        var req = new SendCustomMessageRequest
        {
            ToUser = "oTest123",
            MsgType = "link",
            Link = new CustomLinkContent
            {
                Title = "活动标题",
                Description = "活动详情描述",
                Url = "https://example.com/activity",
                ThumbUrl = "https://example.com/thumb.jpg"
            }
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"touser\":\"oTest123\"", json);
        Assert.Contains("\"msgtype\":\"link\"", json);
        Assert.Contains("\"link\":{", json);
        Assert.Contains("\"title\":\"活动标题\"", json);
        Assert.Contains("\"description\":\"活动详情描述\"", json);
        Assert.Contains("\"url\":\"https://example.com/activity\"", json);
        Assert.Contains("\"thumb_url\":\"https://example.com/thumb.jpg\"", json);
    }

    [Fact]
    public void SendCustomMessageRequest_MiniProgramPage_SerializesCorrectly()
    {
        var req = new SendCustomMessageRequest
        {
            ToUser = "oTest123",
            MsgType = "miniprogrampage",
            MiniProgramPage = new CustomMiniProgramContent
            {
                Title = "小程序卡片",
                PagePath = "pages/detail/detail?id=1",
                ThumbMediaId = "thumb_media_xyz"
            }
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"touser\":\"oTest123\"", json);
        Assert.Contains("\"msgtype\":\"miniprogrampage\"", json);
        Assert.Contains("\"miniprogrampage\":{", json);
        Assert.Contains("\"title\":\"小程序卡片\"", json);
        Assert.Contains("\"pagepath\":\"pages/detail/detail?id=1\"", json);
        Assert.Contains("\"thumb_media_id\":\"thumb_media_xyz\"", json);
    }

    [Fact]
    public void SendCustomMessageResponse_ExtendsWechatBaseResponse()
    {
        var resp = new SendCustomMessageResponse { ErrCode = 0, ErrMsg = "ok" };
        var json = JsonSerializer.Serialize(resp, JsonOptions);
        Assert.Contains("\"errcode\":0", json);
        Assert.Contains("\"errmsg\":\"ok\"", json);
    }

    [Fact]
    public void CustomTextContent_SerializesCorrectly()
    {
        var content = new CustomTextContent { Content = "测试文本消息" };
        var json = JsonSerializer.Serialize(content, JsonOptions);
        Assert.Contains("\"content\":\"测试文本消息\"", json);
    }

    [Fact]
    public void CustomImageContent_SerializesCorrectly()
    {
        var content = new CustomImageContent { MediaId = "media_img_001" };
        var json = JsonSerializer.Serialize(content, JsonOptions);
        Assert.Contains("\"media_id\":\"media_img_001\"", json);
    }

    [Fact]
    public void CustomLinkContent_SerializesCorrectly()
    {
        var content = new CustomLinkContent
        {
            Title = "链接标题",
            Description = "链接描述",
            Url = "https://example.com",
            ThumbUrl = "https://example.com/thumb.png"
        };
        var json = JsonSerializer.Serialize(content, JsonOptions);
        Assert.Contains("\"title\":\"链接标题\"", json);
        Assert.Contains("\"description\":\"链接描述\"", json);
        Assert.Contains("\"url\":\"https://example.com\"", json);
        Assert.Contains("\"thumb_url\":\"https://example.com/thumb.png\"", json);
    }

    [Fact]
    public void CustomMiniProgramContent_SerializesCorrectly()
    {
        var content = new CustomMiniProgramContent
        {
            Title = "小程序卡片标题",
            PagePath = "pages/home/home",
            ThumbMediaId = "media_thumb_002"
        };
        var json = JsonSerializer.Serialize(content, JsonOptions);
        Assert.Contains("\"title\":\"小程序卡片标题\"", json);
        Assert.Contains("\"pagepath\":\"pages/home/home\"", json);
        Assert.Contains("\"thumb_media_id\":\"media_thumb_002\"", json);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // 11. Shipping Models
    // ═══════════════════════════════════════════════════════════════════════

    [Fact]
    public void UploadShippingInfoRequest_SerializesCorrectly()
    {
        var req = new UploadShippingInfoRequest
        {
            OrderKey = new ShippingOrderKey
            {
                OrderNumberType = 1,
                TransactionId = "txn_abc123",
                MchId = "mch_xyz"
            },
            DeliveryMode = 1,
            ShippingList = new List<ShippingItem>
            {
                new ShippingItem
                {
                    TrackingNo = "SF123456789",
                    ExpressCompany = "SF",
                    ItemDesc = "书籍",
                    Contact = new ShippingContact
                    {
                        ConsignorContact = "189****1234",
                        ReceiverContact = "138****5678"
                    }
                }
            },
            UploadTime = "1715000000",
            IsAllDelivered = true
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"order_key\":{", json);
        Assert.Contains("\"order_number_type\":1", json);
        Assert.Contains("\"transaction_id\":\"txn_abc123\"", json);
        Assert.Contains("\"mchid\":\"mch_xyz\"", json);
        Assert.Contains("\"delivery_mode\":1", json);
        Assert.Contains("\"shipping_list\":[", json);
        Assert.Contains("\"tracking_no\":\"SF123456789\"", json);
        Assert.Contains("\"express_company\":\"SF\"", json);
        Assert.Contains("\"item_desc\":\"书籍\"", json);
        Assert.Contains("\"consignor_contact\":\"189****1234\"", json);
        Assert.Contains("\"receiver_contact\":\"138****5678\"", json);
        Assert.Contains("\"upload_time\":\"1715000000\"", json);
        Assert.Contains("\"is_all_delivered\":true", json);
    }

    [Fact]
    public void ShippingOrderKey_SerializesCorrectly()
    {
        var key = new ShippingOrderKey
        {
            OrderNumberType = 2,
            OutTradeNo = "out_trade_abc"
        };
        var json = JsonSerializer.Serialize(key, JsonOptions);
        Assert.Contains("\"order_number_type\":2", json);
        Assert.Contains("\"out_trade_no\":\"out_trade_abc\"", json);
    }

    [Fact]
    public void ShippingContact_SerializesCorrectly()
    {
        var contact = new ShippingContact
        {
            ConsignorContact = "189****1234",
            ReceiverContact = "138****5678"
        };
        var json = JsonSerializer.Serialize(contact, JsonOptions);
        Assert.Contains("\"consignor_contact\":\"189****1234\"", json);
        Assert.Contains("\"receiver_contact\":\"138****5678\"", json);
    }
}
