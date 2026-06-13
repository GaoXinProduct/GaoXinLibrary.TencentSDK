using System.Text;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Services;
using Microsoft.Extensions.Logging;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class SmartRobotWsClientDiagnosticsTests
{
    [Fact]
    public void ProcessTextMessage_LogsMalformedJson()
    {
        var logger = new TestLogger<SmartRobotWsClient>();
        var client = new SmartRobotWsClient(new WecomSmartBotOptions
        {
            BotId = "bot",
            BotSecret = "secret"
        }, logger);

        client.ProcessTextMessageForTest(Encoding.UTF8.GetBytes("{"));

        Assert.Contains(logger.Entries, entry =>
            entry.Level == LogLevel.Warning &&
            entry.Message.Contains("WebSocket", StringComparison.OrdinalIgnoreCase) &&
            entry.Exception is not null);
    }
}
