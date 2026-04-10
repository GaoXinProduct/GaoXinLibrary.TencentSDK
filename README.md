# GaoXinLibrary.TencentSDK

腾讯平台统一 .NET 服务端 SDK，一个包覆盖五个平台：

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![NuGet](https://img.shields.io/nuget/v/GaoXinLibrary.TencentSDK.svg)](https://www.nuget.org/packages/GaoXinLibrary.TencentSDK)
[![.NET](https://img.shields.io/badge/.NET-8%20%7C%209%20%7C%2010-512BD4)](https://dotnet.microsoft.com/download)

| 平台 | 门面客户端 |
|---|---|
| 企业微信 | `WecomClient` |
| 微信小程序 | `WechatMiniProgramClient` |
| 微信公众号 | `WechatOfficialClient` |
| 微信开放平台 | `WechatOpenClient` |
| QQ 互联 | `QQConnectClient` |

---

## 目录

- [安装](#安装)
- [核心特性](#核心特性)
- [快速开始](#快速开始)
- [ASP.NET Core 依赖注入](#aspnet-core-依赖注入)
- [多实例注册（Keyed Services）](#多实例注册keyed-services)
- [从 IConfiguration 绑定](#从-iconfiguration-绑定)
- [客户端能力一览](#客户端能力一览)
- [配置项参考](#配置项参考)
- [Token 管理](#token-管理)
- [备服务器模式（共享密钥）](#备服务器模式共享密钥)
- [消息回调与加解密](#消息回调与加解密)
- [会话内容存档（Finance）](#会话内容存档finance)
- [瞬态故障重试](#瞬态故障重试)
- [构建与发布](#构建与发布)

---

## 安装

```bash
dotnet add package GaoXinLibrary.TencentSDK
```

要求 .NET 8.0 / 9.0 / 10.0。

---

## 核心特性

- **门面客户端**：通过 `client.Message`、`client.User` 等强类型属性访问全部子能力，无需单独注入多个服务
- **依赖注入友好**：`AddWecomService`、`AddWechatMiniProgramService` 等扩展方法，三种重载（`Action<TOptions>` / 对象直传 / `IConfiguration`）
- **多实例支持**：Keyed Services 注册多套凭证，推荐通过工厂接口按名称获取
- **自动 Token 管理**：内置缓存 + 自动刷新 + 手动写入 + Token 变更回调
- **备服务器模式**：多台服务器共享同一 `access_token`，避免多点刷新冲突
- **消息回调加解密**：AES-256-CBC 签名校验、解密、回复加密，开箱即用
- **瞬态故障重试**：`HttpRequestException`、超时、5xx 按指数退避重试，Token 失效单独处理
- **会话内容存档**：企业微信 Finance C SDK P/Invoke 封装（需自行提供原生库）

---

## 快速开始

### 直接创建客户端（非 DI 场景）

所有客户端均通过静态工厂方法 `Create(options)` 创建，实现 `IDisposable`，用完后需释放。

**企业微信**

```csharp
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;

using var client = WecomClient.Create(new WecomOptions
{
    CorpId     = "your_corpid",
    CorpSecret = "your_corpsecret",
    AgentId    = 1000001
});

// 发送应用消息
await client.Message.SendTextAsync("Hello!", toUser: "@all");

// 查询成员信息
var user = await client.User.GetUserAsync("zhangsan");
```

**微信小程序**

```csharp
using GaoXinLibrary.TencentSDK.Wechat;
using GaoXinLibrary.TencentSDK.Wechat.Core;

using var client = WechatMiniProgramClient.Create(new WechatMiniProgramOptions
{
    AppId     = "your_appid",
    AppSecret = "your_appsecret"
});

var session = await client.Auth.Code2SessionAsync("js_code");
Console.WriteLine(session.OpenId);
```

**微信公众号**

```csharp
using var client = WechatOfficialClient.Create(new WechatOfficialOptions
{
    AppId                  = "your_appid",
    AppSecret              = "your_appsecret",
    CallbackToken          = "your_token",           // 可选：启用回调
    CallbackEncodingAesKey = "your_43char_aes_key"   // 可选：启用回调
});

var authUrl = client.OAuth.BuildAuthUrl("https://example.com/callback");
var ticket  = await client.JsSdk.GetTicketAsync();
```

**微信开放平台**

```csharp
using var client = WechatOpenClient.Create(new WechatOpenOptions
{
    AppId     = "your_open_appid",
    AppSecret = "your_open_appsecret"
});

var loginUrl = client.WebLogin.BuildAuthUrl("https://example.com/callback", state: "state");
```

**QQ 互联**

```csharp
using var client = QQConnectClient.Create(new QQConnectOptions
{
    AppId     = "your_qq_appid",
    AppSecret = "your_qq_appkey"
});

var loginUrl = client.Login.BuildAuthUrl("https://example.com/callback", state: "state");
```

---

## ASP.NET Core 依赖注入

### 微信平台

```csharp
using GaoXinLibrary.TencentSDK.Wechat.Extensions;

builder.Services.AddWechatMiniProgramService(options =>
{
    options.AppId     = "mini_appid";
    options.AppSecret = "mini_secret";
});

builder.Services.AddWechatOfficialService(options =>
{
    options.AppId                  = "official_appid";
    options.AppSecret              = "official_secret";
    options.CallbackToken          = "callback_token";          // 配置后自动注册 IOfficialCallbackService
    options.CallbackEncodingAesKey = "encoding_aes_key";
});

builder.Services.AddWechatOpenService(options =>
{
    options.AppId     = "open_appid";
    options.AppSecret = "open_secret";
});

builder.Services.AddQQConnectService(options =>
{
    options.AppId     = "qq_appid";
    options.AppSecret = "qq_secret";
});
```

注入与使用：

```csharp
public class MyService(WechatMiniProgramClient miniProgram, WechatOfficialClient official)
{
    public async Task DoWorkAsync()
    {
        var session = await miniProgram.Auth.Code2SessionAsync("js_code");
        await official.TemplateMessage.SendAsync(...);
    }
}
```

### 企业微信核心能力

```csharp
using GaoXinLibrary.TencentSDK.Wecom.Extensions;

builder.Services.AddWecomService(options =>
{
    options.CorpId     = "your_corpid";
    options.CorpSecret = "your_corpsecret";
    options.AgentId    = 1000001;
});
```

> `AddWecomService` 只注册 `WecomClient` 核心功能，**不包含** `IWebhookService`、`ISmartRobotService`、`ISmartRobotWsClient`、`ICallbackService`，这些能力通过独立扩展方法按需注册。

### 企业微信群机器人

```csharp
// 仅需 WebhookKey，与核心 WecomOptions 完全解耦
builder.Services.AddWecomWebHookService(options =>
{
    options.WebhookKey = "your_webhook_key";
});
```

注册后注入 `IWebhookService`，所有方法无需再传 `webhookKey` 参数。

### 企业微信智能机器人

```csharp
builder.Services.AddWecomSmartBotService(options =>
{
    options.CorpId     = "your_corpid";
    options.CorpSecret = "your_corpsecret";
    options.AgentId    = 1000001;

    // 可选：API 回调模式
    options.CallbackToken          = "your_callback_token";
    options.CallbackEncodingAesKey = "your_43char_aes_key";

    // 可选：WebSocket 长连接模式（BotId + BotSecret 同时配置才生效）
    options.BotId     = "your_bot_id";
    options.BotSecret = "your_bot_secret";
    // options.BotWsUrl = "wss://openws.work.weixin.qq.com"; // 默认值
});
```

按需注册规则：

| 服务 | 注册条件 |
|---|---|
| `ISmartRobotService` | 始终注册 |
| `ISmartRobotWsClient` | `BotId` + `BotSecret` 均配置 |
| `ICallbackService` | `CallbackToken` + `CallbackEncodingAesKey` 均配置 |

> `AddWecomSmartBotService` 内部会幂等调用 `AddWecomService`，确保 `WecomClient` 已就绪。

---

## 多实例注册（Keyed Services）

同一平台可注册多套凭证（如多租户场景），**推荐通过工厂接口**获取实例，而非在 Controller 构造函数中使用 `[FromKeyedServices("name")]`。

### 注册多实例

```csharp
builder.Services.AddWecomService("app1", opt =>
{
    opt.CorpId     = "corp1";
    opt.CorpSecret = "secret1";
    opt.AgentId    = 1000001;
});

builder.Services.AddWecomService("app2", opt =>
{
    opt.CorpId     = "corp1";
    opt.CorpSecret = "secret2";
    opt.AgentId    = 1000002;
});
```

### 通过工厂获取

```csharp
public class MultiTenantService(IWecomClientFactory wecomFactory)
{
    public async Task NotifyAsync(string appName)
    {
        var client = wecomFactory.CreateClient(appName);
        await client.Message.SendTextAsync("通知内容", toUser: "@all");
    }
}
```

### 工厂接口汇总

| 平台 | 工厂接口 | 主要方法 | 返回类型 |
|---|---|---|---|
| 企业微信 | `IWecomClientFactory` | `CreateClient(name)` | `WecomClient` |
| 群机器人 | `IWebhookServiceFactory` | `CreateClient(name)` | `IWebhookService` |
| 智能机器人 | `IWecomSmartBotServiceFactory` | `CreateClient(name)` / `CreateWsClient(name)` | `ISmartRobotService` / `ISmartRobotWsClient?` |
| 微信小程序 | `IWechatMiniProgramClientFactory` | `CreateClient(name)` | `WechatMiniProgramClient` |
| 微信公众号 | `IWechatOfficialClientFactory` | `CreateClient(name)` | `WechatOfficialClient` |
| 微信开放平台 | `IWechatOpenClientFactory` | `CreateClient(name)` | `WechatOpenClient` |
| QQ 互联 | `IQQConnectClientFactory` | `CreateClient(name)` | `QQConnectClient` |

---

## 从 IConfiguration 绑定

所有扩展方法均支持 `IConfigurationSection` 重载：

```csharp
builder.Services.AddWechatMiniProgramService(builder.Configuration.GetSection("WechatMiniProgram"));
builder.Services.AddWechatOfficialService(builder.Configuration.GetSection("WechatOfficial"));
builder.Services.AddWechatOpenService(builder.Configuration.GetSection("WechatOpen"));
builder.Services.AddQQConnectService(builder.Configuration.GetSection("QQConnect"));
builder.Services.AddWecomService(builder.Configuration.GetSection("Wecom"));
builder.Services.AddWecomWebHookService(builder.Configuration.GetSection("WecomWebHook"));
builder.Services.AddWecomSmartBotService(builder.Configuration.GetSection("WecomSmartBot"));
```

对应 `appsettings.json`：

```json
{
  "WechatMiniProgram": {
    "AppId": "mini_appid",
    "AppSecret": "mini_secret"
  },
  "WechatOfficial": {
    "AppId": "official_appid",
    "AppSecret": "official_secret",
    "CallbackToken": "callback_token",
    "CallbackEncodingAesKey": "encoding_aes_key"
  },
  "WechatOpen": {
    "AppId": "open_appid",
    "AppSecret": "open_secret"
  },
  "QQConnect": {
    "AppId": "qq_appid",
    "AppSecret": "qq_secret"
  },
  "Wecom": {
    "CorpId": "your_corpid",
    "CorpSecret": "your_corpsecret",
    "AgentId": 1000001
  },
  "WecomWebHook": {
    "WebhookKey": "your_webhook_key"
  },
  "WecomSmartBot": {
    "CorpId": "your_corpid",
    "CorpSecret": "your_corpsecret",
    "AgentId": 1000001,
    "CallbackToken": "your_callback_token",
    "CallbackEncodingAesKey": "your_43char_aes_key",
    "BotId": "your_bot_id",
    "BotSecret": "your_bot_secret"
  }
}
```

---

## 客户端能力一览

### WecomClient — 企业微信

| 属性 | 说明 |
|---|---|
| `User` | 成员管理 |
| `Department` | 部门管理 |
| `Tag` | 标签管理 |
| `Message` | 应用消息发送 |
| `Agent` | 应用管理与配置 |
| `Menu` | 自定义菜单（与 `Agent` 共用实例） |
| `Media` | 素材管理 |
| `GroupChat` | 应用群聊会话管理 |
| `OAuth` | 网页授权登录（OAuth2） |
| `CorpGroup` | 企业互联 |
| `LinkedCorp` | 上下游 / 互联企业 |
| `Kf` | 微信客服 |
| `MsgAudit` | 会话内容存档 |
| `JsSdk` | 企业微信 H5 / JS-SDK（含企业级和应用级 ticket） |
| `Checkin` | 打卡 |
| `Approval` | 审批 |
| `Export` | 异步导出 |
| `AsyncImport` | 异步导入 |
| `SecondVerify` | 二次验证 |
| `Security` | 安全管理 |
| `AdvancedAccount` | 高级功能账号管理 |
| `OperationLog` | 操作日志 |
| `AccountId` | 账号 ID 管理 |
| `IpRange` | IP 段查询 |
| `ExternalContact` | 客户联系 |
| `CorpPay` | 企业支付 |
| `Email` | 邮件 |
| `Document` | 文档 |
| `Calendar` | 日程 |
| `Meeting` | 会议 |
| `Wedrive` | 微盘 |
| `Living` | 直播 |
| `Dial` | 公费电话 |
| `Report` | 汇报 |
| `Hr` | 人事助手 |
| `MeetingRoom` | 会议室 |
| `Invoice` | 电子发票 |
| `SmartSheet` | 智能表格 |
| `CollectForm` | 收集表 |

群机器人（`IWebhookService`）和智能机器人（`ISmartRobotService` / `ISmartRobotWsClient`）是独立注册能力，不通过 `WecomClient` 属性访问。

### WechatMiniProgramClient — 微信小程序

| 属性 | 说明 |
|---|---|
| `Auth` | 登录（code2session）与手机号解密 |
| `QrCode` | 小程序码生成 |
| `SubscribeMessage` | 订阅消息 |
| `Security` | 内容安全检测 |
| `Shipping` | 发货信息管理 |
| `Ocr` | OCR 与图像处理 |
| `Link` | URL Scheme / URL Link / Short Link |
| `DataAnalysis` | 数据分析 |
| `Express` | 物流助手 |
| `Operation` | 运维中心 |
| `Device` | 硬件设备 |
| `CustomMessage` | 客服消息 |
| `OpenApi` | OpenAPI 管理 |

### WechatOfficialClient — 微信公众号

| 属性 | 说明 |
|---|---|
| `OAuth` | 网页授权（静默 / 用户信息） |
| `Menu` | 自定义菜单 |
| `TemplateMessage` | 模板消息 |
| `User` | 用户管理 |
| `QrCode` | 服务号二维码 |
| `Material` | 素材管理 |
| `JsSdk` | JS-SDK（ticket 自动获取 + 签名生成） |
| `Tag` | 用户标签管理 |
| `Draft` | 草稿管理 |
| `Publish` | 发布能力 |
| `Comment` | 留言管理 |
| `CustomMessage` | 客服消息 |
| `Message` | 群发消息 / 模板管理 |
| `DataAnalysis` | 数据统计 |
| `Ai` | 语义理解 / OCR |
| `Poi` | 微信门店 |
| `Invoice` | 微信发票 |
| `OpenApi` | OpenAPI 管理 |
| `Callback` | 消息回调解析与加密回复 |

### WechatOpenClient — 微信开放平台

| 属性 | 说明 |
|---|---|
| `WebLogin` | 网站应用微信扫码登录（OAuth2 + 用户信息） |

### QQConnectClient — QQ 互联

| 属性 | 说明 |
|---|---|
| `Login` | QQ 登录（构建授权 URL、code 换 token、获取用户信息） |

---

## 配置项参考

### WechatOptions（微信平台基类）

继承关系：`WechatMiniProgramOptions`、`WechatOfficialOptions`、`WechatOpenOptions`、`QQConnectOptions` 均继承此类。

| 字段 | 类型 | 默认值 | 说明 |
|---|---|---|---|
| `AppId` | `string` | — | 应用 ID |
| `AppSecret` | `string` | — | 应用密钥 |
| `BaseUrl` | `string` | `https://api.weixin.qq.com` | API 基础地址 |
| `HttpTimeout` | `TimeSpan` | 30 秒 | HTTP 请求超时 |
| `ShareSecret` | `string?` | `null` | 备服务器共享密钥（ChaCha20-Poly1305，SHA-256 派生） |
| `SecretShareUrl` | `string?` | `null` | 备服务器拉取载荷的 URL，配置后无需 AppSecret |
| `OnTokenChanged` | `Func<string, CancellationToken, Task>?` | `null` | Token 刷新成功回调 |
| `RetryOptions` | `TencentRetryOptions?` | 默认启用 | 瞬态故障重试配置 |

`WechatOfficialOptions` 额外字段：

| 字段 | 类型 | 说明 |
|---|---|---|
| `CallbackToken` | `string?` | 消息回调 Token（签名校验） |
| `CallbackEncodingAesKey` | `string?` | 消息加解密 AES Key（43 位） |
| `OnTicketChanged` | `Func<string, CancellationToken, Task>?` | jsapi_ticket 刷新回调 |

### WecomOptions（企业微信）

| 字段 | 类型 | 默认值 | 说明 |
|---|---|---|---|
| `CorpId` | `string` | — | 企业 ID |
| `CorpSecret` | `string` | — | 应用密钥 |
| `AgentId` | `int` | 0 | 自建应用 AgentId，消息发送时自动注入，无需手动传参 |
| `BaseUrl` | `string` | `https://qyapi.weixin.qq.com` | API 基础地址 |
| `HttpTimeout` | `TimeSpan` | 30 秒 | HTTP 请求超时 |
| `CallbackToken` | `string?` | `null` | 消息回调 Token |
| `CallbackEncodingAesKey` | `string?` | `null` | 消息加解密 AES Key（43 位） |
| `MsgAuditSecret` | `string?` | `null` | 会话存档专用密钥（管理后台获取） |
| `MsgAuditPrivateKey` | `string?` | `null` | 会话存档 RSA 私钥（PEM 格式），用于解密 encrypt_random_key |
| `ShareSecret` | `string?` | `null` | 备服务器共享密钥 |
| `SecretShareUrl` | `string?` | `null` | 备服务器拉取载荷 URL |
| `OnTokenChanged` | `Func<string, CancellationToken, Task>?` | `null` | Token 刷新回调 |
| `RetryOptions` | `TencentRetryOptions?` | 默认启用 | 重试配置 |

### WecomWebHookOptions（群机器人）

| 字段 | 类型 | 说明 |
|---|---|---|
| `WebhookKey` | `string?` | 群机器人 Webhook Key，注册后无需每次传入 |

### WecomSmartBotOptions（智能机器人）

| 字段 | 类型 | 说明 |
|---|---|---|
| `CorpId` | `string` | 企业 ID |
| `CorpSecret` | `string` | 应用密钥 |
| `AgentId` | `int` | 自建应用 AgentId |
| `BaseUrl` | `string` | 默认 `https://qyapi.weixin.qq.com` |
| `HttpTimeout` | `TimeSpan` | 默认 30 秒 |
| `CallbackToken` | `string?` | API 回调 Token（配置后注册 `ICallbackService`） |
| `CallbackEncodingAesKey` | `string?` | API 回调 AES Key（43 位） |
| `BotId` | `string?` | 长连接机器人 ID（配置后注册 `ISmartRobotWsClient`） |
| `BotSecret` | `string?` | 长连接专用密钥 |
| `BotWsUrl` | `string` | 默认 `wss://openws.work.weixin.qq.com` |

### TencentRetryOptions（重试）

| 字段 | 类型 | 默认值 | 说明 |
|---|---|---|---|
| `MaxRetries` | `int` | 2 | 最大重试次数，0 表示禁用 |
| `InitialDelay` | `TimeSpan` | 500ms | 首次重试等待时间 |
| `MaxDelay` | `TimeSpan` | 5s | 单次重试等待上限（指数退避不超过此值） |

---

## Token 管理

所有客户端内置 `access_token` 自动缓存与刷新（提前 60 秒判定过期），同时暴露手动控制接口：

```csharp
// 获取当前有效 token（命中缓存直接返回，否则自动刷新）
var token = await client.GetAccessTokenAsync();

// 强制刷新（立即向腾讯请求新 token）
var newToken = await client.RefreshAccessTokenAsync();

// 手动写入（适用于从外部令牌服务获取 token 的场景）
client.SetAccessToken("token_value", expiresIn: TimeSpan.FromSeconds(7200));

// 使缓存失效（下次 GetAccessTokenAsync 时触发重新获取）
client.InvalidateAccessTokenCache();
```

`WecomClient` 额外提供企业级和应用级 jsapi_ticket 的相同管理接口：

```csharp
// 企业级 jsapi_ticket
await client.GetJsApiTicketAsync();
await client.RefreshJsApiTicketAsync();
client.SetJsApiTicket("ticket_value");
client.InvalidateJsApiTicketCache();

// 应用级 jsapi_ticket
await client.GetAgentTicketAsync();
await client.RefreshAgentTicketAsync();
client.SetAgentTicket("ticket_value");
client.InvalidateAgentTicketCache();
```

---

## 备服务器模式（共享密钥）

适用于多台服务器只需一个节点对接腾讯 API、其余节点共享 token 的场景。

**主服务器**：正常配置 `CorpId` / `CorpSecret`，额外配置 `ShareSecret`，暴露一个受保护的内部接口：

```csharp
// 主服务器：获取加密载荷（包含 access_token、jsapi_ticket 等）
var result = await client.GetSharedSecretAsync();
// 将 result.Data 通过内部接口返回给备服务器
```

**备服务器**：只需配置 `SecretShareUrl` + `ShareSecret`，不需要 `CorpSecret` / `AppSecret`：

```csharp
builder.Services.AddWecomService(options =>
{
    options.ShareSecret    = "shared_secret_same_as_primary";
    options.SecretShareUrl = "https://primary-server/internal/shared-secret";
    // CorpId / CorpSecret 可省略
});
```

载荷传输加密：ChaCha20-Poly1305，密钥由 `ShareSecret` 经 SHA-256 派生。

---

## 消息回调与加解密

### 微信公众号

配置 `CallbackToken` + `CallbackEncodingAesKey` 后，可通过 `client.Callback` 或注入的 `IOfficialCallbackService` 处理回调：

- 签名校验
- AES-256-CBC 消息解密
- 加密回复报文生成

### 企业微信

企业微信回调通过 `AddWecomSmartBotService` 的 `ICallbackService` 处理（`AddWecomService` 本身**不注册**回调服务）。

> **switch 类型顺序陷阱**：`CallbackUpdateUserEvent` 继承自 `CallbackCreateUserEvent`，`CallbackUpdatePartyEvent` 继承自 `CallbackCreatePartyEvent`。在 `switch` 表达式中，**子类 case 必须放在父类之前**，否则会错误匹配到父类。

---

## 会话内容存档（Finance）

`Core/Finance/FinanceSdk.cs` 通过 P/Invoke 封装企业微信 Finance C SDK，支持拉取聊天记录、解密消息媒体等功能。

运行时需在输出目录中提供原生库：

| 平台 | 文件名 |
|---|---|
| Windows | `WeWorkFinanceSdk_C.dll` |
| Linux | `libWeWorkFinanceSdk_C.so` |

这些文件**不包含在本仓库中**，请从企业微信官方渠道获取并自行部署。

在企业微信管理后台「管理工具 - 会话内容存档」获取 `MsgAuditSecret` 和 RSA 密钥对，配置到 `WecomOptions.MsgAuditSecret` 和 `MsgAuditPrivateKey`。

---

## 瞬态故障重试

SDK 对以下错误内置指数退避重试：

- `HttpRequestException`（连接失败、DNS 解析失败等）
- 任务取消（请求超时）
- HTTP 5xx 服务端错误

Token 失效（腾讯返回 token 过期错误码）由独立的内层机制处理，不受 `RetryOptions` 控制。

```csharp
// 自定义重试策略
builder.Services.AddWecomService(options =>
{
    options.CorpId     = "...";
    options.CorpSecret = "...";
    options.RetryOptions = new TencentRetryOptions
    {
        MaxRetries   = 3,
        InitialDelay = TimeSpan.FromMilliseconds(300),
        MaxDelay     = TimeSpan.FromSeconds(10)
    };
    // 禁用重试：
    // options.RetryOptions = null;
});
```

---

## License

[MIT](LICENSE)
