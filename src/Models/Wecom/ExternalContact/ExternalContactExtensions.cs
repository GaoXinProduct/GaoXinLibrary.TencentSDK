using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.ExternalContact;

/// <summary>
/// 转换 tmp_external_userid 请求
/// </summary>
public record ConvertTmpExternalUserIdRequest
{
    /// <summary>业务类型。1-会议 2-收集表 3-智能表</summary>
    [JsonPropertyName("business_type")]
    public int BusinessType { get; init; }

    /// <summary>转换的目标用户类型。1-客户 2-企业互联 3-上下游 4-互联企业（圈子）</summary>
    [JsonPropertyName("user_type")]
    public int UserType { get; init; }

    /// <summary>外部用户临时 id 列表，最多不超过 100 个</summary>
    [JsonPropertyName("tmp_external_userid_list")]
    public string[] TmpExternalUserIdList { get; init; } = [];
}

/// <summary>
/// 转换结果项
/// </summary>
public record ConvertTmpExternalUserIdResult
{
    /// <summary>输入的 tmp_external_userid</summary>
    [JsonPropertyName("tmp_external_userid")]
    public string? TmpExternalUserId { get; init; }

    /// <summary>转换后的 userid，user_type 为 1 时返回</summary>
    [JsonPropertyName("external_userid")]
    public string? ExternalUserId { get; init; }

    /// <summary>userid 对应的 corpid，user_type 为 2、3、4 时返回</summary>
    [JsonPropertyName("corpid")]
    public string? CorpId { get; init; }

    /// <summary>转换后的 userid，user_type 为 2、3、4 时返回</summary>
    [JsonPropertyName("userid")]
    public string? UserId { get; init; }
}

/// <summary>
/// 转换 tmp_external_userid 响应
/// </summary>
public class ConvertTmpExternalUserIdResponse : WecomBaseResponse
{
    [JsonPropertyName("results")] public ConvertTmpExternalUserIdResult[]? Results { get; init; }
    [JsonPropertyName("invalid_tmp_external_userid_list")] public string[]? InvalidTmpExternalUserIdList { get; init; }
}

/// <summary>
/// 获取企业标签列表请求
/// </summary>
public record GetCorpTagListRequest
{
    /// <summary>要查询的标签 id 列表</summary>
    [JsonPropertyName("tag_id")]
    public string[]? TagId { get; init; }

    /// <summary>要查询的标签组 id 列表，返回该标签组以及其下的所有标签信息</summary>
    [JsonPropertyName("group_id")]
    public string[]? GroupId { get; init; }
}

/// <summary>
/// 标签信息
/// </summary>
public record CorpTagInfo
{
    /// <summary>标签 id</summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>标签名称</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>标签创建时间</summary>
    [JsonPropertyName("create_time")]
    public long CreateTime { get; init; }

    /// <summary>标签排序的次序值，order 值大的排序靠前。有效的值范围是 [0, 2^32)</summary>
    [JsonPropertyName("order")]
    public uint Order { get; init; }

    /// <summary>标签是否已经被删除，只在指定 tag_id 进行查询时返回</summary>
    [JsonPropertyName("deleted")]
    public bool Deleted { get; init; }
}

/// <summary>
/// 标签组信息
/// </summary>
public record CorpTagGroup
{
    /// <summary>标签组 id</summary>
    [JsonPropertyName("group_id")]
    public string? GroupId { get; init; }

    /// <summary>标签组名称</summary>
    [JsonPropertyName("group_name")]
    public string? GroupName { get; init; }

    /// <summary>标签组创建时间</summary>
    [JsonPropertyName("create_time")]
    public long CreateTime { get; init; }

    /// <summary>标签组排序的次序值，order 值大的排序靠前。有效的值范围是 [0, 2^32)</summary>
    [JsonPropertyName("order")]
    public uint Order { get; init; }

    /// <summary>标签组是否已经被删除，只在指定 tag_id 进行查询时返回</summary>
    [JsonPropertyName("deleted")]
    public bool Deleted { get; init; }

    /// <summary>标签组内的标签列表</summary>
    [JsonPropertyName("tag")]
    public CorpTagInfo[]? Tag { get; init; }
}

/// <summary>
/// 获取企业标签列表响应
/// </summary>
public class GetCorpTagListResponse : WecomBaseResponse
{
    [JsonPropertyName("tag_group")] public CorpTagGroup[]? TagGroup { get; init; }
}

/// <summary>
/// 添加企业标签请求
/// </summary>
public record AddCorpTagRequest
{
    /// <summary>标签组 id，若指定则向此标签组下添加标签</summary>
    [JsonPropertyName("group_id")]
    public string? GroupId { get; init; }

    /// <summary>标签组名称，最长为 30 个字符</summary>
    [JsonPropertyName("group_name")]
    public string? GroupName { get; init; }

    /// <summary>标签组次序值，order 值大的排序靠前</summary>
    [JsonPropertyName("order")]
    public uint? Order { get; init; }

    /// <summary>标签列表</summary>
    [JsonPropertyName("tag")]
    public CorpTagAddItem[]? Tag { get; init; }

    /// <summary>授权方安装的应用 agentid</summary>
    [JsonPropertyName("agentid")]
    public int? AgentId { get; init; }
}

/// <summary>
/// 添加的标签项
/// </summary>
public record CorpTagAddItem
{
    /// <summary>标签名称，最长为 30 个字符</summary>
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    /// <summary>标签次序值，order 值大的排序靠前</summary>
    [JsonPropertyName("order")]
    public uint? Order { get; init; }
}

/// <summary>
/// 添加企业标签响应
/// </summary>
public class AddCorpTagResponse : WecomBaseResponse
{
    [JsonPropertyName("tag_group")] public CorpTagGroup? TagGroup { get; init; }
}

/// <summary>
/// 编辑企业标签请求
/// </summary>
public record UpdateCorpTagRequest
{
    /// <summary>标签或标签组的 id</summary>
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    /// <summary>新的标签或标签组名称，最长为 30 个字符</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>标签或标签组的次序值，order 值大的排序靠前</summary>
    [JsonPropertyName("order")]
    public uint? Order { get; init; }

    /// <summary>授权方安装的应用 agentid</summary>
    [JsonPropertyName("agentid")]
    public int? AgentId { get; init; }
}

/// <summary>
/// 删除企业标签请求
/// </summary>
public record DeleteCorpTagRequest
{
    /// <summary>标签的 id 列表</summary>
    [JsonPropertyName("tag_id")]
    public string[]? TagId { get; init; }

    /// <summary>标签组的 id 列表</summary>
    [JsonPropertyName("group_id")]
    public string[]? GroupId { get; init; }

    /// <summary>授权方安装的应用 agentid</summary>
    [JsonPropertyName("agentid")]
    public int? AgentId { get; init; }
}

/// <summary>
/// 分配在职成员的客户请求
/// </summary>
public record TransferCustomerRequest
{
    /// <summary>原跟进成员的 userid</summary>
    [JsonPropertyName("handover_userid")]
    public string HandoverUserId { get; init; } = string.Empty;

    /// <summary>接替成员的 userid</summary>
    [JsonPropertyName("takeover_userid")]
    public string TakeoverUserId { get; init; } = string.Empty;

    /// <summary>客户的 external_userid 列表，每次最多分配 100 个客户</summary>
    [JsonPropertyName("external_userid")]
    public string[] ExternalUserId { get; init; } = [];

    /// <summary>转移成功后发给客户的消息，最多 200 个字符</summary>
    [JsonPropertyName("transfer_success_msg")]
    public string? TransferSuccessMsg { get; init; }
}

/// <summary>
/// 客户分配结果项
/// </summary>
public record TransferCustomerResult
{
    /// <summary>客户的 external_userid</summary>
    [JsonPropertyName("external_userid")]
    public string? ExternalUserId { get; init; }

    /// <summary>对此客户进行分配的结果，0 表示成功</summary>
    [JsonPropertyName("errcode")]
    public int ErrCode { get; init; }
}

/// <summary>
/// 分配在职成员的客户响应
/// </summary>
public class TransferCustomerResponse : WecomBaseResponse
{
    [JsonPropertyName("customer")] public TransferCustomerResult[]? Customer { get; init; }
}

/// <summary>
/// 查询客户接替状态请求（在职）
/// </summary>
public record GetTransferCustomerResultRequest
{
    /// <summary>原添加成员的 userid</summary>
    [JsonPropertyName("handover_userid")]
    public string HandoverUserId { get; init; } = string.Empty;

    /// <summary>接替成员的 userid</summary>
    [JsonPropertyName("takeover_userid")]
    public string TakeoverUserId { get; init; } = string.Empty;

    /// <summary>分页查询的 cursor</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}

/// <summary>
/// 客户接替状态项
/// </summary>
public record TransferCustomerStatus
{
    /// <summary>转接客户的外部联系人 userid</summary>
    [JsonPropertyName("external_userid")]
    public string? ExternalUserId { get; init; }

    /// <summary>接替状态。1-接替完毕 2-等待接替 3-客户拒绝 4-接替成员客户达到上限</summary>
    [JsonPropertyName("status")]
    public int Status { get; init; }

    /// <summary>接替客户的时间，如果是等待接替状态，则为未来的自动接替时间</summary>
    [JsonPropertyName("takeover_time")]
    public long TakeoverTime { get; init; }
}

/// <summary>
/// 查询客户接替状态响应
/// </summary>
public class GetTransferCustomerResultResponse : WecomBaseResponse
{
    [JsonPropertyName("customer")] public TransferCustomerStatus[]? Customer { get; init; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; init; }
}

/// <summary>
/// 分配在职成员的客户群请求
/// </summary>
public record TransferGroupChatRequest
{
    /// <summary>需要转群主的客户群 ID 列表，取值范围 1 ~ 100</summary>
    [JsonPropertyName("chat_id_list")]
    public string[] ChatIdList { get; init; } = [];

    /// <summary>新群主 ID</summary>
    [JsonPropertyName("new_owner")]
    public string NewOwner { get; init; } = string.Empty;
}

/// <summary>
/// 客户群分配失败项
/// </summary>
public record FailedGroupChat
{
    /// <summary>没能成功继承的群 ID</summary>
    [JsonPropertyName("chat_id")]
    public string? ChatId { get; init; }

    /// <summary>错误码</summary>
    [JsonPropertyName("errcode")]
    public int ErrCode { get; init; }

    /// <summary>错误描述</summary>
    [JsonPropertyName("errmsg")]
    public string? ErrMsg { get; init; }
}

/// <summary>
/// 分配在职成员的客户群响应
/// </summary>
public class TransferGroupChatResponse : WecomBaseResponse
{
    [JsonPropertyName("failed_chat_list")] public FailedGroupChat[]? FailedChatList { get; init; }
}

/// <summary>
/// 查询客户群接替状态请求
/// </summary>
public record GetTransferGroupChatResultRequest
{
    /// <summary>需要查询的客户群 ID 列表</summary>
    [JsonPropertyName("chat_id_list")]
    public string[] ChatIdList { get; init; } = [];

    /// <summary>分页查询的 cursor</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}

/// <summary>
/// 查询客户群接替状态响应
/// </summary>
public class GetTransferGroupChatResultResponse : WecomBaseResponse
{
    [JsonPropertyName("result_list")] public GroupChatTransferResult[]? ResultList { get; init; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; init; }
}

/// <summary>
/// 客户群接替结果
/// </summary>
public record GroupChatTransferResult
{
    /// <summary>客户群 ID</summary>
    [JsonPropertyName("chat_id")]
    public string? ChatId { get; init; }

    /// <summary>转接状态</summary>
    [JsonPropertyName("status")]
    public int Status { get; init; }

    /// <summary>接替时间</summary>
    [JsonPropertyName("takeover_time")]
    public long TakeoverTime { get; init; }
}

/// <summary>
/// 分配离职成员的客户请求
/// </summary>
public record DemotionTransferCustomerRequest
{
    /// <summary>原跟进成员的 userid（必须是已离职用户）</summary>
    [JsonPropertyName("handover_userid")]
    public string HandoverUserId { get; init; } = string.Empty;

    /// <summary>接替成员的 userid</summary>
    [JsonPropertyName("takeover_userid")]
    public string TakeoverUserId { get; init; } = string.Empty;

    /// <summary>客户的 external_userid 列表，最多一次转移 100 个客户</summary>
    [JsonPropertyName("external_userid")]
    public string[] ExternalUserId { get; init; } = [];
}

/// <summary>
/// 分配离职成员的客户响应
/// </summary>
public class DemotionTransferCustomerResponse : WecomBaseResponse
{
    [JsonPropertyName("customer")] public TransferCustomerResult[]? Customer { get; init; }
}

/// <summary>
/// 查询离职客户接替状态请求
/// </summary>
public record GetDemotionTransferResultRequest
{
    /// <summary>原添加成员的 userid</summary>
    [JsonPropertyName("handover_userid")]
    public string HandoverUserId { get; init; } = string.Empty;

    /// <summary>接替成员的 userid</summary>
    [JsonPropertyName("takeover_userid")]
    public string TakeoverUserId { get; init; } = string.Empty;

    /// <summary>分页查询的 cursor</summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}

/// <summary>
/// 查询离职客户接替状态响应
/// </summary>
public class GetDemotionTransferResultResponse : WecomBaseResponse
{
    [JsonPropertyName("customer")] public TransferCustomerStatus[]? Customer { get; init; }
    [JsonPropertyName("next_cursor")] public string? NextCursor { get; init; }
}

/// <summary>
/// 客户群 opengid 转换请求
/// </summary>
public record GetGroupChatByExternalUserIdRequest
{
    /// <summary>小程序在微信获取到的群 ID</summary>
    [JsonPropertyName("opengid")]
    public string OpengId { get; init; } = string.Empty;
}

/// <summary>
/// 客户群 opengid 转换响应
/// </summary>
public class GetGroupChatByExternalUserIdResponse : WecomBaseResponse
{
    [JsonPropertyName("chat_id")] public string? ChatId { get; init; }
}