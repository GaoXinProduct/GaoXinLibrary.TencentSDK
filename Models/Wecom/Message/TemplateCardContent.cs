using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Wecom.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Message;

// ─── 模版卡片消息（发送） ──────────────────────────────────────────────────

/// <summary>
/// 模版卡片消息内容
/// <para>card_type 可选值：text_notice / news_notice / button_interaction / vote_interaction / multiple_interaction</para>
/// </summary>
public class TemplateCardContent
{
    /// <summary>模版卡片类型：text_notice / news_notice / button_interaction / vote_interaction / multiple_interaction</summary>
    [JsonPropertyName("card_type")] public string CardType { get; set; } = string.Empty;

    /// <summary>卡片来源样式信息（非必填）</summary>
    [JsonPropertyName("source")] public TemplateCardSource? Source { get; set; }

    /// <summary>卡片右上角更多操作按钮（非必填）</summary>
    [JsonPropertyName("action_menu")] public TemplateCardActionMenu? ActionMenu { get; set; }

    /// <summary>模版卡片的主要内容，包括一级标题和标题辅助信息</summary>
    [JsonPropertyName("main_title")] public TemplateCardMainTitle? MainTitle { get; set; }

    /// <summary>引用文献样式（非必填）</summary>
    [JsonPropertyName("quote_area")] public TemplateCardQuoteArea? QuoteArea { get; set; }

    /// <summary>关键数据样式（非必填）</summary>
    [JsonPropertyName("emphasis_content")] public TemplateCardEmphasisContent? EmphasisContent { get; set; }

    /// <summary>二级普通文本（非必填）</summary>
    [JsonPropertyName("sub_title_text")] public string? SubTitleText { get; set; }

    /// <summary>二级标题+文本列表（非必填，最多6个）</summary>
    [JsonPropertyName("horizontal_content_list")] public TemplateCardHorizontalContent[]? HorizontalContentList { get; set; }

    /// <summary>跳转指引样式列表（非必填，最多3个）</summary>
    [JsonPropertyName("jump_list")] public TemplateCardJump[]? JumpList { get; set; }

    /// <summary>整体卡片的点击跳转事件</summary>
    [JsonPropertyName("card_action")] public TemplateCardAction? CardAction { get; set; }

    /// <summary>任务 ID（同一个应用内唯一，用于更新卡片时同步）</summary>
    [JsonPropertyName("task_id")] public string? TaskId { get; set; }

    // ── news_notice 专用 ─────────────────────────────────────────────────

    /// <summary>左图右文样式（news_notice 使用）</summary>
    [JsonPropertyName("image_text_area")] public TemplateCardImageTextArea? ImageTextArea { get; set; }

    /// <summary>卡片图片样式（news_notice 使用）</summary>
    [JsonPropertyName("card_image")] public TemplateCardImage? CardImage { get; set; }

    /// <summary>竖向内容（news_notice 使用，最多4个）</summary>
    [JsonPropertyName("vertical_content_list")] public TemplateCardVerticalContent[]? VerticalContentList { get; set; }

    // ── button_interaction 专用 ──────────────────────────────────────────

    /// <summary>按钮交互型 — 按钮列表（最多6个）</summary>
    [JsonPropertyName("button_list")] public TemplateCardButtonItem[]? ButtonList { get; set; }

    /// <summary>按钮交互型 — 下拉式按钮（非必填）</summary>
    [JsonPropertyName("button_selection")] public TemplateCardButtonSelection? ButtonSelection { get; set; }

    // ── vote_interaction 专用 ────────────────────────────────────────────

    /// <summary>投票交互型 — 选择题（最多20个选项）</summary>
    [JsonPropertyName("checkbox")] public TemplateCardCheckbox? Checkbox { get; set; }

    /// <summary>提交按钮样式</summary>
    [JsonPropertyName("submit_button")] public TemplateCardSubmitButton? SubmitButton { get; set; }

    // ── multiple_interaction 专用 ────────────────────────────────────────

    /// <summary>多项选择列表（最多6个）</summary>
    [JsonPropertyName("select_list")] public TemplateCardSelect[]? SelectList { get; set; }
}

