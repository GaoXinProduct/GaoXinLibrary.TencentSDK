# GaoXinLibrary.TencentSDK

腾讯平台统一 .NET 服务端 SDK，整合 **企业微信（Wecom）** 与 **微信（小程序、公众号、开放平台、QQ 互联）** 核心接口。

一个包覆盖腾讯主流开放平台，开箱即用、接口对齐官方文档、支持依赖注入与多实例。

[![NuGet](https://img.shields.io/nuget/v/GaoXinLibrary.TencentSDK.svg)](https://www.nuget.org/packages/GaoXinLibrary.TencentSDK)

---

## ✨ 特性

- 🎯 **统一包** — 微信小程序、公众号、开放平台、QQ 互联、企业微信，一个 NuGet 包全部搞定
- 🔌 **依赖注入友好** — 提供 `AddWechatMiniProgram` / `AddWechatOfficial` / `AddWechatOpen` / `AddQQConnect` / `AddWecom` 扩展方法，开箱即注入
- 🔑 **Keyed Services 多实例** — 同一平台注册多套凭证（如多个企业微信应用），通过 `[FromKeyedServices("name")]` 注入
- 🔄 **access_token 自动管理** — 内置缓存与自动刷新，无需手动维护 Token 生命周期
- 🛡️ **消息回调加解密** — 企业微信与公众号回调消息的签名校验、AES 加解密一站式支持
- 📦 **会话内容存档** — 企业微信会话存档原生 SDK 封装（含 RSA 解密）
- 🔄 **瞬态故障自动重试** — 网络抖动、连接超时、服务端 5xx 等临时性故障自动按指数退避重试，可通过 `RetryOptions` 配置
- 🎯 **多目标框架** — 同时支持 **.NET 8 / .NET 9 / .NET 10**，各版本自动匹配对应的 `Microsoft.Extensions.*` 包
- 📖 **XML 文档注释** — 所有公开 API 均附带完整 XML 文档，IDE 智能提示开箱即用

---

## 📦 安装

### NuGet 包管理器

```bash
dotnet add package GaoXinLibrary.TencentSDK
```

### Package Manager Console

```powershell
Install-Package GaoXinLibrary.TencentSDK
```

### 要求

| 依赖 | 版本 |
|------|------|
| .NET | 8.0 / 9.0 / 10.0 |
| `Microsoft.Extensions.DependencyInjection.Abstractions` | 对应 TFM 版本 |
| `Microsoft.Extensions.Http` | 对应 TFM 版本 |
| `Microsoft.Extensions.Options` | 对应 TFM 版本 |

---

## 🗂️ 功能概览

### 微信（Wechat）

#### 小程序 — `WechatMiniProgramClient`

| 模块 | 属性 | 服务接口 | 核心功能 |
|------|------|---------|---------|
| 登录与手机号 | `Auth` | `IMiniProgramAuthService` | `Code2SessionAsync` 登录凭证校验 / `GetPhoneNumberAsync` 获取手机号 / `CheckSessionKeyAsync` 校验 session_key / `ResetUserSessionKeyAsync` 重置 session_key |
| 小程序码 | `QrCode` | `IMiniProgramQrCodeService` | `GetUnlimitedAsync` 不限制小程序码 / `GetQrCodeAsync` 有限小程序码 / `CreateQrCodeAsync` 小程序二维码 |
| 订阅消息 | `SubscribeMessage` | `IMiniProgramSubscribeMessageService` | `SendAsync` 发送订阅消息 |
| 内容安全 | `Security` | `IMiniProgramSecurityService` | `MsgSecCheckAsync` 文本内容安全检测 / `MediaCheckAsync` 音视频内容安全异步检测 / `GetUserRiskRankAsync` 获取用户安全等级 |
| 发货信息 | `Shipping` | `IMiniProgramShippingService` | `UploadShippingInfoAsync` 发货信息录入 / `UploadCombinedShippingInfoAsync` 合单发货录入 / `GetOrderAsync` 查询订单发货状态 / `IsTradeManagedAsync` 查询交易结算确认 |
| OCR | `Ocr` | `IMiniProgramOcrService` | `IdCardAsync` 身份证 / `BankCardAsync` 银行卡 / `DrivingAsync` 行驶证 / `DrivingLicenseAsync` 驾驶证 / `BizLicenseAsync` 营业执照 / `CommAsync` 通用印刷体 / `AiCropAsync` 图片智能裁切 |
| 链接生成 | `Link` | `IMiniProgramLinkService` | `GenerateSchemeAsync` 生成 URL Scheme / `GenerateUrlLinkAsync` 生成 URL Link / `GenerateShortLinkAsync` 生成 Short Link |
| 数据分析 | `DataAnalysis` | `IMiniProgramDataAnalysisService` | `GetDailySummaryTrendAsync` 概况趋势 / `GetDailyVisitTrendAsync` 访问趋势 / `GetVisitPageAsync` 访问页面 / `GetUserPortraitAsync` 用户画像 / `GetVisitDistributionAsync` 访问分布 |
| 物流助手 | `Express` | `IMiniProgramExpressService` | `GetAllDeliveryAsync` 获取快递公司列表 / `GetOrderAsync` 查询运单 / `GetPathAsync` 获取运单轨迹 |
| 运维中心 | `Operation` | `IMiniProgramOperationService` | `GetDomainInfoAsync` 域名配置 / `GetPerformanceAsync` 性能数据 / `GetSceneListAsync` 访问来源 / `GetVersionListAsync` 客户端版本 / `RealtimeLogSearchAsync` 实时日志 / `GetFeedbackListAsync` 用户反馈 / `GetFeedbackMediaAsync` 反馈图片 / `JsErrSearchAsync` JS 错误列表 / `GetJsErrDetailAsync` JS 错误详情 / `GetGrayReleasePlanAsync` 分阶段发布详情 |
| 硬件设备 | `Device` | `IMiniProgramDeviceService` | `SendMessageAsync` 发送设备消息 |
| 客服消息 | `CustomMessage` | `IMiniProgramCustomMessageService` | `SendAsync` 发送客服消息 / `SetTypingAsync` 下发输入状态 |
| OpenAPI | `OpenApi` | `IMiniProgramOpenApiService` | `ClearQuotaAsync` 清除调用次数 / `ClearApiQuotaAsync` 重置指定 API 调用次数 / `ClearQuotaByAppSecretAsync` 使用 AppSecret 重置 / `GetQuotaAsync` 查询调用额度 / `GetRidInfoAsync` 查询 rid 信息 / `CallbackCheckAsync` 网络通信检测 / `GetApiDomainIpAsync` API 服务器 IP / `GetCallbackIpAsync` 推送服务器 IP |

#### 公众号 — `WechatOfficialClient`

| 模块 | 属性 | 服务接口 | 核心功能 |
|------|------|---------|---------|
| OAuth 网页授权 | `OAuth` | `IOfficialOAuthService` | `BuildAuthUrl` 构造授权 URL / `GetAccessTokenAsync` code 换取 access_token / `RefreshTokenAsync` 刷新 token / `GetUserInfoAsync` 拉取用户信息 |
| 自定义菜单 | `Menu` | `IOfficialMenuService` | `CreateAsync` 创建菜单 / `GetAsync` 查询菜单 / `DeleteAsync` 删除菜单 |
| 模板消息 | `TemplateMessage` | `IOfficialTemplateMessageService` | `SendAsync` 发送模板消息 |
| 用户管理 | `User` | `IOfficialUserService` | `GetInfoAsync` 获取用户信息 / `BatchGetInfoAsync` 批量获取 / `GetListAsync` 用户列表 / `GetAllOpenIdsAsync` 全部 OpenId（自动分页） / `UpdateRemarkAsync` 设置备注名 / `BatchBlacklistAsync` 拉黑用户 / `BatchUnblacklistAsync` 取消拉黑 / `GetBlacklistAsync` 黑名单列表 / `ChangeOpenIdAsync` 迁移后转换 OpenId |
| 服务号二维码 | `QrCode` | `IOfficialQrCodeService` | 带参二维码：`CreateTemporaryAsync`/`CreatePermanentAsync`/`BuildShowUrl` / 扫码打开小程序：`AddOrUpdateJumpRuleAsync`/`GetJumpRulesAsync`/`PublishJumpRuleAsync`/`DeleteJumpRuleAsync` / 长短链：`GenerateShortLinkAsync`/`FetchShortLinkAsync` |
| 素材管理 | `Material` | `IOfficialMaterialService` | `GetCountAsync` 素材总数 / `GetMaterialAsync` 获取永久素材 / `DeleteMaterialAsync` 删除永久素材 / `BatchGetAsync` 素材列表 / `UploadTempMaterialAsync` 上传临时素材（Stream / ReadOnlyMemory） / `DownloadTempMaterialBytesAsync` 下载临时素材 byte[] / `DownloadTempMaterialReadOnlyAsync` 下载 ReadOnlyMemory / `AddPermanentMaterialAsync` 新增永久素材（Stream / ReadOnlyMemory） |
| JS-SDK | `JsSdk` | `IOfficialJsSdkService` | `GetTicketAsync` 获取 jsapi_ticket（自动缓存） / `CreateSignature` 计算签名 / `InvalidateTicketCache` 使缓存失效 / `RefreshTicketAsync` 强制刷新 / `SetTicket` 手动设置 / `GetSharedTicketAsync` 获取共享加密 Ticket |
| 用户标签 | `Tag` | `IOfficialTagService` | `CreateAsync` 创建标签 / `GetAllAsync` 获取全部标签 / `UpdateAsync` 编辑标签 / `DeleteAsync` 删除标签 / `GetUsersAsync` 标签下粉丝列表 / `BatchTagAsync` 批量打标签 / `BatchUntagAsync` 批量取消 / `GetUserTagsAsync` 获取用户标签 |
| 草稿箱 | `Draft` | `IOfficialDraftService` | `AddAsync` 新建草稿 / `GetAsync` 获取草稿 / `DeleteAsync` 删除草稿 / `BatchGetAsync` 草稿列表 / `GetCountAsync` 草稿总数 |
| 发布能力 | `Publish` | `IOfficialPublishService` | `SubmitAsync` 发布草稿 / `GetAsync` 查询发布状态 / `DeleteAsync` 删除发布 / `GetArticleAsync` 获取已发布文章 / `BatchGetAsync` 成功发布列表 |
| 留言管理 | `Comment` | `IOfficialCommentService` | `OpenAsync` 打开评论 / `CloseAsync` 关闭评论 / `ListAsync` 查看评论 / `ReplyAsync` 回复评论 / `DeleteAsync` 删除评论 / `DeleteReplyAsync` 删除回复 / `MarkElectAsync` 精选 / `UnmarkElectAsync` 取消精选 |
| 客服消息 | `CustomMessage` | `IOfficialCustomMessageService` | `SendAsync` 发送客服消息 / `SetTypingAsync` 下发输入状态 / `AddKfAccountAsync` 添加客服帐号 / `UpdateKfAccountAsync` 修改客服帐号 / `DeleteKfAccountAsync` 删除客服帐号 / `GetKfListAsync` 获取所有客服 |
| 群发消息 | `Message` | `IOfficialMessageService` | `MassSendAllAsync` 按标签群发 / `MassSendAsync` 按 OpenId 群发 / `MassDeleteAsync` 删除群发 / `MassPreviewAsync` 预览 / `MassGetAsync` 查询发送状态 / `SetIndustryAsync` 设置行业 / `GetIndustryAsync` 获取行业 / `AddTemplateAsync` 获得模板 ID / `GetTemplateListAsync` 模板列表 / `DeleteTemplateAsync` 删除模板 |
| 数据统计 | `DataAnalysis` | `IOfficialDataAnalysisService` | `GetUserSummaryAsync` 用户增减 / `GetUserCumulateAsync` 累计用户 / `GetArticleSummaryAsync` 图文群发每日 / `GetArticleTotalAsync` 图文群发总数据 / `GetUserReadAsync` 图文统计 / `GetUserShareAsync` 分享转发 / `GetUpstreamMsgAsync` 消息发送概况 / `GetInterfaceSummaryAsync` 接口分析 |
| 智能接口 | `Ai` | `IOfficialAiService` | `SemanticSearchAsync` 语义理解 / `OcrIdCardAsync` 身份证 OCR / `OcrBankCardAsync` 银行卡 OCR / `OcrDrivingAsync` 行驶证 OCR / `OcrBizLicenseAsync` 营业执照 OCR |
| 门店管理 | `Poi` | `IOfficialPoiService` | `AddAsync` 创建门店 / `GetAsync` 查询门店 / `GetListAsync` 门店列表 / `UpdateAsync` 修改门店 / `DeleteAsync` 删除门店 |
| 微信发票 | `Invoice` | `IOfficialInvoiceService` | 商户开票：`SetAuthFieldAsync`/`GetAuthFieldAsync`/`SetPayMchAsync`/`GetPayMchAsync`/`SetContactAsync`/`GetContactAsync` / 开票平台：`GetPlatformInvoiceUrlAsync`/`GetPlatformPdfAsync`/`UpdatePlatformInvoiceStatusAsync`/`UploadPlatformPdfAsync`/`CreatePlatformCardAsync`/`InsertInvoiceAsync` / 发票报销&自助打印：`GetReimburseInvoiceAsync`/`UpdateReimburseInvoiceStatusAsync`/`BatchUpdateReimburseInvoiceStatusAsync`/`BatchGetReimburseInvoiceAsync` / 极速开发票：`GetUserTitleUrlAsync`/`GetSelectTitleUrlAsync`/`ScanTitleAsync` / 非税票据：`GetNonTaxAuthUrlAsync`/`CreateNonTaxCardAsync`/`InsertNonTaxInvoiceAsync` |
| OpenAPI | `OpenApi` | `IOfficialOpenApiService` | `ClearQuotaAsync` 清空调用 quota / `GetQuotaAsync` 查询调用额度 / `GetRidInfoAsync` 查询 rid 信息 |
| 消息回调 | `Callback` | `IOfficialCallbackService` | `VerifyUrl` 明文模式验证 / `VerifyUrlEncrypted` 安全模式验证 / `ParseMessage` 解析明文消息 / `DecryptAndParse` 解密并解析消息 / `EncryptReply` 加密被动回复 / `GetCallbackIpAsync` 获取微信服务器 IP |

#### 开放平台 — `WechatOpenClient`

| 模块 | 属性 | 服务接口 | 核心功能 |
|------|------|---------|---------|
| 网站登录 | `WebLogin` | `IOpenPlatformService` | `BuildAuthUrl` 构造扫码登录 URL / `GetAccessTokenAsync` code 换取 access_token / `RefreshTokenAsync` 刷新 token / `GetUserInfoAsync` 获取用户信息 / `CheckAccessTokenAsync` 检验凭证有效性 / `GetPcOpenSdkTicketAsync` 获取 PC OpenSDK ticket |

#### QQ 互联 — `QQConnectClient`

| 模块 | 属性 | 服务接口 | 核心功能 |
|------|------|---------|---------|
| QQ 登录 | `Login` | `IQQConnectService` | `BuildAuthUrl` 构造授权页面 URL / `GetAccessTokenAsync` code 换取 access_token / `RefreshTokenAsync` 刷新 token / `GetOpenIdAsync` 获取用户 OpenID / `GetUserInfoAsync` 获取用户信息 |

---

### 企业微信（Wecom） — `WecomClient`

| 模块 | 属性 | 服务接口 | 核心功能 |
|------|------|---------|---------|
| 成员管理 | `User` | `IUserService` | 创建 / 读取 / 更新 / 删除 / 批量删除 / userId⇄openId 转换 / 手机号/邮箱查 userId / 邀请成员 / 分页列表 |
| 部门管理 | `Department` | `IDepartmentService` | 创建 / 更新 / 列表 / 详情 / 删除 |
| 标签管理 | `Tag` | `ITagService` | 创建 / 删除 / 添加删除成员 / 列表 |
| 应用消息 | `Message` | `IMessageService` | 文本 / Markdown / 图文 / 文本卡片 / 小程序通知 / 模版卡片 / 更新模版卡片 / 撤回 |
| 群机器人 | `Webhook` | `IWebhookService` | 文本 / Markdown / 图文 / 图片 / 文件 Webhook 推送 |
| 应用管理 | `Agent` | `IAgentService` | 获取应用信息 / 应用列表 / 设置应用 / 设置工作台模板 / 自定义菜单管理 |
| 自定义菜单 | `Menu` | `IMenuService` | 创建 / 获取 / 删除应用菜单（AgentId 自动取自 `WecomOptions`，无需手动传入） |
| 素材管理 | `Media` | `IMediaService` | 上传临时素材 / 上传图片 / 获取素材 |
| 群聊会话 | `GroupChat` | `IGroupChatService` | 创建群聊 / 修改 / 获取 / 发送群聊消息 |
| OAuth | `OAuth` | `IOAuthService` | 构造授权 URL / code 换取用户身份 / user_ticket 换取敏感信息 |
| JS-SDK | `JsSdk` | `IJsSdkService` | 企业级/应用级 jsapi_ticket 自动缓存与共享、H5 JS-SDK 签名 |
| 消息回调 | `Callback` | `ICallbackService` | URL 验证 / 消息解析与解密 / 被动回复加密 / 回调 IP 段 |
| 智能机器人 | `SmartRobot` | `ISmartRobotService` | 智能机器人管理 |
| 微信客服 | `Kf` | `IKfService` | 微信客服管理 |
| 打卡 | `Checkin` | `ICheckinService` | 打卡规则 / 打卡数据查询 |
| 审批 | `Approval` | `IApprovalService` | 审批流程管理 |
| 会话存档 | `MsgAudit` | `IMsgAuditService` | 会话内容存档（含 RSA 解密） |
| 企业互联 | `CorpGroup` | `ICorpGroupService` | 上下游企业管理 |
| 互联企业 | `LinkedCorp` | `ILinkedCorpService` | 互联企业通讯录 |
| 异步导出 | `Export` | `IExportService` | 异步数据导出任务 |
| 异步导入 | `AsyncImport` | `IAsyncImportService` | 增量更新成员 / 全量覆盖成员 / 全量覆盖部门 / 获取异步任务结果 |
| 二次验证 | `SecondVerify` | `ISecondVerifyService` | 获取二次验证信息 / 登录二次验证确认 |
| 安全管理 | `Security` | `ISecurityService` | 文件防泄漏规则 / 设备管理 |
| 高级功能账号 | `AdvancedAccount` | `IAdvancedAccountService` | 分配 / 取消 / 列表查询高级功能账号 |
| 操作日志 | `OperationLog` | `IOperationLogService` | 成员操作记录 / 管理端操作日志 |
| 账号 ID 管理 | `AccountId` | `IAccountIdService` | tmp_external_userid 转换 |
| IP 段查询 | `IpRange` | `IIpRangeService` | 获取接口 IP 段 / 获取回调 IP 段 |
| 客户联系 | `ExternalContact` | `IExternalContactService` | 成员配置列表 / 客户列表 / 详情 / 批量获取 / 修改备注 / 客户群列表 / 联系统计 / 新客户欢迎语 |
| 企业支付 | `CorpPay` | `ICorpPayService` | 对外收款账单列表 / 收款项目账单列表 |
| 邮件 | `Email` | `IEmailService` | 发送邮件 / 获取未读数 |
| 文档 | `Document` | `IDocumentService` | 新建 / 获取基础信息 / 重命名 / 删除 / 分享文档 |
| 日程 | `Calendar` | `ICalendarService` | 日历增删改查 / 日程增删改查 / 按日历获取日程 |
| 会议 | `Meeting` | `IMeetingService` | 创建 / 修改 / 取消 / 详情 / 成员会议列表 |
| 微盘 | `Wedrive` | `IWedriveService` | 空间创建 / 重命名 / 解散 / 详情 / 文件列表 / 创建文件 / 重命名 / 删除 / 移动 |
| 直播 | `Living` | `ILivingService` | 创建 / 修改 / 取消直播 / 删除回放 / 详情 / 成员直播列表 |
| 公费电话 | `Dial` | `IDialService` | 获取公费电话拨打记录 |
| 汇报 | `Report` | `IReportService` | 批量获取汇报记录单号 / 汇报详情 |
| 人事助手 | `Hr` | `IHrService` | 员工字段配置 / 花名册信息查询与更新 |
| 会议室 | `MeetingRoom` | `IMeetingRoomService` | 添加 / 列表 / 编辑 / 删除会议室 / 查询预定信息 / 预定 / 取消预定 |
| 电子发票 | `Invoice` | `IInvoiceService` | 查询 / 批量查询 / 更新 / 批量更新发票状态 |
| 智能表格 | `SmartSheet` | `ISmartSheetService` | 子表增删改查 / 字段增删改查 / 记录增删改查 / 视图列表 |
| 收集表 | `CollectForm` | `ICollectFormService` | 创建 / 修改 / 获取收集表 / 获取答案 |

---

## 🚀 快速开始

### 微信小程序

```csharp
using GaoXinLibrary.TencentSDK.Wechat;
using GaoXinLibrary.TencentSDK.Wechat.Core;

// 创建客户端
var client = WechatMiniProgramClient.Create(new WechatMiniProgramOptions
{
    AppId     = "your_appid",
    AppSecret = "your_appsecret"
});

// 小程序登录：通过 js_code 换取 session 信息
var session = await client.Auth.Code2SessionAsync("js_code_from_wx_login");
Console.WriteLine($"OpenId: {session.OpenId}, SessionKey: {session.SessionKey}");

// 获取手机号
var phone = await client.Auth.GetPhoneNumberAsync("phone_code_from_button");
Console.WriteLine($"手机号: {phone.PhoneNumber}");

// 生成小程序码
var qrCodeBytes = await client.QrCode.GetUnlimitedQrCodeAsync("scene_value", "pages/index/index");

// 发送订阅消息
await client.SubscribeMessage.SendAsync(new { /* ... */ });

// 内容安全检测
var result = await client.Security.MsgSecCheckAsync("待检测的文本内容");
```

### 微信公众号

```csharp
using GaoXinLibrary.TencentSDK.Wechat;
using GaoXinLibrary.TencentSDK.Wechat.Core;
using GaoXinLibrary.TencentSDK.Wechat.Models.OfficialAccount;

var client = WechatOfficialClient.Create(new WechatOfficialOptions
{
    AppId                 = "your_appid",
    AppSecret             = "your_appsecret",
    CallbackToken         = "your_callback_token",         // 消息回调用
    CallbackEncodingAesKey = "your_43char_encoding_aes_key" // 消息回调用
});

// OAuth 网页授权
var authUrl = client.OAuth.BuildAuthUrl(redirectUri: "https://example.com/callback");
// 用户同意后，通过 code 换取用户信息
// var userInfo = await client.OAuth.GetUserInfoAsync("code_from_callback");

// 发送模板消息
await client.TemplateMessage.SendAsync(new
{
    touser      = "OPENID",
    template_id = "TEMPLATE_ID",
    url         = "https://example.com",
    data        = new { /* 模板数据 */ }
});

// JS-SDK 签名
var jsConfig = await client.JsSdk.GetConfigAsync("https://example.com/page");

// 拉黑用户 / 取消拉黑
await client.User.BatchBlacklistAsync(new BatchBlacklistRequest
{
    OpenIdList = new() { "OPENID_1", "OPENID_2" }
});
await client.User.BatchUnblacklistAsync(new BatchBlacklistRequest
{
    OpenIdList = new() { "OPENID_1" }
});

// 迁移场景：转换 OpenId
var changed = await client.User.ChangeOpenIdAsync(new ChangeOpenIdRequest
{
    FromAppId = "gh_91ae50dfeb1c",
    OpenIdList = new() { "OLD_OPENID" }
});

// 服务号二维码（永久字符串场景值）
var qr = await client.QrCode.CreatePermanentAsync("scene:campaign-2026");
var qrImageUrl = client.QrCode.BuildShowUrl(qr.Ticket!);

// 扫码打开小程序规则（服务号二维码）
await client.QrCode.AddOrUpdateJumpRuleAsync(new QrcodeJumpAddRequest
{
    Prefix = "http://weixin.qq.com/q/kZgfwMTm72Wxxxx",
    AppId = "wxxxxxx",
    Path = "pages/index/index",
    IsEdit = 0
});

// 长信息与短链
var shortResp = await client.QrCode.GenerateShortLinkAsync(new ShortLinkGenerateRequest
{
    LongData = "https://example.com/very/long/path",
    ExpireSeconds = 86400
});
var longResp = await client.QrCode.FetchShortLinkAsync(new ShortLinkFetchRequest
{
    ShortKey = shortResp.ShortKey!
});

// 微信发票（商户开票）—— 设置并查询联系方式
await client.Invoice.SetContactAsync(new InvoiceSetContactRequest
{
    Contact = new InvoiceContactInfo
    {
        Phone = "88888888",
        TimeOut = 12345
    }
});
var contact = await client.Invoice.GetContactAsync();

// 开票平台：获取识别码链接 / 创建卡券模板
var invoiceUrl = await client.Invoice.GetPlatformInvoiceUrlAsync();
var card = await client.Invoice.CreatePlatformCardAsync(new InvoicePlatformCreateCardRequest
{
    InvoiceInfo = new InvoicePlatformCardInfo
    {
        BaseInfo = new InvoicePlatformCardBaseInfo
        {
            Payee = "某某科技有限公司",
            LogoUrl = "https://example.com/logo.png"
        }
    }
});

// 极速开发票：获取商户专属抬头链接
var titleUrl = await client.Invoice.GetSelectTitleUrlAsync(new InvoiceGetSelectTitleUrlRequest
{
    BizName = "某某科技"
});

// 上传临时素材（ReadOnlyMemory 版本）
ReadOnlyMemory<byte> imageBytes = await File.ReadAllBytesAsync("demo.jpg");
var tempUpload = await client.Material.UploadTempMaterialAsync(imageBytes, "demo.jpg", "image");

// 下载临时素材（byte[] / ReadOnlyMemory 两种形式）
var tempBytes = await client.Material.DownloadTempMaterialBytesAsync(tempUpload.MediaId);
var tempReadOnly = await client.Material.DownloadTempMaterialReadOnlyAsync(tempUpload.MediaId);

// 新增永久素材（ReadOnlyMemory 版本）
var permanent = await client.Material.AddPermanentMaterialAsync(imageBytes, "demo.jpg", "image");
```

### 微信开放平台（网站扫码登录）

```csharp
using GaoXinLibrary.TencentSDK.Wechat;
using GaoXinLibrary.TencentSDK.Wechat.Core;

var client = WechatOpenClient.Create(new WechatOpenOptions
{
    AppId     = "your_open_appid",
    AppSecret = "your_open_appsecret"
});

// 构造扫码登录 URL
var loginUrl = client.WebLogin.BuildAuthUrl("https://example.com/callback", state: "random_state");

// 用户扫码后，通过 code 换取 access_token 和用户信息
// var tokenInfo = await client.WebLogin.GetAccessTokenAsync("code_from_callback");
// var userInfo  = await client.WebLogin.GetUserInfoAsync(tokenInfo.AccessToken, tokenInfo.OpenId);
```

### QQ 互联（网站 QQ 登录）

```csharp
using GaoXinLibrary.TencentSDK.Wechat;
using GaoXinLibrary.TencentSDK.Wechat.Core;

var client = QQConnectClient.Create(new QQConnectOptions
{
    AppId     = "your_qq_appid",
    AppSecret = "your_qq_appkey"
});

// 构造 QQ 登录 URL
var loginUrl = client.Login.BuildAuthUrl("https://example.com/callback", state: "random_state");

// 用户授权后，通过 code 换取 access_token → openid → 用户信息
// var token    = await client.Login.GetAccessTokenAsync("code_from_callback");
// var openId   = await client.Login.GetOpenIdAsync(token.AccessToken);
// var userInfo = await client.Login.GetUserInfoAsync(token.AccessToken, openId);
```

### 企业微信

```csharp
using GaoXinLibrary.TencentSDK.Wecom;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.User;
using GaoXinLibrary.TencentSDK.Wecom.Models.Message;
using GaoXinLibrary.TencentSDK.Wecom.Models.Meeting;
using GaoXinLibrary.TencentSDK.Wecom.Models.Document;
using GaoXinLibrary.TencentSDK.Wecom.Models.Calendar;
using GaoXinLibrary.TencentSDK.Wecom.Models.Invoice;

var client = WecomClient.Create(new WecomOptions
{
    CorpId     = "your_corpid",
    CorpSecret = "your_corpsecret",
    AgentId    = 1000001
});

// 发送文本消息（@all 发送给所有人）— 便捷方法
var resp = await client.Message.SendTextAsync("Hello, 企业微信!", toUser: "@all");
Console.WriteLine($"MsgId: {resp.MsgId}");

// 发送 Markdown 消息
await client.Message.SendMarkdownAsync("## 通知\n> 这是一条 **Markdown** 消息", toUser: "@all");

// 撤回消息 — 使用 Request Model
await client.Message.RecallMessageAsync(new RecallMessageRequest { MsgId = resp.MsgId });

// 获取成员信息
var user = await client.User.GetUserAsync("zhangsan");
Console.WriteLine($"姓名: {user.Name}, 手机: {user.Mobile}");

// userid 转 openid — 使用 Request Model
var openId = await client.User.ConvertUserIdToOpenIdAsync(new ConvertToOpenIdRequest
{
    UserId = "zhangsan"
});

// 手机号获取 userid
var uid = await client.User.GetUserIdByMobileAsync(new GetUserIdByMobileRequest
{
    Mobile = "13800000000"
});

// 批量删除成员
await client.User.BatchDeleteUsersAsync(new BatchDeleteUserRequest
{
    UserIdList = ["user1", "user2"]
});

// 获取部门列表
var depts = await client.Department.GetDepartmentListAsync();

// Webhook 群机器人
await client.Webhook.SendTextAsync("YOUR_WEBHOOK_KEY", "机器人消息");
await client.Webhook.SendMarkdownAsync("YOUR_WEBHOOK_KEY", "## 告警\n> 服务异常");

// 获取当前应用信息（AgentId 自动取自 WecomOptions，无需手动传入）
var agentInfo = await client.Agent.GetAgentAsync();
Console.WriteLine($"应用名称: {agentInfo.Name}");

// 获取 / 创建 / 删除应用自定义菜单（AgentId 自动注入）
var buttons = await client.Menu.GetMenuAsync();
await client.Menu.DeleteMenuAsync();

// OAuth 网页授权
var oauthUrl = client.OAuth.BuildAuthUrl(
    redirectUri: "https://your-domain.com/callback",
    agentId: 1000001);

// 创建预约会议
var meeting = await client.Meeting.CreateMeetingAsync(new CreateMeetingRequest
{
    Title        = "项目周会",
    AdminUserId  = "zhangsan",
    MeetingStart = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds(),
    MeetingEnd   = DateTimeOffset.UtcNow.AddHours(2).ToUnixTimeSeconds()
});

// 新建文档
var doc = await client.Document.CreateDocAsync(new CreateDocRequest
{
    DocName = "会议纪要",
    DocType = 1 // 1-文档, 3-表格
});

// 创建日历
var calId = await client.Calendar.CreateCalendarAsync(new CreateCalendarRequest
{
    Calendar = new CalendarInfo
    {
        Summary     = "团队日程",
        Description = "技术团队共享日历"
    }
});

// 查询电子发票
var invoice = await client.Invoice.GetInvoiceInfoAsync(new GetInvoiceInfoRequest
{
    CardId       = "CARD_ID",
    EncryptCode  = "ENCRYPT_CODE"
});
```

> 💡 **API 设计说明**：所有 POST 接口的方法均接受**强类型 Request Model** 作为参数，每个 Model 均包含完整的 `[JsonPropertyName]` 和 XML 文档注释。部分高频接口（如消息发送）额外提供便捷方法（`SendTextAsync` / `SendMarkdownAsync` 等）。

---

## 💉 依赖注入

### 基本用法

```csharp
using GaoXinLibrary.TencentSDK.Wechat.Extensions;
using GaoXinLibrary.TencentSDK.Wecom.Extensions;

var builder = WebApplication.CreateBuilder(args);

// 注册微信小程序
builder.Services.AddWechatMiniProgram(options =>
{
    options.AppId     = "mini_appid";
    options.AppSecret = "mini_secret";
});

// 注册微信公众号
builder.Services.AddWechatOfficial(options =>
{
    options.AppId                  = "official_appid";
    options.AppSecret              = "official_secret";
    options.CallbackToken          = "callback_token";
    options.CallbackEncodingAesKey = "encoding_aes_key";
});

// 注册微信开放平台
builder.Services.AddWechatOpen(options =>
{
    options.AppId     = "open_appid";
    options.AppSecret = "open_secret";
});

// 注册 QQ 互联
builder.Services.AddQQConnect(options =>
{
    options.AppId     = "qq_appid";
    options.AppSecret = "qq_appkey";
});

// 注册企业微信
builder.Services.AddWecom(options =>
{
    options.CorpId     = "your_corpid";
    options.CorpSecret = "your_corpsecret";
    options.AgentId    = 1000001;
});
```

注册后可以通过**构造函数注入**门面客户端或子服务接口：

```csharp
// 方式一：注入门面客户端
public class MyController(WecomClient wecom, WechatMiniProgramClient miniProgram)
{
    public async Task SendNotification()
    {
        await wecom.Message.SendTextAsync("通知内容", toUser: "@all");
    }

    public async Task<string> MiniProgramLogin(string code)
    {
        var session = await miniProgram.Auth.Code2SessionAsync(code);
        return session.OpenId;
    }
}

// 方式二：注入子服务接口（推荐，便于单元测试 Mock）
public class NotificationService(IMessageService messageService, IUserService userService)
{
    public async Task NotifyUserAsync(string userId, string content)
    {
        var user = await userService.GetUserAsync(userId);
        if (user != null)
        {
            await messageService.SendTextAsync(content, toUser: userId);
        }
    }

    public async Task<string> GetOpenIdAsync(string userId)
    {
        // POST 接口使用强类型 Request Model
        return await userService.ConvertUserIdToOpenIdAsync(
            new ConvertToOpenIdRequest { UserId = userId });
    }
}
```

### 多实例注册（Keyed Services）

当同一平台需要注册多套凭证时（例如企业微信有多个应用），使用带 `name` 参数的重载：

```csharp
// 注册多个企业微信应用
builder.Services.AddWecom("agent1", opt =>
{
    opt.CorpId = "corp1"; opt.CorpSecret = "secret1"; opt.AgentId = 1000001;
});
builder.Services.AddWecom("agent2", opt =>
{
    opt.CorpId = "corp1"; opt.CorpSecret = "secret2"; opt.AgentId = 1000002;
});

// 注册多个小程序
builder.Services.AddWechatMiniProgram("appA", opt =>
{
    opt.AppId = "appid_a"; opt.AppSecret = "secret_a";
});
builder.Services.AddWechatMiniProgram("appB", opt =>
{
    opt.AppId = "appid_b"; opt.AppSecret = "secret_b";
});
```

通过 `[FromKeyedServices]` 注入指定实例：

```csharp
public class MultiAgentService(
    [FromKeyedServices("agent1")] IMessageService msgAgent1,
    [FromKeyedServices("agent2")] IMessageService msgAgent2)
{
    public async Task NotifyBothAsync(string content)
    {
        await msgAgent1.SendTextAsync(content, toUser: "@all");
        await msgAgent2.SendTextAsync(content, toUser: "@all");
    }
}
```

### 从配置文件绑定（IConfiguration）

所有 DI 扩展方法均支持直接传入 `IConfiguration`（如 `IConfigurationSection`），自动绑定到对应的 Options 类，无需手动编写委托：

```json
// appsettings.json
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
  }
}
```

```csharp
using GaoXinLibrary.TencentSDK.Wechat.Extensions;
using GaoXinLibrary.TencentSDK.Wecom.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// 从配置节绑定（单实例）
builder.Services.AddWechatMiniProgram(config.GetSection("WechatMiniProgram"));
builder.Services.AddWechatOfficial(config.GetSection("WechatOfficial"));
builder.Services.AddWechatOpen(config.GetSection("WechatOpen"));
builder.Services.AddQQConnect(config.GetSection("QQConnect"));
builder.Services.AddWecom(config.GetSection("Wecom"));
```

多实例同样支持 `IConfiguration` 绑定：

```json
// appsettings.json
{
  "WecomAgent1": {
    "CorpId": "corp1",
    "CorpSecret": "secret1",
    "AgentId": 1000001
  },
  "WecomAgent2": {
    "CorpId": "corp1",
    "CorpSecret": "secret2",
    "AgentId": 1000002
  }
}
```

```csharp
// 带 key 的多实例 + IConfiguration
builder.Services.AddWecom("agent1", config.GetSection("WecomAgent1"));
builder.Services.AddWecom("agent2", config.GetSection("WecomAgent2"));

builder.Services.AddWechatMiniProgram("appA", config.GetSection("MiniProgramA"));
builder.Services.AddWechatMiniProgram("appB", config.GetSection("MiniProgramB"));
```

> 💡 所有 Options 类的属性均支持 `IConfiguration` 绑定，包括 `RetryOptions`、`HttpTimeout` 等嵌套/复杂类型。

---

## ⚙️ 配置参数

### 微信配置 — `WechatOptions`（基类）

| 属性 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `AppId` | `string` | `""` | 应用 ID（AppID） |
| `AppSecret` | `string` | `""` | 应用密钥（AppSecret） |
| `BaseUrl` | `string` | `https://api.weixin.qq.com` | API 基础地址 |
| `HttpTimeout` | `TimeSpan` | 30 秒 | HTTP 请求超时时间 |
| `ShareSecret` | `string?` | — | 共享 Token 密钥（ChaCha20-Poly1305，详见[跨服务共享 Token](#-跨服务共享-token)） |
| `TokenShareUrl` | `string?` | — | 远端共享 Token 地址；设置后从此地址拉取加密 Token，而非直接请求微信 API |
| `OnTokenChanged` | `Func<string, CancellationToken, Task>?` | — | Token 刷新成功后的变更通知回调，参数为新的明文 access_token |
| `RetryOptions` | `TencentRetryOptions` | `new()` | 瞬态故障重试配置（网络抖动、超时、5xx），详见[瞬态故障自动重试](#-瞬态故障自动重试) |

| 属性 | 类型 | 说明 |
|------|------|------|
| `CallbackToken` | `string?` | 接收消息回调的 Token（签名校验） |
| `CallbackEncodingAesKey` | `string?` | 接收消息回调的 EncodingAESKey（43 位字符） |
| `TicketShareSecret` | `string?` | jsapi_ticket 共享密钥（ChaCha20-Poly1305） |
| `TicketShareUrl` | `string?` | jsapi_ticket 共享远端地址 |
| `OnTicketChanged` | `Func<string, CancellationToken, Task>?` | jsapi_ticket 刷新成功后的变更通知回调 |

#### `QQConnectOptions`（继承 `WechatOptions`）

| 属性 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `BaseUrl` | `string` | `https://graph.qq.com` | QQ 互联 API 基础地址 |

### 企业微信配置 — `WecomOptions`

| 属性 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `CorpId` | `string` | `""` | 企业 ID（corpid） |
| `CorpSecret` | `string` | `""` | 应用凭证密钥（corpsecret） |
| `AgentId` | `int` | `0` | 自建应用 AgentId；`Agent` / `Menu` / `Message` 等服务均自动从此处读取，无需在调用时重复传入 |
| `BaseUrl` | `string` | `https://qyapi.weixin.qq.com` | API 基础地址 |
| `HttpTimeout` | `TimeSpan` | 30 秒 | HTTP 请求超时时间 |
| `CallbackToken` | `string?` | — | 接收消息回调的 Token |
| `CallbackEncodingAesKey` | `string?` | — | 接收消息回调的 EncodingAESKey（43 位） |
| `MsgAuditSecret` | `string?` | — | 会话内容存档密钥 |
| `MsgAuditPrivateKey` | `string?` | — | 会话内容存档 RSA 私钥（PEM 格式） |
| `ShareSecret` | `string?` | — | 共享 Token 密钥（ChaCha20-Poly1305，详见[跨服务共享 Token](#-跨服务共享-token)） |
| `TokenShareUrl` | `string?` | — | 远端共享 Token 地址；设置后从此地址拉取加密 Token，而非直接请求企业微信 API |
| `OnTokenChanged` | `Func<string, CancellationToken, Task>?` | — | Token 刷新成功后的变更通知回调，参数为新的明文 access_token |
| `JsApiTicketShareSecret` | `string?` | — | 企业级 jsapi_ticket 共享密钥（ChaCha20-Poly1305） |
| `JsApiTicketShareUrl` | `string?` | — | 企业级 jsapi_ticket 共享远端地址 |
| `OnJsApiTicketChanged` | `Func<string, CancellationToken, Task>?` | — | 企业级 jsapi_ticket 刷新成功后的变更通知回调 |
| `AgentTicketShareSecret` | `string?` | — | 应用级 jsapi_ticket 共享密钥（ChaCha20-Poly1305） |
| `AgentTicketShareUrl` | `string?` | — | 应用级 jsapi_ticket 共享远端地址 |
| `OnAgentTicketChanged` | `Func<string, CancellationToken, Task>?` | — | 应用级 jsapi_ticket 刷新成功后的变更通知回调 |
| `RetryOptions` | `TencentRetryOptions` | `new()` | 瞬态故障重试配置（网络抖动、超时、5xx），详见[瞬态故障自动重试](#-瞬态故障自动重试) |

---

## 🔐 消息回调（企业微信示例）

在 ASP.NET Core 中接入企业微信消息回调：

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddWecom(opt =>
{
    opt.CorpId                 = "your_corpid";
    opt.CorpSecret             = "your_corpsecret";
    opt.AgentId                = 1000001;
    opt.CallbackToken          = "your_callback_token";
    opt.CallbackEncodingAesKey = "your_43char_encoding_aes_key";
});

var app = builder.Build();

// GET — 验证回调 URL
app.MapGet("/wecom/callback", (
    string msg_signature, string timestamp, string nonce, string echostr,
    ICallbackService callback) =>
{
    var plain = callback.VerifyUrl(msg_signature, timestamp, nonce, echostr);
    return Results.Content(plain);
});

// POST — 接收消息与事件
app.MapPost("/wecom/callback", async (
    string msg_signature, string timestamp, string nonce,
    HttpRequest request, ICallbackService callback) =>
{
    using var reader = new StreamReader(request.Body);
    var body = await reader.ReadToEndAsync();

    var msg = callback.DecryptAndParse(msg_signature, timestamp, nonce, body);
    switch (msg)
    {
        case CallbackTextMessage text:
            var reply = CallbackReplyBuilder.BuildText(
                text.FromUserName, text.ToUserName, "收到你的消息了！");
            return Results.Content(callback.EncryptReply(reply), "application/xml");

        case CallbackClickEvent click:
            // 处理菜单点击事件
            break;

        case CallbackTemplateCardEvent cardEvent:
            // 处理模版卡片事件
            break;
    }
    return Results.Content("");
});

app.Run();
```

---

## 📂 项目结构

```
GaoXinLibrary.TencentSDK/
├── Core/                                  # 核心基础设施（共享基类 + 平台子类）
│   ├── TencentConstants.cs                #   统一常量定义（HttpClient 名称、OAuth URL）
│   ├── TencentBaseResponse.cs             #   响应基类（ErrCode / ErrMsg）
│   ├── TencentException.cs                #   异常基类
│   ├── TencentAccessTokenProvider.cs      #   access_token 管理基类（缓存 / 刷新 / 手动设置 / 共享 Token）
│   ├── TencentTokenCrypto.cs              #   共享 Token 加解密工具（ChaCha20-Poly1305）
│   ├── TencentHttpClient.cs               #   HTTP 客户端基类（Get / Post / 反序列化 / 瞬态重试）
│   ├── TencentRetryOptions.cs             #   瞬态故障重试配置（指数退避）
│   ├── TencentCryptoHelper.cs             #   消息加解密基类（AES-256-CBC / SHA1 签名）
│   ├── WechatOptions.cs                   #   微信配置基类
│   ├── WechatMiniProgramOptions.cs        #   小程序配置
│   ├── WechatOfficialOptions.cs           #   公众号配置
│   ├── WechatOpenOptions.cs               #   开放平台配置
│   ├── QQConnectOptions.cs                #   QQ 互联配置
│   ├── WechatHttpClient.cs                #   微信 HTTP 客户端
│   ├── WechatAccessTokenProvider.cs       #   微信 access_token 管理
│   ├── WechatBaseResponse.cs              #   微信响应类
│   ├── WechatCryptoHelper.cs              #   微信消息加解密
│   ├── JsApiTicketProvider.cs             #   公众号 JS-SDK Ticket 缓存与共享
│   ├── WecomOptions.cs                    #   企业微信配置类
│   ├── WecomHttpClient.cs                 #   企业微信 HTTP 客户端
│   ├── WecomAccessTokenProvider.cs        #   企业微信 access_token 管理
│   ├── WecomBaseResponse.cs               #   企业微信响应类
│   ├── WecomCryptoHelper.cs               #   企业微信消息加解密
│   ├── WecomTicketProvider.cs             #   企业微信 JS-SDK Ticket 缓存与共享
│   ├── HexHelper.cs                       #   十六进制工具
│   └── Finance/                           #   会话内容存档原生 SDK
│       ├── FinanceSdk.cs                  #     Finance SDK 封装
│       └── FinanceNativeMethods.cs        #     P/Invoke 声明
├── Models/                                # 数据模型（按产品 × 模块划分，每个类独立文件）
│   ├── MiniProgram/                       #   小程序（104 个模型类）
│   ├── OfficialAccount/                   #   公众号（187 个模型类，含回调消息）
│   ├── OpenPlatform/                      #   开放平台
│   ├── QQConnect/                         #   QQ 互联
│   └── Wecom/                             #   企业微信
│       ├── User/                          #     成员
│       ├── Department/                    #     部门
│       ├── Tag/                           #     标签
│       ├── Message/                       #     消息（含模版卡片）
│       ├── Webhook/                       #     群机器人
│       ├── Agent/                         #     应用
│       ├── Menu/                          #     菜单
│       ├── Media/                         #     素材
│       ├── GroupChat/                      #     群聊
│       ├── OAuth/                         #     OAuth
│       ├── JsSdk/                         #     JS-SDK
│       ├── Callback/                      #     回调消息
│       ├── Kf/                            #     客服
│       ├── Checkin/                       #     打卡
│       ├── Approval/                      #     审批
│       ├── MsgAudit/                      #     会话存档
│       ├── CorpGroup/                     #     企业互联
│       ├── LinkedCorp/                    #     互联企业
│       ├── Export/                        #     异步导出
│       ├── AsyncImport/                   #     异步导入
│       ├── SecondVerify/                  #     二次验证
│       ├── Security/                      #     安全管理
│       ├── AdvancedAccount/               #     高级功能账号
│       ├── OperationLog/                  #     操作日志
│       ├── AccountId/                     #     账号 ID 管理
│       ├── IpRange/                       #     IP 段查询
│       ├── ExternalContact/               #     客户联系
│       ├── CorpPay/                       #     企业支付
│       ├── Email/                         #     邮件
│       ├── Document/                      #     文档
│       ├── Calendar/                      #     日程
│       ├── Meeting/                       #     会议
│       ├── Wedrive/                       #     微盘
│       ├── Living/                        #     直播
│       ├── Dial/                          #     公费电话
│       ├── Report/                        #     汇报
│       ├── Hr/                            #     人事助手
│       ├── MeetingRoom/                   #     会议室
│       ├── Invoice/                       #     电子发票
│       ├── SmartSheet/                    #     智能表格
│       └── CollectForm/                   #     收集表
├── Services/                              # 服务层（按产品 × 模块划分，每个接口 / 实现独立文件）
│   ├── MiniProgram/                       #   小程序（13 对 I*Service / *Service）
│   ├── OfficialAccount/                   #   公众号（17 对 I*Service / *Service）
│   ├── OpenPlatform/                      #   开放平台
│   ├── QQConnect/                         #   QQ 互联
│   └── Wecom/                             #   企业微信
│       ├── User/                          #     成员管理
│       ├── Department/                    #     部门管理
│       ├── Tag/                           #     标签管理
│       ├── Message/                       #     应用消息
│       ├── Webhook/                       #     群机器人
│       ├── Agent/                         #     应用管理
│       ├── Menu/                          #     菜单接口
│       ├── Media/                         #     素材管理
│       ├── GroupChat/                      #     群聊会话
│       ├── OAuth/                         #     OAuth
│       ├── JsSdk/                         #     JS-SDK
│       ├── Callback/                      #     消息回调
│       ├── SmartRobot/                    #     智能机器人
│       ├── Kf/                            #     微信客服
│       ├── Checkin/                       #     打卡
│       ├── Approval/                      #     审批
│       ├── MsgAudit/                      #     会话存档
│       ├── CorpGroup/                     #     企业互联
│       ├── LinkedCorp/                    #     互联企业
│       ├── Export/                        #     异步导出
│       ├── AsyncImport/                   #     异步导入
│       ├── SecondVerify/                  #     二次验证
│       ├── Security/                      #     安全管理
│       ├── AdvancedAccount/               #     高级功能账号
│       ├── OperationLog/                  #     操作日志
│       ├── AccountId/                     #     账号 ID 管理
│       ├── IpRange/                       #     IP 段查询
│       ├── ExternalContact/               #     客户联系
│       ├── CorpPay/                       #     企业支付
│       ├── Email/                         #     邮件
│       ├── Document/                      #     文档
│       ├── Calendar/                      #     日程
│       ├── Meeting/                       #     会议
│       ├── Wedrive/                       #     微盘
│       ├── Living/                        #     直播
│       ├── Dial/                          #     公费电话
│       ├── Report/                        #     汇报
│       ├── Hr/                            #     人事助手
│       ├── MeetingRoom/                   #     会议室
│       ├── Invoice/                       #     电子发票
│       ├── SmartSheet/                    #     智能表格
│       └── CollectForm/                   #     收集表
├── Extensions/                            # DI 扩展
│   ├── WechatServiceCollectionExtensions.cs
│   └── WecomServiceCollectionExtensions.cs
├── WechatMiniProgramClient.cs             # 小程序主客户端
├── WechatOfficialClient.cs                # 公众号主客户端
├── WechatOpenClient.cs                    # 开放平台主客户端
├── QQConnectClient.cs                     # QQ 互联主客户端
├── WecomClient.cs                         # 企业微信主客户端
└── GaoXinLibrary.TencentSDK.csproj        # 项目文件（多目标 net8.0;net9.0;net10.0）
```

---

## 🔧 进阶用法

### 跨服务共享 Token

多台服务器部署时，只需一台**主服务器**持有真实的 `AppSecret` 向腾讯 API 获取 token，其他**备服务器**通过主服务器的接口获取加密后的 token，无需存储 `AppSecret`。

加密算法使用 **ChaCha20-Poly1305**，密钥由 `ShareSecret` 经 SHA-256 派生，格式为 `Base64( nonce[12] + ciphertext[N] + tag[16] )`。

#### 主服务器（持有 AppSecret，对外暴露加密 Token 接口）

```csharp
// Program.cs
builder.Services.AddWecom(opt =>
{
    opt.CorpId     = "your_corpid";
    opt.CorpSecret = "your_corpsecret"; // 仅主服务器配置
    opt.AgentId    = 1000001;
    opt.ShareSecret = "any-strong-shared-secret"; // 与备服务器约定

    // 可选：Token 刷新时推送到 Redis / 消息队列等
    opt.OnTokenChanged = async (newToken, ct) =>
    {
        await redis.StringSetAsync("wecom:token", newToken);
    };
});

// Controller — 对外暴露加密 Token 接口（建议加鉴权）
[HttpGet("/internal/wecom/token")]
public async Task<IActionResult> GetSharedToken([FromServices] WecomClient client)
{
    var result = await client.GetSharedAccessTokenAsync();
    // result.Token     — ChaCha20-Poly1305 加密后的 token（Base64）
    // result.ExpiresIn — 主服务器侧 token 的剩余有效秒数
    return Ok(new { token = result.Token, expires_in = result.ExpiresIn });
}
```

#### 备服务器（无 AppSecret，从主服务器拉取加密 Token）

```csharp
// Program.cs
builder.Services.AddWecom(opt =>
{
    opt.CorpId      = "your_corpid";
    opt.AgentId     = 1000001;
    opt.ShareSecret  = "any-strong-shared-secret"; // 与主服务器一致
    opt.TokenShareUrl = "https://main-server/internal/wecom/token"; // 主服务器接口
    // 不需要配置 CorpSecret
});

// 注入后正常使用，SDK 自动在 token 过期时请求主服务器接口并解密
public class MyService(WecomClient client)
{
    public async Task NotifyAsync()
        => await client.Message.SendTextAsync("Hello!", toUser: "@all");
}
```

#### 也可直接使用加解密工具类

```csharp
using GaoXinLibrary.TencentSDK.Core;

// 加密（主服务器侧）
string encrypted = TencentTokenCrypto.Encrypt(plainToken, "shared-secret");

// 解密（备服务器侧）
string plainToken = TencentTokenCrypto.Decrypt(encrypted, "shared-secret");
```

> 备服务器响应的 `expires_in` 会被 SDK 原样用于设置本地缓存过期时间，确保备服务器的缓存节奏与主服务器保持一致，避免过早或过晚失效。

### 跨服务共享 jsapi_ticket

jsapi_ticket 同样有调用频率限制（企业级每小时 400 次，应用级每小时 100 次），SDK 内置了与 access_token 相同的缓存与共享机制。

#### 公众号 jsapi_ticket 共享

```csharp
// 主服务器
builder.Services.AddWechatOfficial(opt =>
{
    opt.AppId     = "official_appid";
    opt.AppSecret = "official_secret";
    opt.TicketShareSecret = "ticket-shared-secret"; // 与备服务器约定

    // 可选：Ticket 刷新时推送到 Redis 等
    opt.OnTicketChanged = async (newTicket, ct) =>
    {
        await redis.StringSetAsync("official:ticket", newTicket);
    };
});

// Controller — 对外暴露加密 Ticket 接口
[HttpGet("/internal/official/ticket")]
public async Task<IActionResult> GetSharedTicket([FromServices] WechatOfficialClient client)
{
    var result = await client.GetSharedTicketAsync();
    return Ok(new { token = result.Token, expires_in = result.ExpiresIn });
}

// 备服务器
builder.Services.AddWechatOfficial(opt =>
{
    opt.AppId     = "official_appid";
    opt.AppSecret = "official_secret";
    opt.TicketShareSecret = "ticket-shared-secret";
    opt.TicketShareUrl    = "https://main-server/internal/official/ticket";
});
```

#### 企业微信 jsapi_ticket 共享

企业微信有 **两种** jsapi_ticket：
- **企业级** `jsapi_ticket`（用于 `wx.config`）
- **应用级** `jsapi_ticket`（用于 `wx.agentConfig`）

两者均支持独立的缓存、共享、手动设置和刷新。

```csharp
// 主服务器
builder.Services.AddWecom(opt =>
{
    opt.CorpId     = "your_corpid";
    opt.CorpSecret = "your_corpsecret";
    opt.AgentId    = 1000001;

    // 企业级 jsapi_ticket 共享
    opt.JsApiTicketShareSecret = "jsapi-ticket-secret";
    opt.OnJsApiTicketChanged = async (ticket, ct) =>
    {
        await redis.StringSetAsync("wecom:jsapi_ticket", ticket);
    };

    // 应用级 jsapi_ticket 共享
    opt.AgentTicketShareSecret = "agent-ticket-secret";
    opt.OnAgentTicketChanged = async (ticket, ct) =>
    {
        await redis.StringSetAsync("wecom:agent_ticket", ticket);
    };
});

// Controller — 对外暴露加密 Ticket 接口
[HttpGet("/internal/wecom/jsapi-ticket")]
public async Task<IActionResult> GetSharedJsApiTicket([FromServices] WecomClient client)
{
    var result = await client.GetSharedJsApiTicketAsync();
    return Ok(new { token = result.Token, expires_in = result.ExpiresIn });
}

[HttpGet("/internal/wecom/agent-ticket")]
public async Task<IActionResult> GetSharedAgentTicket([FromServices] WecomClient client)
{
    var result = await client.GetSharedAgentTicketAsync();
    return Ok(new { token = result.Token, expires_in = result.ExpiresIn });
}

// 备服务器
builder.Services.AddWecom(opt =>
{
    opt.CorpId  = "your_corpid";
    opt.AgentId = 1000001;

    // 企业级 jsapi_ticket 从主服务器获取
    opt.JsApiTicketShareSecret = "jsapi-ticket-secret";
    opt.JsApiTicketShareUrl    = "https://main-server/internal/wecom/jsapi-ticket";

    // 应用级 jsapi_ticket 从主服务器获取
    opt.AgentTicketShareSecret = "agent-ticket-secret";
    opt.AgentTicketShareUrl    = "https://main-server/internal/wecom/agent-ticket";
});
```

#### 手动管理 jsapi_ticket

```csharp
// ── 公众号 ──
var ticket = await officialClient.GetTicketAsync();       // 自动缓存
await officialClient.RefreshTicketAsync();                 // 强制刷新
officialClient.InvalidateTicketCache();                    // 使缓存失效
officialClient.SetTicket("external_ticket");               // 手动设置

// ── 企业微信（企业级） ──
var jsTicket = await wecomClient.GetJsApiTicketAsync();    // 自动缓存
await wecomClient.RefreshJsApiTicketAsync();               // 强制刷新
wecomClient.InvalidateJsApiTicketCache();                  // 使缓存失效
wecomClient.SetJsApiTicket("external_ticket");             // 手动设置

// ── 企业微信（应用级） ──
var agentTicket = await wecomClient.GetAgentTicketAsync(); // 自动缓存
await wecomClient.RefreshAgentTicketAsync();               // 强制刷新
wecomClient.InvalidateAgentTicketCache();                  // 使缓存失效
wecomClient.SetAgentTicket("external_ticket");             // 手动设置
```

---

### 🔄 瞬态故障自动重试

SDK 内置了瞬态故障自动重试机制，当遇到网络抖动、连接超时、服务端 5xx 等临时性故障时，会按指数退避策略自动重试。此机制与 Token 失效重试独立，两者可叠加工作。

**可重试的故障类型：**
- 网络层错误（连接失败、DNS 解析失败等 `HttpRequestException`）
- HTTP 请求超时（`TaskCanceledException`，非用户主动取消）
- 服务端错误（HTTP 5xx 状态码）

**配置参数 — `TencentRetryOptions`：**

| 属性 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `MaxRetries` | `int` | `2` | 最大重试次数（不含首次请求），设为 0 则不重试 |
| `InitialDelay` | `TimeSpan` | 500ms | 首次重试前的等待时间，后续按指数退避递增 |
| `MaxDelay` | `TimeSpan` | 5s | 单次重试等待时间上限 |

```csharp
// 使用默认重试配置（2 次重试，500ms 起始延迟，指数退避）
var client = WecomClient.Create(new WecomOptions
{
    CorpId     = "your_corpid",
    CorpSecret = "your_corpsecret",
    AgentId    = 1000001
    // RetryOptions 默认已启用，无需额外配置
});

// 自定义重试策略
var client2 = WecomClient.Create(new WecomOptions
{
    CorpId     = "your_corpid",
    CorpSecret = "your_corpsecret",
    AgentId    = 1000001,
    RetryOptions = new TencentRetryOptions
    {
        MaxRetries   = 3,                              // 最多重试 3 次
        InitialDelay = TimeSpan.FromMilliseconds(200),  // 首次重试等待 200ms
        MaxDelay     = TimeSpan.FromSeconds(10)          // 单次最多等待 10s
    }
});

// 禁用重试
var client3 = WecomClient.Create(new WecomOptions
{
    CorpId     = "your_corpid",
    CorpSecret = "your_corpsecret",
    AgentId    = 1000001,
    RetryOptions = new TencentRetryOptions { MaxRetries = 0 }
});
```

> 💡 **设计说明**：瞬态重试工作在 Token 重试的**内层**，即每次使用某个 Token 发起请求时，先尝试瞬态重试；若所有重试均失败且错误为 Token 失效，再触发 Token 刷新。这避免了网络问题被误判为 Token 失效。

---

### 自定义 HttpClient

传入自定义的 `HttpClient` 实例（例如添加代理、自定义 Handler）：

```csharp
var handler = new HttpClientHandler
{
    Proxy = new WebProxy("http://proxy.example.com:8080"),
    UseProxy = true
};
var httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(60) };

var client = WecomClient.Create(new WecomOptions
{
    CorpId     = "your_corpid",
    CorpSecret = "your_corpsecret",
    AgentId    = 1000001
}, httpClient);
```

### 手动管理 access_token

```csharp
// 获取当前有效的 access_token（自动缓存，未过期时直接返回）
var token = await client.GetAccessTokenAsync();

// 强制刷新并获取新的 access_token（异步，遇到 token 失效错误时推荐使用）
var newToken = await client.RefreshAccessTokenAsync();

// 仅使缓存失效（下次调用 GetAccessTokenAsync 时重新获取）
client.InvalidateAccessTokenCache();

// 手动设置 access_token（适用于外部统一管理 Token 的场景）
client.SetAccessToken("your_external_token");

// 手动设置 access_token 并指定有效期
client.SetAccessToken("your_external_token", TimeSpan.FromSeconds(3600));
```

### 异常处理

SDK 在 API 调用失败时会抛出 `TencentException`，包含错误码和错误信息：

```csharp
using GaoXinLibrary.TencentSDK.Core;

try
{
    await client.Message.SendTextAsync("Hello!", toUser: "@all");
}
catch (TencentException ex)
{
    Console.WriteLine($"API 错误 [{ex.ErrCode}]: {ex.Message}");
    // ex.ErrCode — 平台官方错误码
    // ex.Message — 错误描述
}
```

---

## 📋 API 参考

所有公开类型均附带完整的 XML 文档注释。在 Visual Studio / VS Code / Rider 中，悬停即可查看方法签名、参数说明和使用示例。

构建时自动生成 XML 文档文件（`GenerateDocumentationFile = true`），也可集成 DocFX 等工具生成在线文档。

---

## 许可证

MIT
