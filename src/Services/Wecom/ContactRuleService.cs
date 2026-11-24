using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.ContactRule;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

/// <summary>通讯录查看权限规则服务，使用通讯录同步应用凭证。</summary>
public sealed class ContactRuleService
{
    private readonly WecomHttpClient _http;

    public ContactRuleService(WecomHttpClient http) => _http = http;

    /// <summary>批量创建通讯录查看权限规则。</summary>
    /// <seealso href="https://developer.work.weixin.qq.com/document/path/101536"/>
    public Task<CreateContactRulesResponse> CreateRulesAsync(ContactVisibilityRule[] rules, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(rules);
        if (rules.Length is 0 or > 100 || rules.Any(rule => rule is null || rule.Range is null))
            throw new ArgumentException("请提供 1 到 100 条包含作用范围的规则。", nameof(rules));

        return _http.PostAsync<CreateContactRulesResponse>("/cgi-bin/contactrule/create", new { rules }, ct);
    }

    /// <summary>读取通讯录查看权限规则列表。</summary>
    /// <seealso href="https://developer.work.weixin.qq.com/document/path/101537"/>
    public Task<ContactRulesResponse> GetRuleListAsync(CancellationToken ct = default)
        => _http.PostQueryAsync<ContactRulesResponse>("/cgi-bin/contactrule/list", null, ct);

    /// <summary>批量修改通讯录查看权限规则。</summary>
    /// <seealso href="https://developer.work.weixin.qq.com/document/path/101539"/>
    public Task<ContactRulesResponse> UpdateRulesAsync(ContactVisibilityRule[] rules, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(rules);
        if (rules.Length is 0 or > 100 || rules.Any(rule => rule is null || rule.RuleId is not > 0 || rule.Range is null))
            throw new ArgumentException("请提供 1 到 100 条包含规则 ID 和作用范围的规则。", nameof(rules));

        return _http.PostAsync<ContactRulesResponse>("/cgi-bin/contactrule/update", new { rules }, ct);
    }

    /// <summary>批量删除通讯录查看权限规则，每次最多 100 条。</summary>
    /// <seealso href="https://developer.work.weixin.qq.com/document/path/101540"/>
    public Task DeleteRulesAsync(int[] ruleIds, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(ruleIds);
        if (ruleIds.Length is 0 or > 100 || ruleIds.Any(id => id <= 0))
            throw new ArgumentException("请提供 1 到 100 个有效的规则 ID。", nameof(ruleIds));

        return _http.PostAsync<WecomBaseResponse>("/cgi-bin/contactrule/delete", new { rule_ids = ruleIds }, ct);
    }
}
