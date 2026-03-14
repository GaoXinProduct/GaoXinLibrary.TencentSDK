namespace GaoXinLibrary.TencentSDK.Wecom.Models.Approval;

/// <summary>
/// 审批申请构建器
/// <para>
/// 通过链式调用快速构建 <see cref="ApplyEventRequest"/>，无需手动拼装嵌套数据结构。
/// <code>
/// var spNo = await approval.ApplyEventAsync(b => b
///     .SetCreator("zhangsan")
///     .SetTemplate("3TkZjxugodbqpEMk5bRCFTHEHidgwegDnhVj4")
///     .UseTemplateApprover()
///     .AddText("Text-1", "出差事由：拜访客户")
///     .AddNumber("Number-1", "2")
///     .AddDate("Date-1", "day", DateTimeOffset.Now)
///     .AddSummary("出差申请", "张三", "2天"));
/// </code>
/// </para>
/// </summary>
public class ApplyEventBuilder
{
    private readonly ApplyEventRequest _request = new();
    private readonly List<ApplyContent> _contents = [];

    /// <summary>设置申请人 userid</summary>
    public ApplyEventBuilder SetCreator(string userId)
    {
        _request.CreatorUserId = userId;
        return this;
    }

    /// <summary>设置审批模板 id</summary>
    public ApplyEventBuilder SetTemplate(string templateId)
    {
        _request.TemplateId = templateId;
        return this;
    }

    /// <summary>使用模板在管理后台配置的审批流程（use_template_approver = 1）</summary>
    public ApplyEventBuilder UseTemplateApprover()
    {
        _request.UseTemplateApprover = 1;
        return this;
    }

    /// <summary>
    /// 通过接口指定审批人（use_template_approver = 0）
    /// </summary>
    /// <param name="attr">审批方式：1-或签 2-会签</param>
    /// <param name="userIds">审批人 userid 列表</param>
    public ApplyEventBuilder AddApprover(int attr, params string[] userIds)
    {
        _request.UseTemplateApprover = 0;
        var list = _request.Approver?.ToList() ?? [];
        list.Add(new ApprovalApprover { Attr = attr, UserId = userIds });
        _request.Approver = [.. list];
        return this;
    }

    /// <summary>添加抄送人</summary>
    /// <param name="userIds">抄送人 userid 列表</param>
    public ApplyEventBuilder AddNotifyer(params string[] userIds)
    {
        var list = _request.Notifyer?.ToList() ?? [];
        list.AddRange(userIds);
        _request.Notifyer = [.. list];
        return this;
    }

    /// <summary>设置抄送方式</summary>
    /// <param name="notifyType">1-提单时 2-单据通过后 3-提单和通过后</param>
    public ApplyEventBuilder SetNotifyType(int notifyType)
    {
        _request.NotifyType = notifyType;
        return this;
    }

    /// <summary>设置选择的审批人所在部门</summary>
    public ApplyEventBuilder SetChooseDepartment(long departmentId)
    {
        _request.ChooseDepartment = departmentId;
        return this;
    }

    // ─── 控件值设置 ──────────────────────────────────────────────────────

    /// <summary>添加文本控件（Text / Textarea）</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="text">文本值</param>
    public ApplyEventBuilder AddText(string controlId, string text)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Text",
            Id = controlId,
            Value = new ApplyContentValue { Text = text }
        });
        return this;
    }

    /// <summary>添加多行文本控件</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="text">文本值</param>
    public ApplyEventBuilder AddTextarea(string controlId, string text)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Textarea",
            Id = controlId,
            Value = new ApplyContentValue { Text = text }
        });
        return this;
    }

    /// <summary>添加数字控件</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="number">数字值（字符串表示）</param>
    public ApplyEventBuilder AddNumber(string controlId, string number)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Number",
            Id = controlId,
            Value = new ApplyContentValue { NewNumber = number }
        });
        return this;
    }

    /// <summary>添加金额控件</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="money">金额值（字符串表示）</param>
    public ApplyEventBuilder AddMoney(string controlId, string money)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Money",
            Id = controlId,
            Value = new ApplyContentValue { NewMoney = money }
        });
        return this;
    }

    /// <summary>添加日期控件</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="type">日期类型：day / hour</param>
    /// <param name="dateTime">日期时间</param>
    public ApplyEventBuilder AddDate(string controlId, string type, DateTimeOffset dateTime)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Date",
            Id = controlId,
            Value = new ApplyContentValue
            {
                Date = new ApplyDateValue
                {
                    Type = type,
                    STimestamp = dateTime.ToUnixTimeSeconds().ToString()
                }
            }
        });
        return this;
    }

    /// <summary>添加日期范围控件</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="type">日期类型：halfday / hour</param>
    /// <param name="begin">开始时间</param>
    /// <param name="end">结束时间</param>
    /// <param name="duration">时长（秒），不传时由服务端计算</param>
    public ApplyEventBuilder AddDateRange(string controlId, string type, DateTimeOffset begin, DateTimeOffset end, long? duration = null)
    {
        _contents.Add(new ApplyContent
        {
            Control = "DateRange",
            Id = controlId,
            Value = new ApplyContentValue
            {
                DateRange = new ApplyDateRangeValue
                {
                    Type = type,
                    NewBegin = begin.ToUnixTimeSeconds(),
                    NewEnd = end.ToUnixTimeSeconds(),
                    NewDuration = duration
                }
            }
        });
        return this;
    }

    /// <summary>添加单选/多选控件</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="type">选择器类型：single / multi</param>
    /// <param name="optionKeys">选中的选项 key 列表</param>
    public ApplyEventBuilder AddSelector(string controlId, string type, params string[] optionKeys)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Selector",
            Id = controlId,
            Value = new ApplyContentValue
            {
                Selector = new ApplySelectorValue
                {
                    Type = type,
                    Options = optionKeys.Select(k => new ApplySelectorOption { Key = k }).ToArray()
                }
            }
        });
        return this;
    }

    /// <summary>添加成员联系人控件</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="userIds">成员 userid 列表</param>
    public ApplyEventBuilder AddMembers(string controlId, params string[] userIds)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Contact",
            Id = controlId,
            Value = new ApplyContentValue
            {
                Members = userIds.Select(u => new ApplyMember { UserId = u }).ToArray()
            }
        });
        return this;
    }

    /// <summary>添加部门联系人控件</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="departmentIds">部门 openapi_id 列表</param>
    public ApplyEventBuilder AddDepartments(string controlId, params string[] departmentIds)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Contact",
            Id = controlId,
            Value = new ApplyContentValue
            {
                Departments = departmentIds.Select(d => new ApplyDepartment { OpenApiId = d }).ToArray()
            }
        });
        return this;
    }

    /// <summary>添加附件控件</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="fileIds">文件 id 列表（通过上传临时素材获取）</param>
    public ApplyEventBuilder AddFiles(string controlId, params string[] fileIds)
    {
        _contents.Add(new ApplyContent
        {
            Control = "File",
            Id = controlId,
            Value = new ApplyContentValue
            {
                Files = fileIds.Select(f => new ApplyFile { FileId = f }).ToArray()
            }
        });
        return this;
    }

    /// <summary>添加位置控件</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="latitude">纬度</param>
    /// <param name="longitude">经度</param>
    /// <param name="title">位置名称</param>
    /// <param name="address">位置地址</param>
    /// <param name="time">选择地点的时间（Unix 时间戳）</param>
    public ApplyEventBuilder AddLocation(string controlId, string latitude, string longitude, string title, string? address = null, long? time = null)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Location",
            Id = controlId,
            Value = new ApplyContentValue
            {
                Location = new ApplyLocationValue
                {
                    Latitude = latitude,
                    Longitude = longitude,
                    Title = title,
                    Address = address,
                    Time = time
                }
            }
        });
        return this;
    }

    /// <summary>添加明细控件（Table）</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="rows">每行的明细内容列表</param>
    public ApplyEventBuilder AddTable(string controlId, params ApplyContent[][] rows)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Table",
            Id = controlId,
            Value = new ApplyContentValue { Children = rows }
        });
        return this;
    }

    /// <summary>添加假勤组件-请假（Vacation）</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="vacationTypeKey">假期类型选项 key（对应假期管理中的假期类型 id）</param>
    /// <param name="dateRangeType">时长粒度：halfday / hour</param>
    /// <param name="begin">开始时间</param>
    /// <param name="end">结束时间</param>
    /// <param name="duration">时长（秒），不传时由服务端计算</param>
    public ApplyEventBuilder AddVacation(string controlId, string vacationTypeKey, string dateRangeType, DateTimeOffset begin, DateTimeOffset end, long? duration = null)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Vacation",
            Id = controlId,
            Value = new ApplyContentValue
            {
                Vacation = new ApplyVacationValue
                {
                    Selector = new ApplySelectorValue
                    {
                        Type = "single",
                        Options = [new ApplySelectorOption { Key = vacationTypeKey }]
                    },
                    Attendance = new ApplyAttendanceValue
                    {
                        DateRange = new ApplyDateRangeValue
                        {
                            Type = dateRangeType,
                            NewBegin = begin.ToUnixTimeSeconds(),
                            NewEnd = end.ToUnixTimeSeconds(),
                            NewDuration = duration
                        },
                        Type = 1
                    }
                }
            }
        });
        return this;
    }

    /// <summary>添加假勤组件-出差/外出/加班（Attendance）</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="attendanceType">假勤组件类型：1-请假；3-出差；4-外出；5-加班</param>
    /// <param name="dateRangeType">时长粒度：halfday / hour</param>
    /// <param name="begin">开始时间</param>
    /// <param name="end">结束时间</param>
    /// <param name="duration">时长（秒），当有 sliceInfo 时可不传</param>
    /// <param name="sliceInfo">时长分片信息（非必填）</param>
    public ApplyEventBuilder AddAttendance(string controlId, int attendanceType, string dateRangeType, DateTimeOffset begin, DateTimeOffset end, long? duration = null, ApplySliceInfo? sliceInfo = null)
    {
        _contents.Add(new ApplyContent
        {
            Control = "Attendance",
            Id = controlId,
            Value = new ApplyContentValue
            {
                Attendance = new ApplyAttendanceValue
                {
                    DateRange = new ApplyDateRangeValue
                    {
                        Type = dateRangeType,
                        NewBegin = begin.ToUnixTimeSeconds(),
                        NewEnd = end.ToUnixTimeSeconds(),
                        NewDuration = duration
                    },
                    Type = attendanceType,
                    SliceInfo = sliceInfo
                }
            }
        });
        return this;
    }

    /// <summary>添加关联审批单控件（RelatedApproval）</summary>
    /// <param name="controlId">控件 id</param>
    /// <param name="spNos">关联的审批单号列表</param>
    public ApplyEventBuilder AddRelatedApproval(string controlId, params string[] spNos)
    {
        _contents.Add(new ApplyContent
        {
            Control = "RelatedApproval",
            Id = controlId,
            Value = new ApplyContentValue
            {
                RelatedApproval = spNos.Select(s => new ApplyRelatedApprovalItem { SpNo = s }).ToArray()
            }
        });
        return this;
    }

    /// <summary>
    /// 直接添加原始控件内容（用于 Builder 未覆盖的控件类型）
    /// </summary>
    public ApplyEventBuilder AddContent(ApplyContent content)
    {
        _contents.Add(content);
        return this;
    }

    /// <summary>添加摘要信息（最多 3 行，每行最多 20 字符）</summary>
    /// <param name="summaryLines">摘要行内容</param>
    public ApplyEventBuilder AddSummary(params string[] summaryLines)
    {
        _request.SummaryList = summaryLines
            .Select(line => new ApprovalSummary
            {
                SummaryInfo = [new ApprovalText { Text = line, Lang = "zh_CN" }]
            })
            .ToArray();
        return this;
    }

    /// <summary>构建审批申请请求</summary>
    public ApplyEventRequest Build()
    {
        _request.ApplyData = new ApplyData { Contents = [.. _contents] };
        return _request;
    }
}
