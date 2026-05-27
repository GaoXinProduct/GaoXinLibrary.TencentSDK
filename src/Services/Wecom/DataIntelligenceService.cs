using GaoXinLibrary.TencentSDK.Core;
using GaoXinLibrary.TencentSDK.Wecom.Core;
using GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.AppInvoke;
using GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.Debug;
using GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.Expansion;
using GaoXinLibrary.TencentSDK.Wecom.Models.DataIntelligence.SDK;

namespace GaoXinLibrary.TencentSDK.Wecom.Services;

public sealed class DataIntelligenceService
{
    private readonly WecomHttpClient _http;

    public DataIntelligenceService(WecomHttpClient http) => _http = http;

    public async Task<SetPublicKeyResponse> SetPublicKeyAsync(SetPublicKeyRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SetPublicKeyResponse>("/cgi-bin/DataIntelligence/set_public_key", request, ct).ConfigureAwait(false);

    public async Task<GetPermitUserListResponse> GetPermitUserListAsync(GetPermitUserListRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetPermitUserListResponse>("/cgi-bin/DataIntelligence/get_permit_user_list", request, ct).ConfigureAwait(false);

    public async Task<SetReceiveCallbackResponse> SetReceiveCallbackAsync(SetReceiveCallbackRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SetReceiveCallbackResponse>("/cgi-bin/DataIntelligence/set_receive_callback", request, ct).ConfigureAwait(false);

    public async Task<SetSensitiveInfoHideResponse> SetSensitiveInfoHideAsync(SetSensitiveInfoHideRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SetSensitiveInfoHideResponse>("/cgi-bin/DataIntelligence/set_sensitive_info_hide", request, ct).ConfigureAwait(false);

    public async Task<SetLogLevelResponse> SetLogLevelAsync(SetLogLevelRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SetLogLevelResponse>("/cgi-bin/DataIntelligence/set_log_level", request, ct).ConfigureAwait(false);

    public async Task<UploadTempFileResponse> UploadTempFileAsync(UploadTempFileRequest request, CancellationToken ct = default)
        => await _http.PostAsync<UploadTempFileResponse>("/cgi-bin/DataIntelligence/upload_temp_file", request, ct).ConfigureAwait(false);

    public async Task<SyncInvokeResponse> SyncInvokeAsync(SyncInvokeRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SyncInvokeResponse>("/cgi-bin/DataIntelligence/sync_invoke", request, ct).ConfigureAwait(false);

    public async Task<AsyncInvokeResponse> AsyncInvokeAsync(AsyncInvokeRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AsyncInvokeResponse>("/cgi-bin/DataIntelligence/async_invoke", request, ct).ConfigureAwait(false);

    public async Task<GetChatDataResponse> GetChatDataAsync(GetChatDataRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetChatDataResponse>("/cgi-bin/DataIntelligence/get_chat_data", request, ct).ConfigureAwait(false);

    public async Task<GetConsentInfoResponse> GetConsentInfoAsync(GetConsentInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetConsentInfoResponse>("/cgi-bin/DataIntelligence/get_consent_info", request, ct).ConfigureAwait(false);

    public async Task<GetInternalGroupInfoResponse> GetInternalGroupInfoAsync(GetInternalGroupInfoRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetInternalGroupInfoResponse>("/cgi-bin/DataIntelligence/get_internal_group_info", request, ct).ConfigureAwait(false);

    public async Task<SearchByNameResponse> SearchByNameAsync(SearchByNameRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SearchByNameResponse>("/cgi-bin/DataIntelligence/search_by_name", request, ct).ConfigureAwait(false);

    public async Task<SearchMessagesResponse> SearchMessagesAsync(SearchMessagesRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SearchMessagesResponse>("/cgi-bin/DataIntelligence/search_messages", request, ct).ConfigureAwait(false);

    public async Task<SearchStaffOrCustomerResponse> SearchStaffOrCustomerAsync(SearchStaffOrCustomerRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SearchStaffOrCustomerResponse>("/cgi-bin/DataIntelligence/search_staff_or_customer", request, ct).ConfigureAwait(false);

    public async Task<ManageKeywordRuleResponse> ManageKeywordRuleAsync(ManageKeywordRuleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ManageKeywordRuleResponse>("/cgi-bin/DataIntelligence/manage_keyword_rule", request, ct).ConfigureAwait(false);

    public async Task<GetHitKeywordRuleResponse> GetHitKeywordRuleAsync(GetHitKeywordRuleRequest request, CancellationToken ct = default)
        => await _http.PostAsync<GetHitKeywordRuleResponse>("/cgi-bin/DataIntelligence/get_hit_keyword_rule", request, ct).ConfigureAwait(false);

    public async Task<ManageKnowledgeBaseResponse> ManageKnowledgeBaseAsync(ManageKnowledgeBaseRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ManageKnowledgeBaseResponse>("/cgi-bin/DataIntelligence/manage_knowledge_base", request, ct).ConfigureAwait(false);

    public async Task<CommonModelResponse> CommonModelAsync(CommonModelRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CommonModelResponse>("/cgi-bin/DataIntelligence/common_model", request, ct).ConfigureAwait(false);

    public async Task<SpeechSkillResponse> SpeechSkillAsync(SpeechSkillRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SpeechSkillResponse>("/cgi-bin/DataIntelligence/speech_skill", request, ct).ConfigureAwait(false);

    public async Task<CustomerLabelModelResponse> CustomerLabelModelAsync(CustomerLabelModelRequest request, CancellationToken ct = default)
        => await _http.PostAsync<CustomerLabelModelResponse>("/cgi-bin/DataIntelligence/customer_label_model", request, ct).ConfigureAwait(false);

    public async Task<SessionSummaryModelResponse> SessionSummaryModelAsync(SessionSummaryModelRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SessionSummaryModelResponse>("/cgi-bin/DataIntelligence/session_summary_model", request, ct).ConfigureAwait(false);

    public async Task<SentimentAnalysisResponse> SentimentAnalysisAsync(SentimentAnalysisRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SentimentAnalysisResponse>("/cgi-bin/DataIntelligence/sentiment_analysis", request, ct).ConfigureAwait(false);

    public async Task<SelfAnalysisResponse> SelfAnalysisAsync(SelfAnalysisRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SelfAnalysisResponse>("/cgi-bin/DataIntelligence/self_analysis", request, ct).ConfigureAwait(false);

    public async Task<AntiSpamResponse> AntiSpamAsync(AntiSpamRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AntiSpamResponse>("/cgi-bin/DataIntelligence/anti_spam", request, ct).ConfigureAwait(false);

    public async Task<AsyncCallResponse> AsyncCallAsync(AsyncCallRequest request, CancellationToken ct = default)
        => await _http.PostAsync<AsyncCallResponse>("/cgi-bin/DataIntelligence/async_call", request, ct).ConfigureAwait(false);

    public async Task<ReportTaskResultResponse> ReportTaskResultAsync(ReportTaskResultRequest request, CancellationToken ct = default)
        => await _http.PostAsync<ReportTaskResultResponse>("/cgi-bin/DataIntelligence/report_task_result", request, ct).ConfigureAwait(false);

    public async Task<NotifyAppResponse> NotifyAppAsync(NotifyAppRequest request, CancellationToken ct = default)
        => await _http.PostAsync<NotifyAppResponse>("/cgi-bin/DataIntelligence/notify_app", request, ct).ConfigureAwait(false);

    public async Task<SetDebugModeResponse> SetDebugModeAsync(SetDebugModeRequest request, CancellationToken ct = default)
        => await _http.PostAsync<SetDebugModeResponse>("/cgi-bin/DataIntelligence/set_debug_mode", request, ct).ConfigureAwait(false);

    public async Task<CloseDebugModeResponse> CloseDebugModeAsync(CancellationToken ct = default)
        => await _http.PostAsync<CloseDebugModeResponse>("/cgi-bin/DataIntelligence/close_debug_mode", EmptyRequest.Instance, ct).ConfigureAwait(false);

    public async Task<GetDebugModeStatusResponse> GetDebugModeStatusAsync(CancellationToken ct = default)
        => await _http.PostAsync<GetDebugModeStatusResponse>("/cgi-bin/DataIntelligence/get_debug_mode_status", EmptyRequest.Instance, ct).ConfigureAwait(false);
}