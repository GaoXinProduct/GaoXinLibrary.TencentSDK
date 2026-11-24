using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Callback;
using GaoXinLibrary.TencentSDK.Wecom.Models.Callback.ExternalContact;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class WecomCallbackTests
{
    // 客户联系回调字段见 https://developer.work.weixin.qq.com/document/path/92130
    [Theory]
    [InlineData("add_external_contact")]
    [InlineData("add_half_external_contact")]
    public void FromXml_ParsesExternalContactAddition(string changeType)
    {
        var evt = Assert.IsType<AddExternalContactEvent>(ParseCustomerEvent("change_external_contact", $"""
            <ChangeType><![CDATA[{changeType}]]></ChangeType>
            <UserID><![CDATA[zhangsan]]></UserID>
            <ExternalUserID><![CDATA[woAJ2GCAAAXtWyujaWJHDDGi0mAAAA]]></ExternalUserID>
            <State><![CDATA[teststate]]></State>
            <WelcomeCode><![CDATA[WELCOMECODE]]></WelcomeCode>
            """));

        Assert.Equal("change_external_contact", evt.Event);
        Assert.Equal("sys", evt.FromUserName);
        Assert.Equal(changeType, evt.ChangeType);
        Assert.Equal("zhangsan", evt.UserId);
        Assert.Equal("woAJ2GCAAAXtWyujaWJHDDGi0mAAAA", evt.ExternalUserId);
        Assert.Equal("teststate", evt.State);
        Assert.Equal("WELCOMECODE", evt.WelcomeCode);
    }

    [Fact]
    public void FromXml_ParsesExternalContactDeletionAndSource()
    {
        var evt = Assert.IsType<DelExternalContactEvent>(ParseCustomerEvent("change_external_contact", """
            <ChangeType><![CDATA[del_external_contact]]></ChangeType>
            <UserID><![CDATA[zhangsan]]></UserID>
            <ExternalUserID><![CDATA[woAJ2GCAAAXtWyujaWJHDDGi0mAAAA]]></ExternalUserID>
            <Source><![CDATA[DELETE_BY_TRANSFER]]></Source>
            """));

        Assert.Equal("del_external_contact", evt.ChangeType);
        Assert.Equal("zhangsan", evt.UserId);
        Assert.Equal("woAJ2GCAAAXtWyujaWJHDDGi0mAAAA", evt.ExternalUserId);
        Assert.Equal("DELETE_BY_TRANSFER", evt.Source);
    }

    [Theory]
    [InlineData("edit_external_contact", null)]
    [InlineData("del_follow_user", null)]
    [InlineData("transfer_fail", "customer_refused")]
    public void FromXml_PreservesExternalContactChangeDetails(string changeType, string? failReason)
    {
        var failure = failReason is null ? string.Empty : $"<FailReason>{failReason}</FailReason>";
        var evt = Assert.IsType<ExternalContactChangeEvent>(ParseCustomerEvent("change_external_contact", $"""
            <ChangeType>{changeType}</ChangeType>
            <UserID>zhangsan</UserID>
            <ExternalUserID>external-customer</ExternalUserID>
            {failure}
            """));

        Assert.Equal(changeType, evt.ChangeType);
        Assert.Equal("zhangsan", evt.UserId);
        Assert.Equal("external-customer", evt.ExternalUserId);
        Assert.Equal(failReason, evt.FailReason);
    }

    [Theory]
    [InlineData("create")]
    [InlineData("dismiss")]
    public void FromXml_ParsesExternalChatLifecycleEventWithoutUpdateFields(string changeType)
    {
        var evt = Assert.IsType<ExternalChatChangeEvent>(ParseCustomerEvent("change_external_chat", $"""
            <ChatId><![CDATA[CHAT_ID]]></ChatId>
            <ChangeType><![CDATA[{changeType}]]></ChangeType>
            """));

        Assert.Equal(changeType, evt.ChangeType);
        Assert.Equal("CHAT_ID", evt.ChatId);
        Assert.Null(evt.JoinScene);
        Assert.Null(evt.QuitScene);
        Assert.Null(evt.MemberChangeCount);
        Assert.Null(evt.MemberChangeList);
    }

    [Fact]
    public void FromXml_ParsesExternalChatMemberChangesAndVersions()
    {
        var evt = Assert.IsType<ExternalChatChangeEvent>(ParseCustomerEvent("change_external_chat", """
            <ChatId><![CDATA[CHAT_ID]]></ChatId>
            <ChangeType><![CDATA[update]]></ChangeType>
            <UpdateDetail><![CDATA[add_member]]></UpdateDetail>
            <JoinScene>1</JoinScene>
            <QuitScene>0</QuitScene>
            <MemChangeCnt>10</MemChangeCnt>
            <MemChangeList><Item>Jack</Item><Item>Rose</Item></MemChangeList>
            <LastMemVer>9c3f97c2ada667dfb5f6d03308d963e1</LastMemVer>
            <CurMemVer>71217227bbd112ecfe3a49c482195cb4</CurMemVer>
            """));

        Assert.Equal("update", evt.ChangeType);
        Assert.Equal("add_member", evt.UpdateDetail);
        Assert.Equal(1, evt.JoinScene);
        Assert.Equal(0, evt.QuitScene);
        Assert.Equal(10, evt.MemberChangeCount);
        Assert.Equal(new[] { "Jack", "Rose" }, evt.MemberChangeList);
        Assert.Equal("9c3f97c2ada667dfb5f6d03308d963e1", evt.LastMemberVersion);
        Assert.Equal("71217227bbd112ecfe3a49c482195cb4", evt.CurrentMemberVersion);
    }

    [Fact]
    public void DecryptAndParse_ParsesCustomerServiceNotification()
    {
        const string corpId = "ww12345678910";
        const string token = "callback-token";
        const string timestamp = "1348831860";
        const string nonce = "test-nonce";
        var encodingAesKey = Convert.ToBase64String(new byte[32]).TrimEnd('=');
        using var client = WecomClient.Create(new WecomOptions
        {
            CorpId = corpId,
            CorpSecret = "secret",
            CallbackToken = token,
            CallbackEncodingAesKey = encodingAesKey
        });
        var callback = Assert.IsType<CallbackService>(client.Callback);
        var crypto = new WecomCryptoHelper(token, encodingAesKey, corpId);

        // 微信客服回调示例见 https://developer.work.weixin.qq.com/document/path/94670
        var body = crypto.EncryptReply("""
            <xml>
                <ToUserName><![CDATA[ww12345678910]]></ToUserName>
                <CreateTime>1348831860</CreateTime>
                <MsgType><![CDATA[event]]></MsgType>
                <Event><![CDATA[kf_msg_or_event]]></Event>
                <Token><![CDATA[customer-service-event-token]]></Token>
                <OpenKfId><![CDATA[wkxxxxxxx]]></OpenKfId>
            </xml>
            """, timestamp, nonce);
        var envelope = System.Xml.Linq.XElement.Parse(body);
        var signature = envelope.Element("MsgSignature")!.Value;
        var evt = Assert.IsType<KfMessageOrEventCallback>(callback.DecryptAndParse(signature, timestamp, nonce, body));

        Assert.Equal(corpId, evt.ToUserName);
        Assert.Equal(1348831860, evt.CreateTime);
        Assert.Equal("kf_msg_or_event", evt.Event);
        Assert.Equal("customer-service-event-token", evt.Token);
        Assert.Equal("wkxxxxxxx", evt.OpenKfId);
    }

    private static CallbackMessageBase ParseCustomerEvent(string eventType, string payload)
        => CallbackMessageBase.FromXml($"""
            <xml>
                <ToUserName><![CDATA[ww12345678910]]></ToUserName>
                <FromUserName><![CDATA[sys]]></FromUserName>
                <CreateTime>1403610513</CreateTime>
                <MsgType><![CDATA[event]]></MsgType>
                <Event><![CDATA[{eventType}]]></Event>
                {payload}
            </xml>
            """);
}
