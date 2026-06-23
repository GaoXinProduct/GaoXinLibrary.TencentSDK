using GaoXinLibrary.TencentSDK.Wechat;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Extensions;
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Extensions;
using GaoXinLibrary.TencentSDK.Core;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class ShareServiceRegistrationTests
{
    [Fact]
    public void NormalOptions_DoNotExposeShareServiceFields()
    {
        // ShareSecret is allowed on primary Options (WecomOptions, WechatOfficialOptions) for convenience;
        // SecretShareUrl must remain exclusive to ShareOptions (backup server only).
        Assert.DoesNotContain(typeof(WecomOptions).GetProperties(), property => property.Name is "SecretShareUrl");
        Assert.DoesNotContain(typeof(WechatOptions).GetProperties(), property => property.Name is "ShareSecret" or "SecretShareUrl");
        Assert.DoesNotContain(typeof(WechatOfficialOptions).GetProperties(), property => property.Name is "SecretShareUrl");
        Assert.DoesNotContain(typeof(WechatMiniProgramOptions).GetProperties(), property => property.Name is "ShareSecret" or "SecretShareUrl");
        Assert.DoesNotContain(typeof(WechatOpenOptions).GetProperties(), property => property.Name is "ShareSecret" or "SecretShareUrl");
        Assert.DoesNotContain(typeof(QQConnectOptions).GetProperties(), property => property.Name is "ShareSecret" or "SecretShareUrl");
    }

    [Fact]
    public void WecomShareService_RegistersClientWithoutCorpSecret()
    {
        var services = new ServiceCollection();
        services.AddWecomShareService(new WecomShareOptions
        {
            ShareSecret = "shared-secret",
            SecretShareUrl = "https://primary.example/wecom/share"
        });

        using var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<WecomClient>();

        Assert.Equal("https://primary.example/wecom/share", provider.GetRequiredService<WecomShareOptions>().SecretShareUrl);
        Assert.NotNull(client);
    }

    [Fact]
    public void WechatOfficialShareService_RegistersClientWithoutAppSecret()
    {
        var services = new ServiceCollection();
        services.AddWechatOfficialShareService(new WechatOfficialShareOptions
        {
            ShareSecret = "shared-secret",
            SecretShareUrl = "https://primary.example/official/share"
        });

        using var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<WechatOfficialClient>();

        Assert.Equal("https://primary.example/official/share", provider.GetRequiredService<WechatOfficialShareOptions>().SecretShareUrl);
        Assert.NotNull(client);
    }

    [Fact]
    public void WechatMiniProgramShareService_BindsConfigurationAndRegistersKeyedClient()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Share:ShareSecret"] = "shared-secret",
                ["Share:SecretShareUrl"] = "https://primary.example/miniprogram/share"
            })
            .Build();

        var services = new ServiceCollection();
        services.AddWechatMiniProgramShareService("mini", configuration.GetSection("Share"));

        using var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredKeyedService<WechatMiniProgramClient>("mini");

        Assert.Equal("https://primary.example/miniprogram/share", provider.GetRequiredKeyedService<WechatMiniProgramShareOptions>("mini").SecretShareUrl);
        Assert.NotNull(client);
    }

    [Fact]
    public async Task WecomShareClient_FetchesTokenFromSharedSecretEndpoint()
    {
        const string shareSecret = "shared-secret";
        var payload = JsonSerializer.Serialize(new SharedSecretPayload
        {
            AccessToken = "shared-token",
            TokenExpiresIn = 7200,
            CorpId = "corp-from-primary",
            CorpSecret = "secret-from-primary",
            AgentId = 1000001
        });
        var encrypted = TencentTokenCrypto.EncryptWithKey(payload, TencentTokenCrypto.DeriveKey(shareSecret));
        var httpClient = new HttpClient(new SharedSecretHandler(JsonSerializer.Serialize(new { data = encrypted })));
        var client = WecomClient.CreateShareOwned(new WecomShareOptions
        {
            ShareSecret = shareSecret,
            SecretShareUrl = "https://primary.example/wecom/share"
        }, httpClient);

        var token = await client.GetAccessTokenAsync();

        Assert.Equal("shared-token", token);
        Assert.Equal("corp-from-primary", client.Options.CorpId);
        Assert.Equal(1000001, client.Options.AgentId);
    }

    private sealed class SharedSecretHandler(string response) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(response)
            });
    }
}
