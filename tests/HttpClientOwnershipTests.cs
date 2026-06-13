using System.Net;
using System.Reflection;
using GaoXinLibrary.TencentSDK.Wechat;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Extensions;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class HttpClientOwnershipTests
{
    [Fact]
    public async Task AddWecomService_DisposesSdkCreatedHttpClientWithProvider()
    {
        var services = new ServiceCollection();
        services.AddWecomService(new WecomOptions
        {
            CorpId = "corp",
            CorpSecret = "secret",
            HttpTimeout = TimeSpan.FromMilliseconds(1)
        });

        var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<WecomClient>();
        var httpClient = GetHttpClient(client);

        await provider.DisposeAsync();

        await Assert.ThrowsAsync<ObjectDisposedException>(() => httpClient.GetAsync("http://127.0.0.1:1"));
    }

    [Fact]
    public async Task PublicCreate_DoesNotDisposeExternalHttpClient()
    {
        using var httpClient = new HttpClient(new OkHandler());
        using var client = WechatMiniProgramClient.Create(new WechatMiniProgramOptions
        {
            AppId = "app",
            AppSecret = "secret"
        }, httpClient);

        client.Dispose();

        var response = await httpClient.GetAsync("https://example.test/");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task AddWecomWebHookService_DisposesSdkCreatedHttpClientWithProvider()
    {
        var services = new ServiceCollection();
        services.AddWecomWebHookService(new WecomWebHookOptions { WebhookKey = "key" });

        var provider = services.BuildServiceProvider();
        var service = provider.GetRequiredService<WebhookService>();
        var httpClient = GetHttpClient(service);

        await provider.DisposeAsync();

        await Assert.ThrowsAsync<ObjectDisposedException>(() => httpClient.GetAsync("http://127.0.0.1:1"));
    }

    private static HttpClient GetHttpClient(object instance)
    {
        var field = instance.GetType().GetField("_httpClient", BindingFlags.Instance | BindingFlags.NonPublic)
                    ?? instance.GetType().GetField("_http", BindingFlags.Instance | BindingFlags.NonPublic);
        Assert.NotNull(field);
        return Assert.IsType<HttpClient>(field.GetValue(instance));
    }

    private sealed class OkHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
    }
}
