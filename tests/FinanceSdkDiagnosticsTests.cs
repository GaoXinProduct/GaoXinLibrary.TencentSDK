using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core.Finance;
using System.Security.Cryptography;
using Xunit;

namespace GaoXinLibrary.TencentSDK.Tests;

public sealed class FinanceSdkDiagnosticsTests
{
    [Fact]
    public void Constructor_WhenNativeLibraryIsMissing_ThrowsActionableTencentException()
    {
        var exception = Assert.Throws<TencentException>(() => new FinanceSdk("corp", "secret"));

        Assert.Contains("WeWorkFinanceSdk_C", exception.Message);
        Assert.Contains("libWeWorkFinanceSdk_C.so", exception.Message);
        Assert.Contains("WeWorkFinanceSdk_C.dll", exception.Message);
        Assert.Contains("输出目录", exception.Message);
    }

    [Fact]
    public void DecryptChatMessage_WhenNativeLibraryIsMissing_ThrowsActionableTencentException()
    {
        using var rsa = RSA.Create(2048);
        var privateKeyPem = rsa.ExportRSAPrivateKeyPem();
        var encryptedRandomKey = Convert.ToBase64String(rsa.Encrypt("encrypt-key"u8.ToArray(), RSAEncryptionPadding.Pkcs1));

        var exception = Assert.Throws<TencentException>(() =>
            FinanceSdk.DecryptChatMessage(privateKeyPem, encryptedRandomKey, "encrypted-chat-message"));

        Assert.Contains("WeWorkFinanceSdk_C", exception.Message);
        Assert.Contains("libWeWorkFinanceSdk_C.so", exception.Message);
        Assert.Contains("WeWorkFinanceSdk_C.dll", exception.Message);
        Assert.Contains("输出目录", exception.Message);
    }
}
