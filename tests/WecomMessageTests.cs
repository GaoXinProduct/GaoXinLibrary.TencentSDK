using System.Net;
using System.Text.Json;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class WecomMessageTests
{
    [Fact]
    public async Task SendAsync_ReusedRequestUsesEachKeyedClientsDefaultAgentId()
    {
        var handler = new MessageHandler();
        using var httpClient = new HttpClient(handler);
        using var services = new ServiceCollection()
            .AddKeyedSingleton<WecomClient>("first", (_, _) => CreateClient(httpClient, 1000001))
            .AddKeyedSingleton<WecomClient>("second", (_, _) => CreateClient(httpClient, 1000002))
            .BuildServiceProvider();
        var first = services.GetRequiredKeyedService<WecomClient>("first");
        var second = services.GetRequiredKeyedService<WecomClient>("second");
        var request = new SendMessageRequest
        {
            ToUser = "zhangsan",
            MsgType = "text",
            Text = new TextContent { Content = "Message" }
        };

        await first.Message.SendAsync(request);
        await second.Message.SendAsync(request);
        await first.Message.SendAsync(request with { AgentId = 1000003 });

        Assert.Equal(0, request.AgentId);
        Assert.Collection(handler.AgentIds,
            agentId => Assert.Equal(1000001, agentId),
            agentId => Assert.Equal(1000002, agentId),
            agentId => Assert.Equal(1000003, agentId));
    }

    private static WecomClient CreateClient(HttpClient httpClient, int agentId)
    {
        var client = WecomClient.Create(new WecomOptions
        {
            CorpId = "corp",
            CorpSecret = "secret",
            AgentId = agentId,
            BaseUrl = "https://example.test"
        }, httpClient);
        client.SetAccessToken("test-token");
        return client;
    }

    private sealed class MessageHandler : HttpMessageHandler
    {
        public List<int> AgentIds { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal("/cgi-bin/message/send", request.RequestUri?.AbsolutePath);
            using var json = JsonDocument.Parse(await request.Content!.ReadAsStringAsync(cancellationToken));
            AgentIds.Add(json.RootElement.GetProperty("agentid").GetInt32());
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{\"errcode\":0}") };
        }
    }
}
