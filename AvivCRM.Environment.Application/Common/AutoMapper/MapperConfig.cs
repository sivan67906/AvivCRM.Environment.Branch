using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Application.DTOs.CustomQuestionPositions;
using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Application.DTOs.NotificationMains;
using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Application.DTOs.Timesheets;
using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Application.Common.AutoMapper;
public class MapperConfig : Profile
{
    public MapperConfig()
    {
        // LeadSource
        CreateMap<CreateLeadSourceRequest, LeadSource>();
        CreateMap<UpdateLeadSourceRequest, LeadSource>();
        CreateMap<LeadSource, GetLeadSource>();

        // ProjectCategory
        CreateMap<CreateProjectCategoryRequest, ProjectCategory>();
        CreateMap<UpdateProjectCategoryRequest, ProjectCategory>();
        CreateMap<ProjectCategory, GetProjectCategory>();

        // ProjectReminderPerson
        CreateMap<CreateProjectReminderPersonRequest, ProjectReminderPerson>();
        CreateMap<UpdateProjectReminderPersonRequest, ProjectReminderPerson>();
        CreateMap<ProjectReminderPerson, GetProjectReminderPerson>();

        // TicketAgent
        CreateMap<CreateTicketAgentRequest, TicketAgent>();
        CreateMap<UpdateTicketAgentRequest, TicketAgent>();
        CreateMap<TicketAgent, GetTicketAgent>();

        CreateMap<CreateTicketAgentRequest, TicketAgent>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketAgentName));
        CreateMap<TicketAgent, CreateTicketAgentRequest>()
            .ForMember(dest => dest.TicketAgentName, opt => opt.MapFrom(src => src.Name));

        CreateMap<UpdateTicketAgentRequest, TicketAgent>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketAgentName));
        CreateMap<TicketAgent, UpdateTicketAgentRequest>()
            .ForMember(dest => dest.TicketAgentName, opt => opt.MapFrom(src => src.Name));

        CreateMap<TicketAgent, GetTicketAgent>()
            .ForMember(dest => dest.TicketAgentName, opt => opt.MapFrom(src => src.Name));
        CreateMap<GetTicketAgent, TicketAgent>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketAgentName));

        // TicketChannel
        CreateMap<CreateTicketChannelRequest, TicketChannel>();
        CreateMap<UpdateTicketChannelRequest, TicketChannel>();
        CreateMap<TicketChannel, GetTicketChannel>();

        CreateMap<CreateTicketChannelRequest, TicketAgent>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketChannelName));
        CreateMap<TicketAgent, CreateTicketChannelRequest>()
            .ForMember(dest => dest.TicketChannelName, opt => opt.MapFrom(src => src.Name));

        CreateMap<UpdateTicketChannelRequest, TicketAgent>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketChannelName));
        CreateMap<TicketAgent, UpdateTicketChannelRequest>()
            .ForMember(dest => dest.TicketChannelName, opt => opt.MapFrom(src => src.Name));

        CreateMap<TicketAgent, GetTicketChannel>()
            .ForMember(dest => dest.TicketChannelName, opt => opt.MapFrom(src => src.Name));
        CreateMap<GetTicketChannel, TicketAgent>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketChannelName));

        // TicketGroup
        CreateMap<CreateTicketGroupRequest, TicketGroup>();
        CreateMap<UpdateTicketGroupRequest, TicketGroup>();
        CreateMap<TicketGroup, GetTicketGroup>();

        CreateMap<CreateTicketGroupRequest, TicketGroup>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketGroupName));
        CreateMap<TicketGroup, CreateTicketGroupRequest>()
            .ForMember(dest => dest.TicketGroupName, opt => opt.MapFrom(src => src.Name));

        CreateMap<UpdateTicketGroupRequest, TicketGroup>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketGroupName));
        CreateMap<TicketGroup, UpdateTicketGroupRequest>()
            .ForMember(dest => dest.TicketGroupName, opt => opt.MapFrom(src => src.Name));

        CreateMap<GetTicketGroup, TicketGroup>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketGroupName));
        CreateMap<TicketGroup, GetTicketGroup>()
            .ForMember(dest => dest.TicketGroupName, opt => opt.MapFrom(src => src.Name));


        // TicketReplyTemplate
        CreateMap<CreateTicketReplyTemplateRequest, TicketReplyTemplate>();
        CreateMap<UpdateTicketReplyTemplateRequest, TicketReplyTemplate>();
        CreateMap<TicketReplyTemplate, GetTicketReplyTemplate>();

        // TicketType
        CreateMap<CreateTicketTypeRequest, TicketType>();
        CreateMap<UpdateTicketTypeRequest, TicketType>();
        CreateMap<TicketType, GetTicketType>();

        CreateMap<CreateTicketTypeRequest, TicketType>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketTypeName));
        CreateMap<TicketType, CreateTicketTypeRequest>()
            .ForMember(dest => dest.TicketTypeName, opt => opt.MapFrom(src => src.Name));

        CreateMap<UpdateTicketTypeRequest, TicketType>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketTypeName));
        CreateMap<TicketType, UpdateTicketTypeRequest>()
            .ForMember(dest => dest.TicketTypeName, opt => opt.MapFrom(src => src.Name));

        CreateMap<TicketType, GetTicketType>()
            .ForMember(dest => dest.TicketTypeName, opt => opt.MapFrom(src => src.Name));
        CreateMap<GetTicketType, TicketType>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TicketTypeName));

        // FinanceInvoiceTemplateSetting
        CreateMap<CreateFinanceInvoiceTemplateSettingRequest, FinanceInvoiceTemplateSetting>();
        CreateMap<UpdateFinanceInvoiceTemplateSettingRequest, FinanceInvoiceTemplateSetting>();
        CreateMap<FinanceInvoiceTemplateSetting, GetFinanceInvoiceTemplateSetting>();

        // FinancePrefixSetting
        CreateMap<CreateFinancePrefixSettingRequest, FinancePrefixSetting>();
        CreateMap<UpdateFinancePrefixSettingRequest, FinancePrefixSetting>();
        CreateMap<FinancePrefixSetting, GetFinancePrefixSetting>();

        // FinanceUnitSetting
        CreateMap<CreateFinanceUnitSettingRequest, FinanceUnitSetting>();
        CreateMap<UpdateFinanceUnitSettingRequest, FinanceUnitSetting>();
        CreateMap<FinanceUnitSetting, GetFinanceUnitSetting>();

        CreateMap<CreateFinanceUnitSettingRequest, FinanceUnitSetting>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FUnitName))
            .ForMember(dest => dest.IsDefault, opt => opt.MapFrom(src => src.FIsDefault));
        CreateMap<FinanceUnitSetting, CreateFinanceUnitSettingRequest>()
            .ForMember(dest => dest.FUnitName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FIsDefault, opt => opt.MapFrom(src => src.IsDefault));

        CreateMap<UpdateFinanceUnitSettingRequest, FinanceUnitSetting>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FUnitName))
            .ForMember(dest => dest.IsDefault, opt => opt.MapFrom(src => src.FIsDefault));
        CreateMap<FinanceUnitSetting, UpdateFinanceUnitSettingRequest>()
            .ForMember(dest => dest.FUnitName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FIsDefault, opt => opt.MapFrom(src => src.IsDefault));

        CreateMap<FinanceUnitSetting, GetFinanceUnitSetting>()
            .ForMember(dest => dest.FUnitName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FIsDefault, opt => opt.MapFrom(src => src.IsDefault));
        CreateMap<GetFinanceUnitSetting, FinanceUnitSetting>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FUnitName))
            .ForMember(dest => dest.IsDefault, opt => opt.MapFrom(src => src.FIsDefault));

        // RecruitNotificationSetting
        CreateMap<CreateRecruitNotificationSettingRequest, RecruitNotificationSetting>();
        CreateMap<UpdateRecruitNotificationSettingRequest, RecruitNotificationSetting>();
        CreateMap<RecruitNotificationSetting, GetRecruitNotificationSetting>();

        // LeadStatus
        CreateMap<CreateLeadStatusRequest, LeadStatus>();
        CreateMap<UpdateLeadStatusRequest, LeadStatus>();
        CreateMap<LeadStatus, GetLeadStatus>();
        // Contract
        CreateMap<CreateContractRequest, Contract>();
        CreateMap<UpdateContractRequest, Contract>();
        CreateMap<Contract, GetContract>();
        // LeadAgent
        CreateMap<CreateLeadAgentRequest, LeadAgent>();
        CreateMap<UpdateLeadAgentRequest, LeadAgent>();
        CreateMap<LeadAgent, GetLeadAgent>();
        // LeadCategory
        CreateMap<CreateLeadCategoryRequest, LeadCategory>();
        CreateMap<UpdateLeadCategoryRequest, LeadCategory>();
        CreateMap<LeadCategory, GetLeadCategory>();

        // CustomQuestionCategory
        CreateMap<CreateCustomQuestionCategoryRequest, CustomQuestionCategory>();
        CreateMap<UpdateCustomQuestionCategoryRequest, CustomQuestionCategory>();
        CreateMap<CustomQuestionCategory, GetCustomQuestionCategory>();

        CreateMap<CreateCustomQuestionCategoryRequest, CustomQuestionCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CQCategoryName));
        CreateMap<CustomQuestionCategory, CreateCustomQuestionCategoryRequest>()
            .ForMember(dest => dest.CQCategoryName, opt => opt.MapFrom(src => src.Name));

        CreateMap<UpdateCustomQuestionCategoryRequest, CustomQuestionCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CQCategoryName));
        CreateMap<CustomQuestionCategory, UpdateCustomQuestionCategoryRequest>()
            .ForMember(dest => dest.CQCategoryName, opt => opt.MapFrom(src => src.Name));

        CreateMap<CustomQuestionCategory, GetCustomQuestionCategory>()
            .ForMember(dest => dest.CQCategoryName, opt => opt.MapFrom(src => src.Name));
        CreateMap<GetCustomQuestionCategory, CustomQuestionCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CQCategoryName));


        // CustomQuestionType
        CreateMap<CreateCustomQuestionTypeRequest, CustomQuestionType>();
        CreateMap<UpdateCustomQuestionTypeRequest, CustomQuestionType>();
        CreateMap<CustomQuestionType, GetCustomQuestionType>();

        CreateMap<CreateCustomQuestionTypeRequest, CustomQuestionType>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CQTypeName));
        CreateMap<CustomQuestionType, CreateCustomQuestionTypeRequest>()
            .ForMember(dest => dest.CQTypeName, opt => opt.MapFrom(src => src.Name));

        CreateMap<UpdateCustomQuestionTypeRequest, CustomQuestionType>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CQTypeName));
        CreateMap<CustomQuestionType, UpdateCustomQuestionTypeRequest>()
            .ForMember(dest => dest.CQTypeName, opt => opt.MapFrom(src => src.Name));

        CreateMap<CustomQuestionType, GetCustomQuestionType>()
            .ForMember(dest => dest.CQTypeName, opt => opt.MapFrom(src => src.Name));
        CreateMap<GetCustomQuestionType, CustomQuestionType>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CQTypeName));

        // JobApplicationCategory
        CreateMap<CreateJobApplicationCategoryRequest, JobApplicationCategory>();
        CreateMap<UpdateJobApplicationCategoryRequest, JobApplicationCategory>();
        CreateMap<JobApplicationCategory, GetJobApplicationCategory>();

        CreateMap<CreateJobApplicationCategoryRequest, JobApplicationCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.JACategoryName));
        CreateMap<JobApplicationCategory, CreateJobApplicationCategoryRequest>()
            .ForMember(dest => dest.JACategoryName, opt => opt.MapFrom(src => src.Name));

        CreateMap<UpdateJobApplicationCategoryRequest, JobApplicationCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.JACategoryName));
        CreateMap<JobApplicationCategory, UpdateJobApplicationCategoryRequest>()
            .ForMember(dest => dest.JACategoryName, opt => opt.MapFrom(src => src.Name));

        CreateMap<JobApplicationCategory, GetJobApplicationCategory>()
            .ForMember(dest => dest.JACategoryName, opt => opt.MapFrom(src => src.Name));
        CreateMap<GetJobApplicationCategory, JobApplicationCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.JACategoryName));

        // CustomQuestionPosition
        CreateMap<CreateCustomQuestionPositionRequest, CustomQuestionPosition>();
        CreateMap<UpdateCustomQuestionPositionRequest, CustomQuestionPosition>();
        CreateMap<CustomQuestionPosition, GetCustomQuestionPosition>();

        // NotificationMain
        CreateMap<CreateNotificationMainRequest, NotificationMain>();
        CreateMap<UpdateNotificationMainRequest, NotificationMain>();
        CreateMap<NotificationMain, GetNotificationMain>();

        // ProjectSetting
        CreateMap<CreateProjectSettingRequest, ProjectSetting>();
        CreateMap<UpdateProjectSettingRequest, ProjectSetting>();
        CreateMap<ProjectSetting, GetProjectSetting>();

        // ProjectStatus
        CreateMap<CreateProjectStatusRequest, ProjectStatus>();
        CreateMap<UpdateProjectStatusRequest, ProjectStatus>();
        CreateMap<ProjectStatus, GetProjectStatus>();

        // RecruitCustomQuestionSetting
        CreateMap<CreateRecruitCustomQuestionSettingRequest, RecruitCustomQuestionSetting>();
        CreateMap<UpdateRecruitCustomQuestionSettingRequest, RecruitCustomQuestionSetting>();
        CreateMap<RecruitCustomQuestionSetting, GetRecruitCustomQuestionSetting>();

        // RecruitFooterSetting
        CreateMap<CreateRecruitFooterSettingRequest, RecruitFooterSetting>();
        CreateMap<UpdateRecruitFooterSettingRequest, RecruitFooterSetting>();
        CreateMap<RecruitFooterSetting, GetRecruitFooterSetting>();

        // RecruitGeneralSetting
        CreateMap<CreateRecruitGeneralSettingRequest, RecruitGeneralSetting>();
        CreateMap<UpdateRecruitGeneralSettingRequest, RecruitGeneralSetting>();
        CreateMap<RecruitGeneralSetting, GetRecruitGeneralSetting>();

        // RecruitJobApplicationStatusSetting
        CreateMap<CreateRecruitJobApplicationStatusSettingRequest, RecruitJobApplicationStatusSetting>();
        CreateMap<UpdateRecruitJobApplicationStatusSettingRequest, RecruitJobApplicationStatusSetting>();
        CreateMap<RecruitJobApplicationStatusSetting, GetRecruitJobApplicationStatusSetting>();

        // RecruiterSetting
        CreateMap<CreateRecruiterSettingRequest, RecruiterSetting>();
        CreateMap<UpdateRecruiterSettingRequest, RecruiterSetting>();
        CreateMap<RecruiterSetting, GetRecruiterSetting>();

        // TimeLog
        CreateMap<CreateTimeLogRequest, TimeLog>();
        CreateMap<UpdateTimeLogRequest, TimeLog>();
        CreateMap<TimeLog, GetTimeLog>();

        // Timesheet
        CreateMap<CreateTimesheetRequest, Timesheet>();
        CreateMap<UpdateTimesheetRequest, Timesheet>();
        CreateMap<Timesheet, GetTimesheet>();
    }
}