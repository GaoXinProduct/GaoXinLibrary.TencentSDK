using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Agent;
using GaoXinLibrary.TencentSDK.Wecom.Models.Approval;
using GaoXinLibrary.TencentSDK.Wecom.Models.Checkin;
using GaoXinLibrary.TencentSDK.Wecom.Models.Department;
using GaoXinLibrary.TencentSDK.Wecom.Models.Kf;
using GaoXinLibrary.TencentSDK.Wecom.Models.Media;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;
using GaoXinLibrary.TencentSDK.Wecom.Models.OAuth;
using GaoXinLibrary.TencentSDK.Wecom.Models.Tag;
using GaoXinLibrary.TencentSDK.Wecom.Models.User;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public class WecomModelTests
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    [Fact]
    public void CreateUserRequest_SerializesCorrectly()
    {
        var req = new CreateUserRequest
        {
            UserId = "zhangsan",
            Name = "ZhangSan",
            Alias = "zs",
            Mobile = "13800138000",
            Department = [1, 2],
            Position = "Engineer",
            Gender = "1",
            Email = "zhangsan@example.com",
            BizMail = "zhangsan@company.com",
            Telephone = "010-12345678",
            Address = "Beijing",
            Enable = 1
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"userid\":\"zhangsan\"", json);
        Assert.Contains("\"name\":\"ZhangSan\"", json);
        Assert.Contains("\"alias\":\"zs\"", json);
        Assert.Contains("\"mobile\":\"13800138000\"", json);
        Assert.Contains("\"department\":[1,2]", json);
        Assert.Contains("\"position\":\"Engineer\"", json);
        Assert.Contains("\"gender\":\"1\"", json);
        Assert.Contains("\"email\":\"zhangsan@example.com\"", json);
        Assert.Contains("\"biz_mail\":\"zhangsan@company.com\"", json);
        Assert.Contains("\"telephone\":\"010-12345678\"", json);
        Assert.Contains("\"enable\":1", json);
    }

    [Fact]
    public void CreateUserRequest_DefaultsEnableToOne()
    {
        var req = new CreateUserRequest { UserId = "test", Name = "Test" };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"enable\":1", json);
    }

    [Fact]
    public void GetUserDirectResponse_DeserializesCorrectly()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"userid\":\"zhangsan\",\"name\":\"ZhangSan\",\"department\":[1,2],\"position\":\"Engineer\",\"status\":1,\"enable\":1,\"english_name\":\"zhang\",\"main_department\":1,\"direct_leader\":[\"lisi\"],\"hide_mobile\":0,\"open_userid\":\"openid123\"}";

        var resp = JsonSerializer.Deserialize<GetUserDirectResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("zhangsan", resp.UserId);
        Assert.Equal("ZhangSan", resp.Name);
        Assert.NotNull(resp.Department);
        Assert.Equal([1, 2], resp.Department);
        Assert.Equal("Engineer", resp.Position);
        Assert.Equal(1, resp.Status);
        Assert.Equal(1, resp.Enable);
        Assert.Equal("zhang", resp.EnglishName);
        Assert.Equal(1, resp.MainDepartment);
        Assert.NotNull(resp.DirectLeader);
        Assert.Equal(["lisi"], resp.DirectLeader);
        Assert.Equal(0, resp.HideMobile);
        Assert.Equal("openid123", resp.OpenUserId);
    }

    [Fact]
    public void GetUserDirectResponse_DeserializesWithMinimalFields()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"userid\":\"minimal\",\"name\":\"Min\"}";

        var resp = JsonSerializer.Deserialize<GetUserDirectResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal("minimal", resp.UserId);
        Assert.Equal("Min", resp.Name);
        Assert.Null(resp.Alias);
        Assert.Null(resp.Mobile);
        Assert.Null(resp.Email);
        Assert.Null(resp.Position);
        Assert.Null(resp.Department);
    }

    [Fact]
    public void CreateDepartmentRequest_SerializesCorrectly()
    {
        var req = new CreateDepartmentRequest
        {
            Name = "R&D",
            NameEn = "RnD",
            ParentId = 1,
            Order = 100,
            Id = 200
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"name\":\"R\\u0026D\"", json);
        Assert.Contains("\"name_en\":\"RnD\"", json);
        Assert.Contains("\"parentid\":1", json);
        Assert.Contains("\"order\":100", json);
        Assert.Contains("\"id\":200", json);
    }

    [Fact]
    public void CreateDepartmentRequest_NullOptionals_SerializedAsNull()
    {
        var req = new CreateDepartmentRequest { Name = "Test", ParentId = 0 };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"name\":\"Test\"", json);
        Assert.Contains("\"parentid\":0", json);
        Assert.Contains("\"name_en\":null", json);
        Assert.Contains("\"order\":null", json);
        Assert.Contains("\"id\":null", json);
    }

    [Fact]
    public void DepartmentInfo_DeserializesCorrectly()
    {
        var json = "{\"id\":1,\"name\":\"R\\u0026D\",\"name_en\":\"RnD\",\"parentid\":0,\"order\":100,\"department_leader\":[\"zhangsan\",\"lisi\"]}";

        var info = JsonSerializer.Deserialize<DepartmentInfo>(json, JsonOptions);
        Assert.NotNull(info);
        Assert.Equal(1, info.Id);
        Assert.Equal("R&D", info.Name);
        Assert.Equal("RnD", info.NameEn);
        Assert.Equal(0, info.ParentId);
        Assert.Equal(100, info.Order);
        Assert.NotNull(info.DepartmentLeader);
        Assert.Equal(["zhangsan", "lisi"], info.DepartmentLeader);
    }

    [Fact]
    public void CreateTagRequest_SerializesCorrectly()
    {
        var req = new CreateTagRequest { TagName = "VIP", TagId = 100 };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"tagname\":\"VIP\"", json);
        Assert.Contains("\"tagid\":100", json);
    }

    [Fact]
    public void CreateTagRequest_WithNullTagId_SerializesNull()
    {
        var req = new CreateTagRequest { TagName = "NewTag" };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"tagname\":\"NewTag\"", json);
        Assert.Contains("\"tagid\":null", json);
    }

    [Fact]
    public void SendMessageRequest_TextMessage_SerializesCorrectly()
    {
        var req = new SendMessageRequest
        {
            ToUser = "@all",
            MsgType = "text",
            AgentId = 1000001,
            Text = new TextContent { Content = "Hello World" },
            Safe = 1
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"touser\":\"@all\"", json);
        Assert.Contains("\"msgtype\":\"text\"", json);
        Assert.Contains("\"agentid\":1000001", json);
        Assert.Contains("\"text\":{\"content\":\"Hello World\"}", json);
        Assert.Contains("\"safe\":1", json);
    }

    [Fact]
    public void SendMessageRequest_WithAllReceivers_SerializesCorrectly()
    {
        var req = new SendMessageRequest
        {
            ToUser = "user1|user2",
            ToParty = "1|2",
            ToTag = "3",
            MsgType = "text",
            AgentId = 1000001,
            Text = new TextContent { Content = "broadcast" }
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"toparty\":\"1|2\"", json);
        Assert.Contains("\"totag\":\"3\"", json);
        Assert.Contains("\"touser\":\"user1|user2\"", json);
    }

    [Fact]
    public void SendMessageRequest_WithDuplicateCheck_SerializesCorrectly()
    {
        var req = new SendMessageRequest
        {
            ToUser = "user1",
            MsgType = "text",
            AgentId = 1000001,
            Text = new TextContent { Content = "test" },
            EnableDuplicateCheck = 1,
            DuplicateCheckInterval = 1800
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"enable_duplicate_check\":1", json);
        Assert.Contains("\"duplicate_check_interval\":1800", json);
    }

    [Fact]
    public void SendMessageRequest_TextCard_SerializesCorrectly()
    {
        var req = new SendMessageRequest
        {
            ToUser = "user1",
            MsgType = "textcard",
            AgentId = 1000001,
            TextCard = new TextCardContent
            {
                Title = "Notice",
                Description = "Content",
                Url = "https://example.com",
                BtnTxt = "Details"
            }
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"msgtype\":\"textcard\"", json);
        Assert.Contains("\"textcard\"", json);
        Assert.Contains("\"title\":\"Notice\"", json);
        Assert.Contains("\"url\":\"https://example.com\"", json);
        Assert.Contains("\"btntxt\":\"Details\"", json);
    }

    [Fact]
    public void SetAgentRequest_SerializesCorrectly()
    {
        var req = new SetAgentRequest
        {
            AgentId = 1000001,
            ReportLocationFlag = 1,
            LogoMediaId = "media123",
            Name = "MyApp",
            Description = "AppDesc",
            RedirectDomain = "example.com",
            IsReportEnter = 1,
            HomeUrl = "https://example.com/home"
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"agentid\":1000001", json);
        Assert.Contains("\"report_location_flag\":1", json);
        Assert.Contains("\"logo_mediaid\":\"media123\"", json);
        Assert.Contains("\"name\":\"MyApp\"", json);
        Assert.Contains("\"description\":\"AppDesc\"", json);
        Assert.Contains("\"redirect_domain\":\"example.com\"", json);
        Assert.Contains("\"isreportenter\":1", json);
        Assert.Contains("\"home_url\":\"https://example.com/home\"", json);
    }

    [Fact]
    public void SetAgentRequest_MinimalFields_SerializesCorrectly()
    {
        var req = new SetAgentRequest { AgentId = 1000001 };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"agentid\":1000001", json);
        Assert.Contains("\"report_location_flag\":null", json);
        Assert.Contains("\"isreportenter\":null", json);
        Assert.Contains("\"logo_mediaid\":null", json);
    }

    [Fact]
    public void KfAccountAddRequest_SerializesCorrectly()
    {
        var req = new KfAccountAddRequest { Name = "AgentXiao", MediaId = "media_avatar_001" };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"name\":\"AgentXiao\"", json);
        Assert.Contains("\"media_id\":\"media_avatar_001\"", json);
    }

    [Fact]
    public void KfAccountAddRequest_NullMediaId_SerializesAsNull()
    {
        var req = new KfAccountAddRequest { Name = "AgentLi" };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"name\":\"AgentLi\"", json);
        Assert.Contains("\"media_id\":null", json);
    }

    [Fact]
    public void GetCheckinDataRequest_SerializesCorrectly()
    {
        var req = new GetCheckinDataRequest
        {
            OpenCheckinDataType = 3,
            StartTime = 1715673600,
            EndTime = 1715759999,
            UserIdList = ["zhangsan", "lisi", "wangwu"]
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"opencheckindatatype\":3", json);
        Assert.Contains("\"starttime\":1715673600", json);
        Assert.Contains("\"endtime\":1715759999", json);
        Assert.Contains("\"useridlist\":[\"zhangsan\",\"lisi\",\"wangwu\"]", json);
    }

    [Fact]
    public void ApplyEventRequest_SerializesCorrectly()
    {
        var req = new ApplyEventRequest
        {
            CreatorUserId = "zhangsan",
            TemplateId = "template001",
            UseTemplateApprover = 1,
            ChooseDepartment = 2,
            NotifyType = 1,
            ApplyData = new ApplyData()
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"creator_userid\":\"zhangsan\"", json);
        Assert.Contains("\"template_id\":\"template001\"", json);
        Assert.Contains("\"use_template_approver\":1", json);
        Assert.Contains("\"choose_department\":2", json);
        Assert.Contains("\"notify_type\":1", json);
        Assert.Contains("\"apply_data\"", json);
    }

    [Fact]
    public void ApplyEventRequest_WithApproverAndNotifyer_SerializesCorrectly()
    {
        var req = new ApplyEventRequest
        {
            CreatorUserId = "zhangsan",
            TemplateId = "template001",
            UseTemplateApprover = 0,
            Approver = [new ApprovalApprover { Attr = 1, UserId = ["user1", "user2"] }],
            Notifyer = ["notify1", "notify2"],
            NotifyType = 2,
            ApplyData = new ApplyData()
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"approver\":[{\"attr\":1,\"userid\":[\"user1\",\"user2\"]}]", json);
        Assert.Contains("\"notifyer\":[\"notify1\",\"notify2\"]", json);
        Assert.Contains("\"notify_type\":2", json);
    }

    [Fact]
    public void ApplyEventRequest_WithSummaryList_SerializesCorrectly()
    {
        var req = new ApplyEventRequest
        {
            CreatorUserId = "zhangsan",
            TemplateId = "template001",
            UseTemplateApprover = 1,
            ApplyData = new ApplyData(),
            SummaryList = [new ApprovalSummary { SummaryInfo = [new ApprovalText { Text = "Line1" }] }]
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"summary_list\"", json);
        Assert.Contains("\"summary_info\"", json);
        Assert.Contains("\"text\":\"Line1\"", json);
    }

    [Fact]
    public void UploadByUrlRequest_SerializesCorrectly()
    {
        var req = new UploadByUrlRequest
        {
            Scene = 1,
            Type = "image",
            Filename = "photo.jpg",
            Url = "https://cdn.example.com/photo.jpg",
            Md5 = "d41d8cd98f00b204e9800998ecf8427e"
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);

        Assert.Contains("\"scene\":1", json);
        Assert.Contains("\"type\":\"image\"", json);
        Assert.Contains("\"filename\":\"photo.jpg\"", json);
        Assert.Contains("\"url\":\"https://cdn.example.com/photo.jpg\"", json);
        Assert.Contains("\"md5\":\"d41d8cd98f00b204e9800998ecf8427e\"", json);
    }

    [Fact]
    public void OAuthUserInfoResponse_DeserializesCorrectly()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"userid\":\"zhangsan\",\"user_ticket\":\"ticket_abc\",\"openid\":\"openid_ext\",\"external_userid\":\"ext123\",\"open_userid\":\"open_userid_456\",\"deviceid\":\"device_789\"}";

        var resp = JsonSerializer.Deserialize<OAuthUserInfoResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("zhangsan", resp.UserId);
        Assert.Equal("ticket_abc", resp.UserTicket);
        Assert.Equal("openid_ext", resp.OpenId);
        Assert.Equal("ext123", resp.ExternalUserId);
        Assert.Equal("open_userid_456", resp.OpenUserId);
        Assert.Equal("device_789", resp.DeviceId);
    }

    [Fact]
    public void OAuthUserInfoResponse_DeserializesWithOnlyUserId()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"userid\":\"user_min\"}";

        var resp = JsonSerializer.Deserialize<OAuthUserInfoResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("user_min", resp.UserId);
        Assert.Null(resp.UserTicket);
        Assert.Null(resp.OpenId);
        Assert.Null(resp.ExternalUserId);
        Assert.Null(resp.OpenUserId);
        Assert.Null(resp.DeviceId);
    }

    [Fact]
    public void GetUserDirectResponse_InheritsWecomBaseResponse()
    {
        var resp = new GetUserDirectResponse { ErrCode = 0, ErrMsg = "ok" };
        Assert.IsAssignableFrom<WecomBaseResponse>(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.Equal("ok", resp.ErrMsg);
    }

    [Fact]
    public void OAuthUserInfoResponse_InheritsWecomBaseResponse()
    {
        var resp = new OAuthUserInfoResponse { ErrCode = 42, ErrMsg = "error" };
        Assert.IsAssignableFrom<WecomBaseResponse>(resp);
        Assert.Equal(42, resp.ErrCode);
        Assert.Equal("error", resp.ErrMsg);
    }

    [Fact]
    public void CreateUserRequest_RoundTrip_ConsistentValues()
    {
        var original = new CreateUserRequest
        {
            UserId = "user001",
            Name = "Test User",
            Alias = "tu",
            Department = [3, 5, 7],
            Position = "Tester",
            Enable = 0
        };
        var json = JsonSerializer.Serialize(original, JsonOptions);
        var deserialized = JsonSerializer.Deserialize<CreateUserRequest>(json, JsonOptions);

        Assert.NotNull(deserialized);
        Assert.Equal(original.UserId, deserialized.UserId);
        Assert.Equal(original.Name, deserialized.Name);
        Assert.Equal(original.Alias, deserialized.Alias);
        Assert.Equal(original.Department, deserialized.Department);
        Assert.Equal(original.Position, deserialized.Position);
        Assert.Equal(original.Enable, deserialized.Enable);
    }

    [Fact]
    public void SendMessageRequest_RoundTrip_ConsistentValues()
    {
        var original = new SendMessageRequest
        {
            ToUser = "user1",
            MsgType = "text",
            AgentId = 1000001,
            Text = new TextContent { Content = "roundtrip" },
            Safe = 0,
            EnableIdTrans = 1,
            EnableDuplicateCheck = 1,
            DuplicateCheckInterval = 600
        };
        var json = JsonSerializer.Serialize(original, JsonOptions);
        var deserialized = JsonSerializer.Deserialize<SendMessageRequest>(json, JsonOptions);

        Assert.NotNull(deserialized);
        Assert.Equal(original.ToUser, deserialized.ToUser);
        Assert.Equal(original.MsgType, deserialized.MsgType);
        Assert.Equal(original.AgentId, deserialized.AgentId);
        Assert.NotNull(deserialized.Text);
        Assert.Equal(original.Text.Content, deserialized.Text.Content);
        Assert.Equal(original.Safe, deserialized.Safe);
        Assert.Equal(original.EnableIdTrans, deserialized.EnableIdTrans);
        Assert.Equal(original.EnableDuplicateCheck, deserialized.EnableDuplicateCheck);
        Assert.Equal(original.DuplicateCheckInterval, deserialized.DuplicateCheckInterval);
    }
}
