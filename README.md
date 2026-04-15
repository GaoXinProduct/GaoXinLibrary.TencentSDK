# GaoXinLibrary.TencentSDK

腾讯平台统一 .NET 服务端 SDK，一个包覆盖五个平台：

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![NuGet](https://img.shields.io/nuget/v/GaoXinLibrary.TencentSDK.svg)](https://www.nuget.org/packages/GaoXinLibrary.TencentSDK)
[![.NET](https://img.shields.io/badge/.NET-8%20%7C%209%20%7C%2010-512BD4)](https://dotnet.microsoft.com/download)

| 平台 | 门面客户端 | 命名空间 |
|---|---|---|
| 企业微信 | `WecomClient` | `GaoXinLibrary.TencentSDK.Wecom` |
| 微信小程序 | `WechatMiniProgramClient` | `GaoXinLibrary.TencentSDK.Wechat` |
| 微信公众号 | `WechatOfficialClient` | `GaoXinLibrary.TencentSDK.Wechat` |
| 微信开放平台 | `WechatOpenClient` | `GaoXinLibrary.TencentSDK.Wechat` |
| QQ 互联 | `QQConnectClient` | `GaoXinLibrary.TencentSDK.Wechat` |

---

## 目录

- [安装](#安装)
- [核心特性](#核心特性)
- [快速开始（非 DI 场景）](#快速开始非-di-场景)
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

---

## 安装

```bash
dotnet add package GaoXinLibrary.TencentSDK
```

要求 .NET 8.0 / 9.0 / 10.0。

---

## 核心特性

- **门面客户端**：通过 `client.Message`、`client.User` 等强类型属性访问全部子能力，无需单独注入多个服务
- **依赖注入友好**：`AddWecomService`、`AddWechatMiniProgramService` 等扩展方法，均提供三种重载（`Action<TOptions>` / 对象直传 / `IConfiguration`）
- **多实例支持**：Keyed Services 注册多套凭证，通过工厂接口按名称获取实例
- **自动 Token 管理**：内置缓存 + 自动刷新（提前 60 秒判定过期）+ 手动写入 + Token 变更回调
- **备服务器模式**：多台服务器共享同一 `access_token`，避免多点刷新冲突（ChaCha20-Poly1305 加密传输）
- **消息回调加解密**：AES-256-CBC 签名校验、消息解密、回复加密，开箱即用
- **瞬态故障重试**：`HttpRequestException`、超时、5xx 按指数退避重试；Token 失效由独立内层机制处理
- **会话内容存档**：企业微信 Finance C SDK P/Invoke 封装（需自行提供原生库）

---

## 快速开始（非 DI 场景）

所有客户端均通过静态工厂方法 `Create(options)` 或 `Create(options, httpClient)` 创建，实现 `IDisposable`，用完后需释放。

### 企业微信

```csharp
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;

using var client = WecomClient.Create(new WecomOptions
{
    CorpId     = "your_corpid",
    CorpSecret = "your_corpsecret",
    AgentId    = 1000001
});

// 发送应用文本消息（AgentId 已由配置自动注入，无需手动传参）
await client.Message.SendTextAsync("Hello!", toUser: "@all");

// 查询成员信息
var user = await client.User.GetUserAsync("zhangsan");
```

### 微信小程序

```csharp
using GaoXinLibrary.TencentSDK.Wechat;
using GaoXinLibrary.TencentSDK.Wechat.Core;

using var client = WechatMiniProgramClient.Create(new WechatMiniProgramOptions
{
    AppId     = "your_appid",
    AppSecret = "your_appsecret"
});

var session = await client.Auth.Code2SessionAsync("js_code_from_wx_login");
Console.WriteLine(session.OpenId);
```

### 微信公众号

```csharp
using GaoXinLibrary.TencentSDK.Wechat;
using GaoXinLibrary.TencentSDK.Wechat.Core;

using var client = WechatOfficialClient.Create(new WechatOfficialOptions
{
    AppId                  = "your_appid",
    AppSecret              = "your_appsecret",
    CallbackToken          = "your_token",           // 可选：配置后启用消息回调
    CallbackEncodingAesKey = "your_43char_aes_key"   // 可选：配置后启用消息加解密
});

// 构建 OAuth 授权 URL
var authUrl = client.OAuth.BuildAuthUrl("https://example.com/callback");

// 获取 jsapi_ticket（用于 JS-SDK wx.config）
var ticket = await client.JsSdk.GetTicketAsync();
```

### 微信开放平台

```csharp
using GaoXinLibrary.TencentSDK.Wechat;
using GaoXinLibrary.TencentSDK.Wechat.Core;

using var client = WechatOpenClient.Create(new WechatOpenOptions
{
    AppId     = "your_open_appid",
    AppSecret = "your_open_appsecret"
});

// 构建网站扫码登录授权 URL
var loginUrl = client.WebLogin.BuildAuthUrl("https://example.com/callback", state: "random_state");
```

### QQ 互联

```csharp
using GaoXinLibrary.TencentSDK.Wechat;
using GaoXinLibrary.TencentSDK.Wechat.Core;

using var client = QQConnectClient.Create(new QQConnectOptions
{
    AppId     = "your_qq_appid",
    AppSecret = "your_qq_appkey"
});

// 构建 QQ 登录授权 URL
var loginUrl = client.Login.BuildAuthUrl("https://example.com/callback", state: "random_state");
```

---

## ASP.NET Core 依赖注入

所有扩展方法均位于 `Microsoft.Extensions.DependencyInjection.IServiceCollection` 上，按平台分属不同扩展类。

### 微信平台（小程序 / 公众号 / 开放平台 / QQ 互联）

扩展方法命名空间：`GaoXinLibrary.TencentSDK.Wechat.Extensions`

```csharp
using GaoXinLibrary.TencentSDK.Wechat.Extensions;

// 微信小程序
builder.Services.AddWechatMiniProgramService(options =>
{
    options.AppId     = "mini_appid";
    options.AppSecret = "mini_secret";
});

// 微信公众号
builder.Services.AddWechatOfficialService(options =>
{
    options.AppId                  = "official_appid";
    options.AppSecret              = "official_secret";
    // 同时配置以下两项时，SDK 会自动向 DI 注册 IOfficialCallbackService
    options.CallbackToken          = "callback_token";
    options.CallbackEncodingAesKey = "encoding_aes_key";
});

// 微信开放平台
builder.Services.AddWechatOpenService(options =>
{
    options.AppId     = "open_appid";
    options.AppSecret = "open_secret";
});

// QQ 互联
builder.Services.AddQQConnectService(options =>
{
    options.AppId     = "qq_appid";
    options.AppSecret = "qq_appkey";
});
```

注入与使用（直接注入门面客户端，通过属性访问子服务）：

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

### 企业微信核心客户端

扩展方法命名空间：`GaoXinLibrary.TencentSDK.Wecom.Extensions`

```csharp
using GaoXinLibrary.TencentSDK.Wecom.Extensions;

builder.Services.AddWecomService(options =>
{
    options.CorpId     = "your_corpid";
    options.CorpSecret = "your_corpsecret";
    options.AgentId    = 1000001;
});
```

> `AddWecomService` 仅注册 `WecomClient` 核心功能及 `CallbackService`（当 `CallbackToken` + `CallbackEncodingAesKey` 均配置时自动注册）。`WebhookService`、`SmartRobotService`、`ISmartRobotWsClient` 不包含，如需这些服务请分别调用对应的注册方法。

注入示例：

```csharp
public class MyWecomService(WecomClient wecom)
{
    public async Task NotifyAsync()
        => await wecom.Message.SendTextAsync("通知内容", toUser: "@all");
}
```

### 企业微信群机器人

群机器人**不依赖** `access_token`，通过 Webhook Key 直接推送，无需提前调用 `AddWecomService`。

```csharp
using GaoXinLibrary.TencentSDK.Wecom.Extensions;

builder.Services.AddWecomWebHookService(options =>
{
    options.WebhookKey = "your_webhook_key";
});
```

注入后调用时无需再传入 `webhookKey` 参数：

```csharp
public class AlertService(WebhookService webhook)
{
    public Task SendAlertAsync(string text)
        => webhook.SendTextAsync(text);
}
```

### 企业微信智能机器人

`AddWecomSmartBotService` 内部会**幂等**调用 `AddWecomService`，无需提前手动注册 `WecomClient`。

```csharp
using GaoXinLibrary.TencentSDK.Wecom.Extensions;

builder.Services.AddWecomSmartBotService(options =>
{
    options.CorpId     = "your_corpid";
    options.CorpSecret = "your_corpsecret";
    options.AgentId    = 1000001;

    // 可选：配置 API 回调模式（两项同时配置才生效）
    options.CallbackToken          = "your_callback_token";
    options.CallbackEncodingAesKey = "your_43char_aes_key";

    // 可选：配置 WebSocket 长连接模式（两项同时配置才生效）
    options.BotId     = "your_bot_id";
    options.BotSecret = "your_bot_secret";
    // options.BotWsUrl = "wss://openws.work.weixin.qq.com"; // 默认值，可省略
});
```

按需注册规则：

| 服务 | 注册条件 |
|---|---|
| `WecomClient` | 始终（内部幂等调用 `AddWecomService`） |
| `SmartRobotService` | 始终 |
| `ISmartRobotWsClient` | `BotId` 与 `BotSecret` 均非空时 |

注入示例：

```csharp
// API 模式机器人（始终可注入）
public class BotService(SmartRobotService robot) { ... }

// 长连接客户端（仅当 BotId + BotSecret 均配置时可注入）
public class WsService(ISmartRobotWsClient wsClient) { ... }
```

---

## 多实例注册（Keyed Services）

同一平台可注册多套凭证（如多租户、多 AgentId 场景），通过 Keyed Services 管理。**推荐通过工厂接口**按名称获取实例。

### 注册多实例

```csharp
using GaoXinLibrary.TencentSDK.Wecom.Extensions;

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

### 通过工厂接口获取实例（推荐）

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

### 直接通过 Keyed 注入（适用于 Controller 等场景）

```csharp
public class MyController(
    [FromKeyedServices("app1")] WecomClient app1,
    [FromKeyedServices("app2")] WecomClient app2) : ControllerBase { ... }
```

### 工厂接口汇总

| 平台 | 工厂接口 | 主要方法 | 返回类型 |
|---|---|---|---|
| 企业微信 | `IWecomClientFactory` | `CreateClient(name)` | `WecomClient` |
| 群机器人 | `IWebhookServiceFactory` | `CreateClient(name)` | `WebhookService` |
| 智能机器人 | `IWecomSmartBotServiceFactory` | `CreateClient(name)` / `CreateWsClient(name)` | `SmartRobotService` / `ISmartRobotWsClient?` |
| 微信小程序 | `IWechatMiniProgramClientFactory` | `CreateClient(name)` | `WechatMiniProgramClient` |
| 微信公众号 | `IWechatOfficialClientFactory` | `CreateClient(name)` | `WechatOfficialClient` |
| 微信开放平台 | `IWechatOpenClientFactory` | `CreateClient(name)` | `WechatOpenClient` |
| QQ 互联 | `IQQConnectClientFactory` | `CreateClient(name)` | `QQConnectClient` |

> 首次调用带 `name` 参数的 `AddXxxService(name, ...)` 时，工厂接口会被自动注册为单例（幂等），无需手动注册。

---

## 从 IConfiguration 绑定

所有扩展方法均提供 `IConfiguration` / `IConfigurationSection` 重载：

```csharp
using GaoXinLibrary.TencentSDK.Wechat.Extensions;
using GaoXinLibrary.TencentSDK.Wecom.Extensions;

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
    "AppSecret": "qq_appkey"
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

| 属性 | 类型 | 说明 |
|---|---|---|
| `User` | `UserService` | 成员管理（增删改查、部门成员列表） |
| `Department` | `DepartmentService` | 部门管理 |
| `Tag` | `TagService` | 标签管理 |
| `Message` | `MessageService` | 应用消息发送（文本、图片、视频、卡片等） |
| `Agent` | `AgentService` | 应用管理与配置 |
| `Menu` | `AgentService` | 自定义菜单（与 `Agent` 共用同一 `AgentService` 实例） |
| `Media` | `MediaService` | 素材管理（上传/下载） |
| `GroupChat` | `GroupChatService` | 应用群聊会话管理 |
| `OAuth` | `OAuthService` | 网页授权登录（OAuth2） |
| `CorpGroup` | `CorpGroupService` | 企业互联 |
| `LinkedCorp` | `LinkedCorpService` | 上下游 / 互联企业 |
| `Kf` | `KfService` | 微信客服 |
| `MsgAudit` | `MsgAuditService` | 会话内容存档 |
| `JsSdk` | `JsSdkService` | 企业微信 H5 / JS-SDK（企业级与应用级 ticket） |
| `Checkin` | `CheckinService` | 打卡 |
| `Approval` | `ApprovalService` | 审批 |
| `Export` | `ExportService` | 异步导出 |
| `AsyncImport` | `AsyncImportService` | 异步导入 |
| `SecondVerify` | `SecondVerifyService` | 二次验证 |
| `Security` | `SecurityService` | 安全管理 |
| `AdvancedAccount` | `AdvancedAccountService` | 高级功能账号管理 |
| `OperationLog` | `OperationLogService` | 操作日志 |
| `AccountId` | `AccountIdService` | 账号 ID 管理 |
| `IpRange` | `IpRangeService` | IP 段查询 |
| `ExternalContact` | `ExternalContactService` | 客户联系 |
| `CorpPay` | `CorpPayService` | 企业支付 |
| `Email` | `EmailService` | 邮件 |
| `Document` | `DocumentService` | 文档 |
| `Calendar` | `CalendarService` | 日程 |
| `Meeting` | `MeetingService` | 会议 |
| `Wedrive` | `WedriveService` | 微盘 |
| `Living` | `LivingService` | 直播 |
| `Dial` | `DialService` | 公费电话 |
| `Report` | `ReportService` | 汇报 |
| `Hr` | `HrService` | 人事助手 |
| `MeetingRoom` | `MeetingRoomService` | 会议室 |
| `Invoice` | `InvoiceService` | 电子发票 |
| `SmartSheet` | `SmartSheetService` | 智能表格 |
| `CollectForm` | `CollectFormService` | 收集表 |
| `Callback` | `CallbackService?` | 应用消息回调（URL 验证 / 消息解密 / 加密回复）；未配置 `CallbackToken` + `CallbackEncodingAesKey` 时为 `null` |

> 群机器人

### WechatMiniProgramClient — 微信小程序

| 属性 | 类型 | 说明 |
|---|---|---|
| `Auth` | `MiniProgramAuthService` | 登录（code2session）、手机号解密 |
| `QrCode` | `MiniProgramQrCodeService` | 小程序码 / 二维码生成 |
| `SubscribeMessage` | `MiniProgramSubscribeMessageService` | 订阅消息 |
| `Security` | `MiniProgramSecurityService` | 内容安全检测 |
| `Shipping` | `MiniProgramShippingService` | 发货信息管理 |
| `Ocr` | `MiniProgramOcrService` | OCR 与图像处理 |
| `Link` | `MiniProgramLinkService` | URL Scheme / URL Link / Short Link |
| `DataAnalysis` | `MiniProgramDataAnalysisService` | 数据分析 |
| `Express` | `MiniProgramExpressService` | 物流助手 |
| `Operation` | `MiniProgramOperationService` | 运维中心 |
| `Device` | `MiniProgramDeviceService` | 硬件设备 |
| `CustomMessage` | `MiniProgramCustomMessageService` | 客服消息 |
| `OpenApi` | `MiniProgramOpenApiService` | OpenAPI 管理 |

### WechatOfficialClient — 微信公众号

| 属性 | 类型 | 说明 |
|---|---|---|
| `OAuth` | `OfficialOAuthService` | 网页授权（静默 / 用户信息） |
| `Menu` | `OfficialMenuService` | 自定义菜单 |
| `TemplateMessage` | `OfficialTemplateMessageService` | 模板消息 |
| `User` | `OfficialUserService` | 用户管理 |
| `QrCode` | `OfficialQrCodeService` | 服务号二维码 |
| `Material` | `OfficialMaterialService` | 素材管理 |
| `JsSdk` | `OfficialJsSdkService` | JS-SDK（ticket 自动获取 + 签名生成） |
| `Tag` | `OfficialTagService` | 用户标签管理 |
| `Draft` | `OfficialDraftService` | 草稿管理 |
| `Publish` | `OfficialPublishService` | 发布能力 |
| `Comment` | `OfficialCommentService` | 留言管理 |
| `CustomMessage` | `OfficialCustomMessageService` | 客服消息 |
| `Message` | `OfficialMessageService` | 群发消息 / 模板管理 |
| `DataAnalysis` | `OfficialDataAnalysisService` | 数据统计 |
| `Ai` | `OfficialAiService` | 语义理解 / OCR |
| `Poi` | `OfficialPoiService` | 微信门店 |
| `Invoice` | `OfficialInvoiceService` | 微信发票 |
| `OpenApi` | `OfficialOpenApiService` | OpenAPI 管理 |
| `Callback` | `OfficialCallbackService` | 消息回调解析与加密回复 |

### WechatOpenClient — 微信开放平台

| 属性 | 类型 | 说明 |
|---|---|---|
| `WebLogin` | `OpenPlatformService` | 网站应用微信扫码登录（OAuth2 + 用户信息） |

### QQConnectClient — QQ 互联

| 属性 | 类型 | 说明 |
|---|---|---|
| `Login` | `QQConnectService` | QQ 登录（构建授权 URL、code 换 token、获取用户信息） |

---

## 配置项参考

### WechatOptions（微信平台基类）

`WechatMiniProgramOptions`、`WechatOfficialOptions`、`WechatOpenOptions`、`QQConnectOptions` 均继承此类，位于命名空间 `GaoXinLibrary.TencentSDK.Wechat.Core`。

| 字段 | 类型 | 默认值 | 说明 |
|---|---|---|---|
| `AppId` | `string` | — | 应用 ID |
| `AppSecret` | `string` | — | 应用密钥 |
| `BaseUrl` | `string` | `https://api.weixin.qq.com` | API 基础地址 |
| `HttpTimeout` | `TimeSpan` | 30 秒 | HTTP 请求超时 |
| `ShareSecret` | `string?` | `null` | 备服务器共享密钥（ChaCha20-Poly1305，SHA-256 派生 32 字节密钥） |
| `SecretShareUrl` | `string?` | `null` | 备服务器拉取加密载荷的 URL；配置后无需 AppSecret |
| `OnTokenChanged` | `Func<string, CancellationToken, Task>?` | `null` | Token 刷新成功回调（参数为新的明文 access_token） |
| `RetryOptions` | `TencentRetryOptions?` | 默认启用 | 瞬态故障重试配置（见下方） |

### WechatMiniProgramOptions

无额外字段，继承 `WechatOptions` 所有字段。

### WechatOfficialOptions 额外字段

| 字段 | 类型 | 默认值 | 说明 |
|---|---|---|---|
| `CallbackToken` | `string?` | `null` | 消息回调 Token（用于签名校验）；与 `CallbackEncodingAesKey` 同时配置时自动注册 `IOfficialCallbackService` |
| `CallbackEncodingAesKey` | `string?` | `null` | 消息加解密 AES Key（43 位字符） |
| `OnTicketChanged` | `Func<string, CancellationToken, Task>?` | `null` | jsapi_ticket 刷新成功回调 |

### WechatOpenOptions

无额外字段，继承 `WechatOptions` 所有字段。

### QQConnectOptions

覆盖 `BaseUrl` 默认值，无其他额外字段。

| 字段 | 类型 | 默认值 | 说明 |
|---|---|---|---|
| `BaseUrl` | `string` | `https://graph.qq.com` | QQ 互联 API 基础地址（覆盖基类默认值） |

### WecomOptions（企业微信）

位于命名空间 `GaoXinLibrary.TencentSDK.Wecom.Core`。

| 字段 | 类型 | 默认值 | 说明 |
|---|---|---|---|
| `CorpId` | `string` | — | 企业 ID |
| `CorpSecret` | `string` | — | 应用密钥 |
| `AgentId` | `int` | `0` | 自建应用 AgentId；消息发送时自动注入，无需手动传参 |
| `BaseUrl` | `string` | `https://qyapi.weixin.qq.com` | API 基础地址 |
| `HttpTimeout` | `TimeSpan` | 30 秒 | HTTP 请求超时 |
| `CallbackToken` | `string?` | `null` | 应用消息回调 Token；与 `CallbackEncodingAesKey` 同时配置时 `AddWecomService` 自动注册 `CallbackService` |
| `CallbackEncodingAesKey` | `string?` | `null` | 消息加解密 AES Key（43 位字符）；与 `CallbackToken` 同时配置时 `AddWecomService` 自动注册 `CallbackService` |
| `MsgAuditSecret` | `string?` | `null` | 会话存档专用密钥（在企业微信管理后台「管理工具 - 会话内容存档」获取，非 CorpSecret） |
| `MsgAuditPrivateKey` | `string?` | `null` | 会话存档 RSA 私钥（PEM 格式），用于解密 `encrypt_random_key` |
| `ShareSecret` | `string?` | `null` | 备服务器共享密钥 |
| `SecretShareUrl` | `string?` | `null` | 备服务器拉取加密载荷的 URL；配置后可省略 CorpSecret |
| `OnTokenChanged` | `Func<string, CancellationToken, Task>?` | `null` | Token 刷新成功回调 |
| `RetryOptions` | `TencentRetryOptions?` | 默认启用 | 瞬态故障重试配置 |

### WecomWebHookOptions（群机器人）

位于命名空间 `GaoXinLibrary.TencentSDK.Wecom.Core`。

| 字段 | 类型 | 说明 |
|---|---|---|
| `WebhookKey` | `string?` | 群机器人 Webhook Key；注册后调用时无需再传入 |

### WecomSmartBotOptions（智能机器人）

位于命名空间 `GaoXinLibrary.TencentSDK.Wecom.Core`。该类**不继承** `WecomOptions`，是独立配置类。

| 字段 | 类型 | 默认值 | 说明 |
|---|---|---|---|
| `CorpId` | `string` | — | 企业 ID |
| `CorpSecret` | `string` | — | 应用密钥 |
| `AgentId` | `int` | `0` | 自建应用 AgentId |
| `BaseUrl` | `string` | `https://qyapi.weixin.qq.com` | API 基础地址 |
| `HttpTimeout` | `TimeSpan` | 30 秒 | HTTP 请求超时 |
| `CallbackToken` | `string?` | `null` | API 回调 Token（与 `CallbackEncodingAesKey` 同时配置时注册 `CallbackService`） |
| `CallbackEncodingAesKey` | `string?` | `null` | API 回调 AES Key（43 位字符） |
| `BotId` | `string?` | `null` | 长连接机器人 ID（与 `BotSecret` 同时配置时注册 `ISmartRobotWsClient`） |
| `BotSecret` | `string?` | `null` | 长连接专用密钥 |
| `BotWsUrl` | `string` | `wss://openws.work.weixin.qq.com` | 长连接 WebSocket 地址 |

### TencentRetryOptions（重试配置）

位于命名空间 `GaoXinLibrary.TencentSDK.Core`。

| 字段 | 类型 | 默认值 | 说明 |
|---|---|---|---|
| `MaxRetries` | `int` | `2` | 最大重试次数（不含首次请求）；设为 `0` 禁用重试 |
| `InitialDelay` | `TimeSpan` | 500ms | 首次重试前等待时间；后续按指数退避翻倍 |
| `MaxDelay` | `TimeSpan` | 5s | 单次重试等待时间上限 |

---

## Token 管理

### WecomClient

`WecomClient` 支持 `access_token` 以及企业级/应用级 `jsapi_ticket` 的完整生命周期管理：

```csharp
// ─── access_token ────────────────────────────────────────────────────────
// 获取当前有效 token（命中缓存直接返回，否则自动向企业微信刷新）
string token = await client.GetAccessTokenAsync();

// 强制刷新（立即向企业微信请求新 token 并更新缓存）
string newToken = await client.RefreshAccessTokenAsync();

// 手动写入（从外部令牌服务获取 token 后写入缓存）
client.SetAccessToken("token_value", expiresIn: TimeSpan.FromSeconds(7200));

// 使缓存失效（下次 GetAccessTokenAsync 时触发重新获取）
client.InvalidateAccessTokenCache();

// ─── 企业级 jsapi_ticket（wx.config 所需）────────────────────────────────
string ticket = await client.GetJsApiTicketAsync();
await client.RefreshJsApiTicketAsync();
client.SetJsApiTicket("ticket_value");
client.InvalidateJsApiTicketCache();

// ─── 应用级 jsapi_ticket（wx.agentConfig 所需）───────────────────────────
string agentTicket = await client.GetAgentTicketAsync();
await client.RefreshAgentTicketAsync();
client.SetAgentTicket("ticket_value");
client.InvalidateAgentTicketCache();
```

### WechatOfficialClient

`WechatOfficialClient` 支持 `access_token` 以及公众号 `jsapi_ticket` 的管理：

```csharp
// ─── access_token ────────────────────────────────────────────────────────
string token = await client.GetAccessTokenAsync();
await client.RefreshAccessTokenAsync();
client.SetAccessToken("token_value");
client.InvalidateAccessTokenCache();

// ─── jsapi_ticket（wx.config 所需，也可通过 client.JsSdk 访问）────────────
string ticket = await client.GetTicketAsync();
await client.RefreshTicketAsync();
client.SetTicket("ticket_value");
client.InvalidateTicketCache();
```

### WechatMiniProgramClient

`WechatMiniProgramClient` 支持 `access_token` 管理：

```csharp
string token = await client.GetAccessTokenAsync();
await client.RefreshAccessTokenAsync();
client.SetAccessToken("token_value");
client.InvalidateAccessTokenCache();
```

> 所有 Token / Ticket 缓存均在内部**提前 60 秒**判定过期，以预留安全余量。

---

## 备服务器模式（共享密钥）

适用于多台服务器中只需一个主节点对接腾讯 API、其余备节点共享 token 的场景。`WecomClient` 和 `WechatOfficialClient` 均支持此模式。

**主服务器**：正常配置凭证，额外配置 `ShareSecret`，通过受保护的内部接口将载荷暴露给备服务器：

```csharp
// WecomClient 主服务器
builder.Services.AddWecomService(options =>
{
    options.CorpId      = "your_corpid";
    options.CorpSecret  = "your_corpsecret";
    options.AgentId     = 1000001;
    options.ShareSecret = "shared_secret_32chars_or_more";  // 与备服务器约定的同一密钥
    options.OnTokenChanged = async (token, ct) =>
    {
        // 可选：将 token 推送至 Redis 等共享存储
    };
});

// 内部接口（Controller 示例）：
app.MapGet("/internal/shared-secret", async (WecomClient client) =>
    Results.Ok(await client.GetSharedSecretAsync()))
   .RequireAuthorization("InternalOnly");
```

**备服务器**：只需配置 `SecretShareUrl` + `ShareSecret`，无需 `CorpSecret`：

```csharp
builder.Services.AddWecomService(options =>
{
    options.ShareSecret    = "shared_secret_32chars_or_more"; // 与主服务器相同
    options.SecretShareUrl = "https://primary-server/internal/shared-secret";
    // CorpId / CorpSecret 可省略
});
```

**载荷加密**：ChaCha20-Poly1305，密钥由 `ShareSecret` 经 SHA-256 派生为 32 字节。载荷包含 `access_token`、`jsapi_ticket`（企业级与应用级）、`CorpId`、`CorpSecret`、`AgentId` 等全部敏感信息，备服务器无需任何凭证即可正常运行。

> 注意：配置 `SecretShareUrl` 时必须同时配置 `ShareSecret`；若未配置 `ShareSecret` 在创建客户端时将抛出 `ArgumentException`。

---

## 消息回调与加解密

### 微信公众号

`AddWechatOfficialService` 中，当 `CallbackToken` + `CallbackEncodingAesKey` **同时配置**时，`OfficialCallbackService` 会被自动注册到 DI 容器，无需手动注册；也可直接通过 `client.Callback` 属性访问（始终可用）。

`OfficialCallbackService` 提供：
- 签名校验（`ValidateSignature`）
- AES-256-CBC 消息解密（`DecryptMessage`）
- 加密回复报文生成（`BuildEncryptedReply`）

### 企业微信

企业微信应用回调（URL 验证、消息解密、事件解析、加密回复）由 `CallbackService` 处理。当 `AddWecomService` 中的 `CallbackToken` 与 `CallbackEncodingAesKey` **同时配置**时，`CallbackService` 会被自动注册到 DI 容器。

`CallbackService` 提供：
- URL 验证（`VerifyUrl`）
- 消息解密与事件解析（`DecryptAndParse`）
- 加密被动回复（`EncryptReply`）

**Switch 类型顺序注意事项**：

回调事件类存在继承关系，在 `switch` 表达式中**子类必须放在父类之前**，否则会错误匹配到父类：

```csharp
// 正确：子类在前
var result = message switch
{
    CallbackUpdateUserEvent update   => HandleUpdate(update),   // 先匹配子类
    CallbackCreateUserEvent create   => HandleCreate(create),   // 再匹配父类
    CallbackUpdatePartyEvent updPty  => HandleUpdateParty(updPty),
    CallbackCreatePartyEvent crtPty  => HandleCreateParty(crtPty),
    _ => null
};
```

> `CallbackUpdateUserEvent` 继承 `CallbackCreateUserEvent`；`CallbackUpdatePartyEvent` 继承 `CallbackCreatePartyEvent`。

---

## 会话内容存档（Finance）

`Core/Finance/FinanceSdk.cs` 通过 P/Invoke 封装企业微信 Finance C SDK，支持拉取加密聊天记录、解密消息、获取媒体数据等功能。

**使用前提**：

1. 在企业微信管理后台「管理工具 - 会话内容存档」获取 `MsgAuditSecret` 和 RSA 密钥对：

```csharp
builder.Services.AddWecomService(options =>
{
    options.CorpId              = "your_corpid";
    options.CorpSecret          = "your_corpsecret";
    options.MsgAuditSecret      = "msg_audit_secret";         // 存档专用密钥
    options.MsgAuditPrivateKey  = "-----BEGIN RSA PRIVATE KEY-----\n..."; // PEM 格式私钥
});
```

2. 在输出目录中提供 Finance C SDK 原生库：

| 平台 | 文件名 |
|---|---|
| Windows | `WeWorkFinanceSdk_C.dll` |
| Linux | `libWeWorkFinanceSdk_C.so` |

> 这些原生库**不包含在本 NuGet 包中**，请从企业微信官方渠道获取并自行部署至应用输出目录。

---

## 瞬态故障重试

SDK 对以下错误内置指数退避重试：

- `HttpRequestException`（连接失败、DNS 解析失败等网络错误）
- 请求超时（`TaskCanceledException`）
- HTTP 5xx 服务端错误

Token 失效（腾讯返回 token 过期错误码）由独立的内层机制处理，**不受** `RetryOptions` 控制。

**自定义重试策略**：

```csharp
builder.Services.AddWecomService(options =>
{
    options.CorpId     = "...";
    options.CorpSecret = "...";
    options.RetryOptions = new TencentRetryOptions
    {
        MaxRetries   = 3,                              // 最多重试 3 次
        InitialDelay = TimeSpan.FromMilliseconds(300), // 首次重试等待 300ms
        MaxDelay     = TimeSpan.FromSeconds(10)        // 单次等待上限 10s
    };
});
```

**禁用重试**：

```csharp
options.RetryOptions = null;
// 或
options.RetryOptions = new TencentRetryOptions { MaxRetries = 0 };
```

---
