using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public class ExternalContactModelTests
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    [Fact]
    public void TransferCustomerRequest_SerializesCorrectly()
    {
        var req = new TransferCustomerRequest
        {
            HandoverUserId = "user1",
            TakeoverUserId = "user2",
            ExternalUserId = ["ext1", "ext2"],
            TransferSuccessMsg = "hello"
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"handover_userid\":\"user1\"", json);
        Assert.Contains("\"takeover_userid\":\"user2\"", json);
        Assert.Contains("\"external_userid\"", json);
        Assert.Contains("\"ext1\"", json);
    }

    [Fact]
    public void TransferCustomerResponse_DeserializesCorrectly()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"customer\":[{\"external_userid\":\"ext1\",\"errcode\":0}]}";
        var resp = JsonSerializer.Deserialize<TransferCustomerResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.NotNull(resp.Customer);
        Assert.Single(resp.Customer);
        Assert.Equal("ext1", resp.Customer[0].ExternalUserId);
    }

    [Fact]
    public void TransferGroupChatRequest_SerializesCorrectly()
    {
        var req = new TransferGroupChatRequest
        {
            ChatIdList = ["chat1", "chat2"],
            NewOwner = "newowner"
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"chat_id_list\"", json);
        Assert.Contains("\"new_owner\":\"newowner\"", json);
    }

    [Fact]
    public void GetCorpTagListResponse_DeserializesCorrectly()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"tag_group\":[{\"group_id\":\"g1\",\"group_name\":\"Test\",\"create_time\":1000,\"order\":1,\"deleted\":false,\"tag\":[{\"id\":\"t1\",\"name\":\"tag1\",\"create_time\":1000,\"order\":1,\"deleted\":false}]}]}";
        var resp = JsonSerializer.Deserialize<GetCorpTagListResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.NotNull(resp.TagGroup);
        Assert.Single(resp.TagGroup);
        Assert.Equal("g1", resp.TagGroup[0].GroupId);
    }

    [Fact]
    public void AddContactWayRequest_SerializesCorrectly()
    {
        var req = new AddContactWayRequest
        {
            Type = 1,
            Scene = 2,
            Style = 3,
            Remark = "test",
            User = ["user1"],
            Party = [1, 2]
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"type\":1", json);
        Assert.Contains("\"scene\":2", json);
        Assert.Contains("\"remark\":\"test\"", json);
        Assert.Contains("\"user\"", json);
    }

    [Fact]
    public void GetUnassignedListResponse_DeserializesCorrectly()
    {
        var json = "{\"errcode\":0,\"errmsg\":\"ok\",\"info\":[{\"handover_userid\":\"h1\",\"external_userid\":\"e1\",\"dimission_time\":1000}],\"is_last\":true,\"next_cursor\":\"cursor1\"}";
        var resp = JsonSerializer.Deserialize<GetUnassignedListResponse>(json, JsonOptions);
        Assert.NotNull(resp);
        Assert.Equal(0, resp.ErrCode);
        Assert.NotNull(resp.Info);
        Assert.True(resp.IsLast);
        Assert.Equal("cursor1", resp.NextCursor);
    }

    [Fact]
    public void AddMsgTemplateRequest_SerializesCorrectly()
    {
        var req = new AddMsgTemplateRequest
        {
            ChatType = "single",
            ExternalUserId = ["ext1"],
            Sender = "user1",
            Text = new GroupMsgText { Content = "hello" }
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"chat_type\":\"single\"", json);
        Assert.Contains("\"sender\":\"user1\"", json);
        Assert.Contains("\"text\":{\"content\":\"hello\"}", json);
    }

    [Fact]
    public void AllResponseTypesExtendWecomBaseResponse()
    {
        // Verify key response types extend WecomBaseResponse
        var resp = new TransferCustomerResponse { ErrCode = 0 };
        Assert.IsAssignableFrom<WecomBaseResponse>(resp);
        Assert.Equal(0, resp.ErrCode);

        var resp2 = new GetCorpTagListResponse();
        Assert.IsAssignableFrom<WecomBaseResponse>(resp2);

        var resp3 = new AddContactWayResponse { ConfigId = "test" };
        Assert.IsAssignableFrom<WecomBaseResponse>(resp3);
    }

    [Fact]
    public void MarkTagRequest_SerializesCorrectly()
    {
        var req = new MarkTagRequest
        {
            UserId = "user1",
            ExternalUserId = "ext1",
            AddTag = ["tag1", "tag2"],
            RemoveTag = ["tag3"]
        };
        var json = JsonSerializer.Serialize(req, JsonOptions);
        Assert.Contains("\"userid\":\"user1\"", json);
        Assert.Contains("\"add_tag\"", json);
        Assert.Contains("\"remove_tag\"", json);
    }
}
