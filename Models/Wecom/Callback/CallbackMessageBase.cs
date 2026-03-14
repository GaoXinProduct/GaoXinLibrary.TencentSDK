using System.Xml.Linq;
using System.Text.Json.Serialization;
using GaoXinLibrary.TencentSDK.Core;

namespace GaoXinLibrary.TencentSDK.Wecom.Models.Callback;

// ═══════════════════════════════════════════════════════════════════════════

/// <summary>
/// 企业微信回调消息基类
/// <para>所有接收到的消息和事件都继承此类</para>
/// </summary>
public class CallbackMessageBase
{
    /// <summary>企业微信 CorpID</summary>
    public string ToUserName { get; set; } = string.Empty;

    /// <summary>成员 UserID</summary>
    public string FromUserName { get; set; } = string.Empty;

    /// <summary>消息创建时间（Unix 时间戳）</summary>
    public long CreateTime { get; set; }

    /// <summary>消息类型（text / image / voice / video / location / link / event 等）</summary>
    public string MsgType { get; set; } = string.Empty;

    /// <summary>企业应用的 AgentID</summary>
    public int AgentID { get; set; }

    /// <summary>从解密后的 XML 解析消息</summary>
    public static CallbackMessageBase FromXml(string xml)
    {
        var doc = XDocument.Parse(xml);
        var root = doc.Root ?? throw new TencentException("无效的回调消息 XML：缺少根节点");

        var msgType = root.Element("MsgType")?.Value ?? string.Empty;
        return msgType switch
        {
            "text" => ParseTextMessage(root),
            "image" => ParseImageMessage(root),
            "voice" => ParseVoiceMessage(root),
            "video" or "shortvideo" => ParseVideoMessage(root, msgType),
            "location" => ParseLocationMessage(root),
            "link" => ParseLinkMessage(root),
            "attachment" => ParseAttachmentMessage(root),
            "event" => ParseEvent(root),
            _ => ParseBase(root, msgType)
        };
    }

    // ─── 解析各消息类型 ─────────────────────────────────────────────────

    private static CallbackTextMessage ParseTextMessage(XElement root)
    {
        var msg = FillBase<CallbackTextMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        msg.Content = root.Element("Content")?.Value ?? string.Empty;
        return msg;
    }

    private static CallbackImageMessage ParseImageMessage(XElement root)
    {
        var msg = FillBase<CallbackImageMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        msg.PicUrl = root.Element("PicUrl")?.Value ?? string.Empty;
        msg.MediaId = root.Element("MediaId")?.Value ?? string.Empty;
        return msg;
    }

    private static CallbackVoiceMessage ParseVoiceMessage(XElement root)
    {
        var msg = FillBase<CallbackVoiceMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        msg.MediaId = root.Element("MediaId")?.Value ?? string.Empty;
        msg.Format = root.Element("Format")?.Value ?? string.Empty;
        return msg;
    }

    private static CallbackVideoMessage ParseVideoMessage(XElement root, string msgType)
    {
        var msg = FillBase<CallbackVideoMessage>(root);
        msg.MsgType = msgType;
        msg.MsgId = GetLong(root, "MsgId");
        msg.MediaId = root.Element("MediaId")?.Value ?? string.Empty;
        msg.ThumbMediaId = root.Element("ThumbMediaId")?.Value ?? string.Empty;
        return msg;
    }

    private static CallbackLocationMessage ParseLocationMessage(XElement root)
    {
        var msg = FillBase<CallbackLocationMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        msg.LocationX = GetDouble(root, "Location_X");
        msg.LocationY = GetDouble(root, "Location_Y");
        msg.Scale = GetInt(root, "Scale");
        msg.Label = root.Element("Label")?.Value ?? string.Empty;
        msg.AppType = root.Element("AppType")?.Value;
        return msg;
    }

    private static CallbackLinkMessage ParseLinkMessage(XElement root)
    {
        var msg = FillBase<CallbackLinkMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        msg.Title = root.Element("Title")?.Value ?? string.Empty;
        msg.Description = root.Element("Description")?.Value ?? string.Empty;
        msg.Url = root.Element("Url")?.Value ?? string.Empty;
        msg.PicUrl = root.Element("PicUrl")?.Value;
        return msg;
    }

    private static CallbackAttachmentMessage ParseAttachmentMessage(XElement root)
    {
        var msg = FillBase<CallbackAttachmentMessage>(root);
        msg.MsgId = GetLong(root, "MsgId");
        var attachment = root.Element("Attachment");
        if (attachment != null)
        {
            msg.CallbackId = attachment.Element("CallbackId")?.Value ?? string.Empty;
            var actions = attachment.Element("Actions");
            if (actions != null)
            {
                msg.Actions = actions.Elements("item").Select(item => new CallbackAttachmentAction
                {
                    Name = item.Element("Name")?.Value ?? string.Empty,
                    Value = item.Element("Value")?.Value ?? string.Empty,
                    Type = item.Element("Type")?.Value ?? string.Empty,
                    Key = item.Element("Key")?.Value ?? string.Empty
                }).ToArray();
            }
        }
        return msg;
    }

    // ─── 解析事件 ──────────────────────────────────────────────────────

    private static CallbackMessageBase ParseEvent(XElement root)
    {
        var eventType = root.Element("Event")?.Value ?? string.Empty;
        return eventType.ToLowerInvariant() switch
        {
            "subscribe" => FillEvent<CallbackSubscribeEvent>(root),
            "unsubscribe" => FillEvent<CallbackSubscribeEvent>(root),
            "enter_agent" => FillEvent<CallbackEnterAgentEvent>(root),
            "enter_chat" => FillEvent<CallbackEnterChatEvent>(root),
            "location" => ParseLocationEvent(root),
            "click" => ParseClickEvent(root),
            "view" => ParseViewEvent(root),
            "scancode_push" or "scancode_waitmsg" => ParseScanCodeEvent(root),
            "pic_sysphoto" or "pic_photo_or_album" or "pic_weixin" => ParsePicEvent(root),
            "location_select" => ParseLocationSelectEvent(root),
            "template_card_event" => ParseTemplateCardEvent(root),
            "open_approval_change" => ParseApprovalChangeEvent(root),
            "batch_job_result" => ParseBatchJobEvent(root),
            "change_contact" => ParseChangeContactEvent(root),
            _ => FillEvent<CallbackEventBase>(root)
        };
    }

    private static CallbackLocationEvent ParseLocationEvent(XElement root)
    {
        var evt = FillEvent<CallbackLocationEvent>(root);
        evt.Latitude = GetDouble(root, "Latitude");
        evt.Longitude = GetDouble(root, "Longitude");
        evt.Precision = GetDouble(root, "Precision");
        return evt;
    }

    private static CallbackClickEvent ParseClickEvent(XElement root)
    {
        var evt = FillEvent<CallbackClickEvent>(root);
        evt.EventKey = root.Element("EventKey")?.Value ?? string.Empty;
        return evt;
    }

    private static CallbackViewEvent ParseViewEvent(XElement root)
    {
        var evt = FillEvent<CallbackViewEvent>(root);
        evt.EventKey = root.Element("EventKey")?.Value ?? string.Empty;
        return evt;
    }

    private static CallbackScanCodeEvent ParseScanCodeEvent(XElement root)
    {
        var evt = FillEvent<CallbackScanCodeEvent>(root);
        evt.EventKey = root.Element("EventKey")?.Value ?? string.Empty;
        var scanCodeInfo = root.Element("ScanCodeInfo");
        if (scanCodeInfo != null)
        {
            evt.ScanType = scanCodeInfo.Element("ScanType")?.Value;
            evt.ScanResult = scanCodeInfo.Element("ScanResult")?.Value;
        }
        return evt;
    }

    private static CallbackPicEvent ParsePicEvent(XElement root)
    {
        var evt = FillEvent<CallbackPicEvent>(root);
        evt.EventKey = root.Element("EventKey")?.Value ?? string.Empty;
        var sendPicsInfo = root.Element("SendPicsInfo");
        evt.Count = GetInt(sendPicsInfo, "Count");
        var picList = sendPicsInfo?.Element("PicList");
        if (picList != null)
        {
            evt.PicMd5Sums = picList.Elements("item")
                .Select(i => i.Element("PicMd5Sum")?.Value ?? string.Empty)
                .ToArray();
        }
        return evt;
    }

    private static CallbackLocationSelectEvent ParseLocationSelectEvent(XElement root)
    {
        var evt = FillEvent<CallbackLocationSelectEvent>(root);
        evt.EventKey = root.Element("EventKey")?.Value ?? string.Empty;
        var sendLocationInfo = root.Element("SendLocationInfo");
        if (sendLocationInfo != null)
        {
            evt.LocationX = GetDouble(sendLocationInfo, "Location_X");
            evt.LocationY = GetDouble(sendLocationInfo, "Location_Y");
            evt.Scale = GetInt(sendLocationInfo, "Scale");
            evt.Label = sendLocationInfo.Element("Label")?.Value ?? string.Empty;
            evt.PoiName = sendLocationInfo.Element("Poiname")?.Value;
        }
        return evt;
    }

    private static CallbackTemplateCardEvent ParseTemplateCardEvent(XElement root)
    {
        var evt = FillEvent<CallbackTemplateCardEvent>(root);
        evt.EventKey = root.Element("EventKey")?.Value ?? string.Empty;
        evt.TaskId = root.Element("TaskId")?.Value ?? string.Empty;
        evt.CardType = root.Element("CardType")?.Value;
        evt.ResponseCode = root.Element("ResponseCode")?.Value;
        var selectedItems = root.Element("SelectedItems");
        if (selectedItems != null)
        {
            evt.SelectedItems = selectedItems.Elements("SelectedItem")
                .Select(item => new TemplateCardSelectedItem
                {
                    QuestionKey = item.Element("QuestionKey")?.Value ?? string.Empty,
                    OptionIds = item.Elements("OptionIds")
                        .SelectMany(o => o.Elements("OptionId"))
                        .Select(o => o.Value)
                        .ToArray()
                })
                .ToArray();
        }
        return evt;
    }

    private static CallbackBatchJobEvent ParseBatchJobEvent(XElement root)
    {
        var evt = FillEvent<CallbackBatchJobEvent>(root);
        var batchJob = root.Element("BatchJob");
        if (batchJob != null)
        {
            evt.JobId = batchJob.Element("JobId")?.Value ?? string.Empty;
            evt.JobType = batchJob.Element("JobType")?.Value ?? string.Empty;
            evt.ErrCode = GetInt(batchJob, "ErrCode");
            evt.ErrMsg = batchJob.Element("ErrMsg")?.Value;
        }
        return evt;
    }

    // ─── 解析通讯录变更事件 ─────────────────────────────────────────────

    private static CallbackMessageBase ParseChangeContactEvent(XElement root)
    {
        var changeType = root.Element("ChangeType")?.Value ?? string.Empty;
        return changeType switch
        {
            "create_user" => ParseCreateUserEvent(root),
            "update_user" => ParseUpdateUserEvent(root),
            "delete_user" => ParseDeleteUserEvent(root),
            "create_party" => ParseCreatePartyEvent(root),
            "update_party" => ParseUpdatePartyEvent(root),
            "delete_party" => ParseDeletePartyEvent(root),
            "update_tag" => ParseUpdateTagEvent(root),
            _ => FillChangeContact<CallbackChangeContactEvent>(root)
        };
    }

    private static CallbackCreateUserEvent ParseCreateUserEvent(XElement root)
    {
        var evt = FillChangeContact<CallbackCreateUserEvent>(root);
        FillUserFields(evt, root);
        return evt;
    }

    private static CallbackUpdateUserEvent ParseUpdateUserEvent(XElement root)
    {
        var evt = FillChangeContact<CallbackUpdateUserEvent>(root);
        FillUserFields(evt, root);
        evt.NewUserID = root.Element("NewUserID")?.Value;
        return evt;
    }

    private static CallbackDeleteUserEvent ParseDeleteUserEvent(XElement root)
    {
        var evt = FillChangeContact<CallbackDeleteUserEvent>(root);
        evt.UserID = root.Element("UserID")?.Value ?? string.Empty;
        return evt;
    }

    private static void FillUserFields(CallbackCreateUserEvent evt, XElement root)
    {
        evt.UserID = root.Element("UserID")?.Value ?? string.Empty;
        evt.Name = root.Element("Name")?.Value;
        evt.Department = root.Element("Department")?.Value;
        evt.MainDepartment = GetInt(root, "MainDepartment");
        evt.IsLeaderInDept = root.Element("IsLeaderInDept")?.Value;
        evt.DirectLeader = root.Element("DirectLeader")?.Value;
        evt.Position = root.Element("Position")?.Value;
        evt.Mobile = root.Element("Mobile")?.Value;
        evt.Gender = GetInt(root, "Gender");
        evt.Email = root.Element("Email")?.Value;
        evt.BizMail = root.Element("BizMail")?.Value;
        evt.Status = GetInt(root, "Status");
        evt.Avatar = root.Element("Avatar")?.Value;
        evt.Alias = root.Element("Alias")?.Value;
        evt.Telephone = root.Element("Telephone")?.Value;
        evt.Address = root.Element("Address")?.Value;

        var extAttr = root.Element("ExtAttr");
        if (extAttr != null)
        {
            evt.ExtAttr = extAttr.Elements("Item")
                .Select(item =>
                {
                    var attr = new CallbackExtAttrItem
                    {
                        Name = item.Element("Name")?.Value ?? string.Empty,
                        Type = GetInt(item, "Type")
                    };
                    if (attr.Type == 0)
                    {
                        attr.Value = item.Element("Text")?.Element("Value")?.Value;
                    }
                    else if (attr.Type == 1)
                    {
                        var web = item.Element("Web");
                        attr.WebUrl = web?.Element("Url")?.Value;
                        attr.WebTitle = web?.Element("Title")?.Value;
                    }
                    return attr;
                })
                .ToArray();
        }
    }

    private static CallbackCreatePartyEvent ParseCreatePartyEvent(XElement root)
    {
        var evt = FillChangeContact<CallbackCreatePartyEvent>(root);
        evt.Id = GetInt(root, "Id");
        evt.Name = root.Element("Name")?.Value;
        evt.ParentId = GetInt(root, "ParentId");
        evt.Order = GetInt(root, "Order");
        return evt;
    }

    private static CallbackUpdatePartyEvent ParseUpdatePartyEvent(XElement root)
    {
        var evt = FillChangeContact<CallbackUpdatePartyEvent>(root);
        evt.Id = GetInt(root, "Id");
        evt.Name = root.Element("Name")?.Value;
        evt.ParentId = GetInt(root, "ParentId");
        evt.Order = GetInt(root, "Order");
        return evt;
    }

    private static CallbackDeletePartyEvent ParseDeletePartyEvent(XElement root)
    {
        var evt = FillChangeContact<CallbackDeletePartyEvent>(root);
        evt.Id = GetInt(root, "Id");
        return evt;
    }

    private static CallbackUpdateTagEvent ParseUpdateTagEvent(XElement root)
    {
        var evt = FillChangeContact<CallbackUpdateTagEvent>(root);
        evt.TagId = GetInt(root, "TagId");
        evt.AddUserItems = root.Element("AddUserItems")?.Value;
        evt.DelUserItems = root.Element("DelUserItems")?.Value;
        evt.AddPartyItems = root.Element("AddPartyItems")?.Value;
        evt.DelPartyItems = root.Element("DelPartyItems")?.Value;
        return evt;
    }

    private static T FillChangeContact<T>(XElement root) where T : CallbackChangeContactEvent, new()
    {
        var evt = FillEvent<T>(root);
        evt.ChangeType = root.Element("ChangeType")?.Value ?? string.Empty;
        return evt;
    }

    // ─── 解析审批回调 ──────────────────────────────────────────────────

    private static CallbackApprovalEvent ParseApprovalChangeEvent(XElement root)
    {
        var evt = FillEvent<CallbackApprovalEvent>(root);
        var approvalInfo = root.Element("ApprovalInfo");
        if (approvalInfo == null) return evt;

        evt.SpNo = approvalInfo.Element("SpNo")?.Value ?? string.Empty;
        evt.SpName = approvalInfo.Element("SpName")?.Value ?? string.Empty;
        evt.SpStatus = GetInt(approvalInfo, "SpStatus");
        evt.TemplateId = approvalInfo.Element("TemplateId")?.Value ?? string.Empty;
        evt.ApplyTime = GetLong(approvalInfo, "ApplyTime");
        evt.StatuChangeEvent = GetInt(approvalInfo, "StatuChangeEvent");

        var applyer = approvalInfo.Element("Applyer");
        if (applyer != null)
        {
            evt.ApplyerUserId = applyer.Element("UserId")?.Value ?? string.Empty;
            evt.ApplyerPartyId = applyer.Element("Party")?.Value ?? string.Empty;
        }

        var spRecordNodes = approvalInfo.Elements("SpRecord");
        evt.SpRecords = spRecordNodes.Select(record =>
        {
            var r = new CallbackApprovalSpRecord
            {
                SpStatus = GetInt(record, "SpStatus"),
                ApproverAttr = GetInt(record, "ApproverAttr")
            };
            r.Details = record.Elements("Details").Select(detail => new CallbackApprovalSpDetail
            {
                UserId = detail.Element("Approver")?.Element("UserId")?.Value ?? string.Empty,
                Speech = detail.Element("Speech")?.Value ?? string.Empty,
                SpStatus = GetInt(detail, "SpStatus"),
                SpTime = GetLong(detail, "SpTime")
            }).ToArray();
            return r;
        }).ToArray();

        var notifyerNodes = approvalInfo.Elements("Notifyer");
        evt.NotifyerUserIds = notifyerNodes
            .Select(n => n.Element("UserId")?.Value ?? string.Empty)
            .Where(u => !string.IsNullOrEmpty(u))
            .ToArray();

        var commentNodes = approvalInfo.Elements("Comments");
        evt.Comments = commentNodes.Select(c => new CallbackApprovalComment
        {
            UserId = c.Element("CommentUserInfo")?.Element("UserId")?.Value ?? string.Empty,
            CommentTime = GetLong(c, "CommentTime"),
            Content = c.Element("CommentContent")?.Value ?? string.Empty,
            CommentId = c.Element("CommentId")?.Value ?? string.Empty
        }).ToArray();

        return evt;
    }

    // ─── 解析辅助方法 ──────────────────────────────────────────────────

    private static CallbackMessageBase ParseBase(XElement root, string msgType)
    {
        var msg = FillBase<CallbackMessageBase>(root);
        msg.MsgType = msgType;
        return msg;
    }

    private static T FillBase<T>(XElement root) where T : CallbackMessageBase, new()
    {
        return new T
        {
            ToUserName = root.Element("ToUserName")?.Value ?? string.Empty,
            FromUserName = root.Element("FromUserName")?.Value ?? string.Empty,
            CreateTime = GetLong(root, "CreateTime"),
            MsgType = root.Element("MsgType")?.Value ?? string.Empty,
            AgentID = GetInt(root, "AgentID")
        };
    }

    private static T FillEvent<T>(XElement root) where T : CallbackEventBase, new()
    {
        var evt = FillBase<T>(root);
        evt.Event = root.Element("Event")?.Value ?? string.Empty;
        return evt;
    }

    private static long GetLong(XElement? root, string name)
        => long.TryParse(root?.Element(name)?.Value, out var v) ? v : 0;

    private static int GetInt(XElement? root, string name)
        => int.TryParse(root?.Element(name)?.Value, out var v) ? v : 0;

    private static double GetDouble(XElement? root, string name)
        => double.TryParse(root?.Element(name)?.Value, out var v) ? v : 0;
}

