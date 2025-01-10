#region

using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Applications;
using AvivCRM.Environment.Application.DTOs.AttendanceSettings;
using AvivCRM.Environment.Application.DTOs.Clients;
using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Application.DTOs.Currencies;
using AvivCRM.Environment.Application.DTOs.CustomQuestionCategories;
using AvivCRM.Environment.Application.DTOs.CustomQuestionTypes;
using AvivCRM.Environment.Application.DTOs.Employees;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceSettings;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Application.DTOs.JobApplicationCategories;
using AvivCRM.Environment.Application.DTOs.JobApplicationPositions;
using AvivCRM.Environment.Application.DTOs.Languages;
using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Application.DTOs.Messages;
using AvivCRM.Environment.Application.DTOs.NotificationMains;
using AvivCRM.Environment.Application.DTOs.Notifications;
using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Application.DTOs.Plannings;
using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Application.DTOs.ProjectSettings;
using AvivCRM.Environment.Application.DTOs.ProjectStatuses;
using AvivCRM.Environment.Application.DTOs.PurchaseSettings;
using AvivCRM.Environment.Application.DTOs.RecruitCustomQuestionSettings;
using AvivCRM.Environment.Application.DTOs.RecruiterSettings;
using AvivCRM.Environment.Application.DTOs.RecruitFooterSettings;
using AvivCRM.Environment.Application.DTOs.RecruitGeneralSettings;
using AvivCRM.Environment.Application.DTOs.RecruitJobApplicationStatusSettings;
using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Application.DTOs.Taskss;
using AvivCRM.Environment.Application.DTOs.Taxes;
using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Application.DTOs.TicketTypes;
using AvivCRM.Environment.Application.DTOs.TimeLogs;
using AvivCRM.Environment.Application.DTOs.Timesheets;
using AvivCRM.Environment.Application.DTOs.ToggleValues;
using AvivCRM.Environment.Domain.Entities;

#endregion

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

        // TicketChannel
        CreateMap<CreateTicketChannelRequest, TicketChannel>();
        CreateMap<UpdateTicketChannelRequest, TicketChannel>();
        CreateMap<TicketChannel, GetTicketChannel>();

        // TicketGroup
        CreateMap<CreateTicketGroupRequest, TicketGroup>();
        CreateMap<UpdateTicketGroupRequest, TicketGroup>();
        CreateMap<TicketGroup, GetTicketGroup>();

        // TicketReplyTemplate
        CreateMap<CreateTicketReplyTemplateRequest, TicketReplyTemplate>();
        CreateMap<UpdateTicketReplyTemplateRequest, TicketReplyTemplate>();
        CreateMap<TicketReplyTemplate, GetTicketReplyTemplate>();

        // TicketType
        CreateMap<CreateTicketTypeRequest, TicketType>();
        CreateMap<UpdateTicketTypeRequest, TicketType>();
        CreateMap<TicketType, GetTicketType>();

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

        // JobApplicationPosition
        CreateMap<CreateJobApplicationPositionRequest, JobApplicationPosition>();
        CreateMap<UpdateJobApplicationPositionRequest, JobApplicationPosition>();
        CreateMap<JobApplicationPosition, GetJobApplicationPosition>();

        CreateMap<CreateJobApplicationPositionRequest, JobApplicationPosition>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.JAPositionName));
        CreateMap<JobApplicationPosition, CreateJobApplicationPositionRequest>()
            .ForMember(dest => dest.JAPositionName, opt => opt.MapFrom(src => src.Name));

        CreateMap<UpdateJobApplicationPositionRequest, JobApplicationPosition>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.JAPositionName));
        CreateMap<JobApplicationPosition, UpdateJobApplicationPositionRequest>()
            .ForMember(dest => dest.JAPositionName, opt => opt.MapFrom(src => src.Name));

        CreateMap<JobApplicationPosition, GetJobApplicationPosition>()
            .ForMember(dest => dest.JAPositionName, opt => opt.MapFrom(src => src.Name));
        CreateMap<GetJobApplicationPosition, JobApplicationPosition>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.JAPositionName));


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

        // RecruitGeneralSetting
        CreateMap<CreateRecruitGeneralSettingRequest, RecruitGeneralSetting>();
        CreateMap<UpdateRecruitGeneralSettingRequest, RecruitGeneralSetting>();
        CreateMap<RecruitGeneralSetting, GetRecruitGeneralSetting>();

        CreateMap<CreateRecruitGeneralSettingRequest, RecruitGeneralSetting>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GeneralCompanyName))
            .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.GeneralCompanyWebsite))
            .ForMember(dest => dest.Logo, opt => opt.MapFrom(src => src.GeneralCompanyLogo))
            .ForMember(dest => dest.LogoPath, opt => opt.MapFrom(src => src.GeneralCompanyLogoPath))
            .ForMember(dest => dest.LogoImageFileName, opt => opt.MapFrom(src => src.GeneralCompanyLogoImageFileName))
            .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.GeneralAboutCompany))
            .ForMember(dest => dest.LegalTerm, opt => opt.MapFrom(src => src.GeneralLegalTerm))
            .ForMember(dest => dest.DuplJobApplnRestrictDays, opt => opt.MapFrom(src => src.GeneralDuplJobApplnRestrictDays))
            .ForMember(dest => dest.OLReminderToCandidate, opt => opt.MapFrom(src => src.GeneralOLReminderToCandidate))
            .ForMember(dest => dest.BGLogo, opt => opt.MapFrom(src => src.GeneralBGLogo))
            .ForMember(dest => dest.BGLogoPath, opt => opt.MapFrom(src => src.GeneralBGLogoPath))
            .ForMember(dest => dest.BGLogoImageFileName, opt => opt.MapFrom(src => src.GeneralBGLogoImageFileName))
            .ForMember(dest => dest.BGColorCode, opt => opt.MapFrom(src => src.GeneralBGColorCode))
            .ForMember(dest => dest.CBJsonSettings, opt => opt.MapFrom(src => src.GeneralCBJsonSettings));
        CreateMap<RecruitGeneralSetting, CreateRecruitGeneralSettingRequest>()
            .ForMember(dest => dest.GeneralCompanyName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.GeneralCompanyWebsite, opt => opt.MapFrom(src => src.Website))
            .ForMember(dest => dest.GeneralCompanyLogo, opt => opt.MapFrom(src => src.Logo))
            .ForMember(dest => dest.GeneralCompanyLogoPath, opt => opt.MapFrom(src => src.LogoPath))
            .ForMember(dest => dest.GeneralCompanyLogoImageFileName, opt => opt.MapFrom(src => src.LogoImageFileName))
            .ForMember(dest => dest.GeneralAboutCompany, opt => opt.MapFrom(src => src.About))
            .ForMember(dest => dest.GeneralLegalTerm, opt => opt.MapFrom(src => src.LegalTerm))
            .ForMember(dest => dest.GeneralDuplJobApplnRestrictDays, opt => opt.MapFrom(src => src.DuplJobApplnRestrictDays))
            .ForMember(dest => dest.GeneralOLReminderToCandidate, opt => opt.MapFrom(src => src.OLReminderToCandidate))
            .ForMember(dest => dest.GeneralBGLogo, opt => opt.MapFrom(src => src.BGLogo))
            .ForMember(dest => dest.GeneralBGLogoPath, opt => opt.MapFrom(src => src.BGLogoPath))
            .ForMember(dest => dest.GeneralBGLogoImageFileName, opt => opt.MapFrom(src => src.BGLogoImageFileName))
            .ForMember(dest => dest.GeneralBGColorCode, opt => opt.MapFrom(src => src.BGColorCode))
            .ForMember(dest => dest.GeneralCBJsonSettings, opt => opt.MapFrom(src => src.CBJsonSettings));

        CreateMap<UpdateRecruitGeneralSettingRequest, RecruitGeneralSetting>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GeneralCompanyName))
            .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.GeneralCompanyWebsite))
            .ForMember(dest => dest.Logo, opt => opt.MapFrom(src => src.GeneralCompanyLogo))
            .ForMember(dest => dest.LogoPath, opt => opt.MapFrom(src => src.GeneralCompanyLogoPath))
            .ForMember(dest => dest.LogoImageFileName, opt => opt.MapFrom(src => src.GeneralCompanyLogoImageFileName))
            .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.GeneralAboutCompany))
            .ForMember(dest => dest.LegalTerm, opt => opt.MapFrom(src => src.GeneralLegalTerm))
            .ForMember(dest => dest.DuplJobApplnRestrictDays, opt => opt.MapFrom(src => src.GeneralDuplJobApplnRestrictDays))
            .ForMember(dest => dest.OLReminderToCandidate, opt => opt.MapFrom(src => src.GeneralOLReminderToCandidate))
            .ForMember(dest => dest.BGLogo, opt => opt.MapFrom(src => src.GeneralBGLogo))
            .ForMember(dest => dest.BGLogoPath, opt => opt.MapFrom(src => src.GeneralBGLogoPath))
            .ForMember(dest => dest.BGLogoImageFileName, opt => opt.MapFrom(src => src.GeneralBGLogoImageFileName))
            .ForMember(dest => dest.BGColorCode, opt => opt.MapFrom(src => src.GeneralBGColorCode))
            .ForMember(dest => dest.CBJsonSettings, opt => opt.MapFrom(src => src.GeneralCBJsonSettings));
        CreateMap<RecruitGeneralSetting, UpdateRecruitGeneralSettingRequest>()
            .ForMember(dest => dest.GeneralCompanyName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.GeneralCompanyWebsite, opt => opt.MapFrom(src => src.Website))
            .ForMember(dest => dest.GeneralCompanyLogo, opt => opt.MapFrom(src => src.Logo))
            .ForMember(dest => dest.GeneralCompanyLogoPath, opt => opt.MapFrom(src => src.LogoPath))
            .ForMember(dest => dest.GeneralCompanyLogoImageFileName, opt => opt.MapFrom(src => src.LogoImageFileName))
            .ForMember(dest => dest.GeneralAboutCompany, opt => opt.MapFrom(src => src.About))
            .ForMember(dest => dest.GeneralLegalTerm, opt => opt.MapFrom(src => src.LegalTerm))
            .ForMember(dest => dest.GeneralDuplJobApplnRestrictDays, opt => opt.MapFrom(src => src.DuplJobApplnRestrictDays))
            .ForMember(dest => dest.GeneralOLReminderToCandidate, opt => opt.MapFrom(src => src.OLReminderToCandidate))
            .ForMember(dest => dest.GeneralBGLogo, opt => opt.MapFrom(src => src.BGLogo))
            .ForMember(dest => dest.GeneralBGLogoPath, opt => opt.MapFrom(src => src.BGLogoPath))
            .ForMember(dest => dest.GeneralBGLogoImageFileName, opt => opt.MapFrom(src => src.BGLogoImageFileName))
            .ForMember(dest => dest.GeneralBGColorCode, opt => opt.MapFrom(src => src.BGColorCode))
            .ForMember(dest => dest.GeneralCBJsonSettings, opt => opt.MapFrom(src => src.CBJsonSettings));

        CreateMap<GetRecruitGeneralSetting, RecruitGeneralSetting>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GeneralCompanyName))
            .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.GeneralCompanyWebsite))
            .ForMember(dest => dest.Logo, opt => opt.MapFrom(src => src.GeneralCompanyLogo))
            .ForMember(dest => dest.LogoPath, opt => opt.MapFrom(src => src.GeneralCompanyLogoPath))
            .ForMember(dest => dest.LogoImageFileName, opt => opt.MapFrom(src => src.GeneralCompanyLogoImageFileName))
            .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.GeneralAboutCompany))
            .ForMember(dest => dest.LegalTerm, opt => opt.MapFrom(src => src.GeneralLegalTerm))
            .ForMember(dest => dest.DuplJobApplnRestrictDays, opt => opt.MapFrom(src => src.GeneralDuplJobApplnRestrictDays))
            .ForMember(dest => dest.OLReminderToCandidate, opt => opt.MapFrom(src => src.GeneralOLReminderToCandidate))
            .ForMember(dest => dest.BGLogo, opt => opt.MapFrom(src => src.GeneralBGLogo))
            .ForMember(dest => dest.BGLogoPath, opt => opt.MapFrom(src => src.GeneralBGLogoPath))
            .ForMember(dest => dest.BGLogoImageFileName, opt => opt.MapFrom(src => src.GeneralBGLogoImageFileName))
            .ForMember(dest => dest.BGColorCode, opt => opt.MapFrom(src => src.GeneralBGColorCode))
            .ForMember(dest => dest.CBJsonSettings, opt => opt.MapFrom(src => src.GeneralCBJsonSettings));
        CreateMap<RecruitGeneralSetting, GetRecruitGeneralSetting>()
            .ForMember(dest => dest.GeneralCompanyName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.GeneralCompanyWebsite, opt => opt.MapFrom(src => src.Website))
            .ForMember(dest => dest.GeneralCompanyLogo, opt => opt.MapFrom(src => src.Logo))
            .ForMember(dest => dest.GeneralCompanyLogoPath, opt => opt.MapFrom(src => src.LogoPath))
            .ForMember(dest => dest.GeneralCompanyLogoImageFileName, opt => opt.MapFrom(src => src.LogoImageFileName))
            .ForMember(dest => dest.GeneralAboutCompany, opt => opt.MapFrom(src => src.About))
            .ForMember(dest => dest.GeneralLegalTerm, opt => opt.MapFrom(src => src.LegalTerm))
            .ForMember(dest => dest.GeneralDuplJobApplnRestrictDays, opt => opt.MapFrom(src => src.DuplJobApplnRestrictDays))
            .ForMember(dest => dest.GeneralOLReminderToCandidate, opt => opt.MapFrom(src => src.OLReminderToCandidate))
            .ForMember(dest => dest.GeneralBGLogo, opt => opt.MapFrom(src => src.BGLogo))
            .ForMember(dest => dest.GeneralBGLogoPath, opt => opt.MapFrom(src => src.BGLogoPath))
            .ForMember(dest => dest.GeneralBGLogoImageFileName, opt => opt.MapFrom(src => src.BGLogoImageFileName))
            .ForMember(dest => dest.GeneralBGColorCode, opt => opt.MapFrom(src => src.BGColorCode))
            .ForMember(dest => dest.GeneralCBJsonSettings, opt => opt.MapFrom(src => src.CBJsonSettings));


        // RecruitFooterSetting
        CreateMap<CreateRecruitFooterSettingRequest, RecruitFooterSetting>();
        CreateMap<UpdateRecruitFooterSettingRequest, RecruitFooterSetting>();
        CreateMap<RecruitFooterSetting, GetRecruitFooterSetting>();

        CreateMap<CreateRecruitFooterSettingRequest, RecruitFooterSetting>()
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.FooterTitle))
        .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.FooterSlug))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.FooterDescription))
        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.FooterStatusId));
        CreateMap<RecruitFooterSetting, CreateRecruitFooterSettingRequest>()
        .ForMember(dest => dest.FooterTitle, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.FooterSlug, opt => opt.MapFrom(src => src.Slug))
        .ForMember(dest => dest.FooterDescription, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.FooterStatusId, opt => opt.MapFrom(src => src.Status));

        CreateMap<UpdateRecruitFooterSettingRequest, RecruitFooterSetting>()
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.FooterTitle))
        .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.FooterSlug))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.FooterDescription))
        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.FooterStatusId));
        CreateMap<RecruitFooterSetting, UpdateRecruitFooterSettingRequest>()
        .ForMember(dest => dest.FooterTitle, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.FooterSlug, opt => opt.MapFrom(src => src.Slug))
        .ForMember(dest => dest.FooterDescription, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.FooterStatusId, opt => opt.MapFrom(src => src.Status));

        CreateMap<GetRecruitFooterSetting, RecruitFooterSetting>()
         .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.FooterTitle))
         .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.FooterSlug))
         .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.FooterDescription))
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.FooterStatusId));
        CreateMap<RecruitFooterSetting, GetRecruitFooterSetting>()
        .ForMember(dest => dest.FooterTitle, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.FooterSlug, opt => opt.MapFrom(src => src.Slug))
        .ForMember(dest => dest.FooterDescription, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.FooterStatusId, opt => opt.MapFrom(src => src.Status));

        // RecruiterSetting
        CreateMap<CreateRecruiterSettingRequest, RecruiterSetting>();
        CreateMap<UpdateRecruiterSettingRequest, RecruiterSetting>();
        CreateMap<RecruiterSetting, GetRecruiterSetting>();

        CreateMap<CreateRecruiterSettingRequest, RecruiterSetting>()
         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RecruiterName))
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.RecruiterStatusId));
        CreateMap<RecruiterSetting, CreateRecruiterSettingRequest>()
        .ForMember(dest => dest.RecruiterName, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.RecruiterStatusId, opt => opt.MapFrom(src => src.Status));

        CreateMap<UpdateRecruiterSettingRequest, RecruiterSetting>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RecruiterName))
        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.RecruiterStatusId));
        CreateMap<RecruiterSetting, UpdateRecruiterSettingRequest>()
        .ForMember(dest => dest.RecruiterName, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.RecruiterStatusId, opt => opt.MapFrom(src => src.Status));

        CreateMap<GetRecruiterSetting, RecruiterSetting>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RecruiterName))
        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.RecruiterStatusId));
        CreateMap<RecruiterSetting, GetRecruiterSetting>()
        .ForMember(dest => dest.RecruiterName, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.RecruiterStatusId, opt => opt.MapFrom(src => src.Status));

        // RecruitNotificationSetting
        CreateMap<CreateRecruitNotificationSettingRequest, RecruitNotificationSetting>();
        CreateMap<UpdateRecruitNotificationSettingRequest, RecruitNotificationSetting>();
        CreateMap<RecruitNotificationSetting, GetRecruitNotificationSetting>();

        CreateMap<CreateRecruitNotificationSettingRequest, RecruitNotificationSetting>()
        .ForMember(dest => dest.EMailJsonSettings, opt => opt.MapFrom(src => src.CBEMailJsonSettings))
        .ForMember(dest => dest.EMailNotificationJsonSettings, opt => opt.MapFrom(src => src.CBEMailNotificationJsonSettings));
        CreateMap<RecruitNotificationSetting, CreateRecruitNotificationSettingRequest>()
        .ForMember(dest => dest.CBEMailJsonSettings, opt => opt.MapFrom(src => src.EMailJsonSettings))
        .ForMember(dest => dest.CBEMailNotificationJsonSettings, opt => opt.MapFrom(src => src.EMailNotificationJsonSettings));

        CreateMap<UpdateRecruitNotificationSettingRequest, RecruitNotificationSetting>()
        .ForMember(dest => dest.EMailJsonSettings, opt => opt.MapFrom(src => src.CBEMailJsonSettings))
        .ForMember(dest => dest.EMailNotificationJsonSettings, opt => opt.MapFrom(src => src.CBEMailNotificationJsonSettings));
        CreateMap<RecruitNotificationSetting, UpdateRecruitNotificationSettingRequest>()
        .ForMember(dest => dest.CBEMailJsonSettings, opt => opt.MapFrom(src => src.EMailJsonSettings))
        .ForMember(dest => dest.CBEMailNotificationJsonSettings, opt => opt.MapFrom(src => src.EMailNotificationJsonSettings));

        CreateMap<GetRecruitNotificationSetting, RecruitNotificationSetting>()
        .ForMember(dest => dest.EMailJsonSettings, opt => opt.MapFrom(src => src.CBEMailJsonSettings))
        .ForMember(dest => dest.EMailNotificationJsonSettings, opt => opt.MapFrom(src => src.CBEMailNotificationJsonSettings));
        CreateMap<RecruitNotificationSetting, GetRecruitNotificationSetting>()
        .ForMember(dest => dest.CBEMailJsonSettings, opt => opt.MapFrom(src => src.EMailJsonSettings))
        .ForMember(dest => dest.CBEMailNotificationJsonSettings, opt => opt.MapFrom(src => src.EMailNotificationJsonSettings));

        // RecruitJobApplicationStatusSetting
        CreateMap<CreateRecruitJobApplicationStatusSettingRequest, RecruitJobApplicationStatusSetting>();
        CreateMap<UpdateRecruitJobApplicationStatusSettingRequest, RecruitJobApplicationStatusSetting>();
        CreateMap<RecruitJobApplicationStatusSetting, GetRecruitJobApplicationStatusSetting>();

        CreateMap<CreateRecruitJobApplicationStatusSettingRequest, RecruitJobApplicationStatusSetting>()
        .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.JobApplicationPositionId))
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.JobApplicationCategoryId))
        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.JASStatus))
        .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.JASColor))
        .ForMember(dest => dest.IsModelChecked, opt => opt.MapFrom(src => src.JASIsModelChecked));
        CreateMap<RecruitJobApplicationStatusSetting, CreateRecruitJobApplicationStatusSettingRequest>()
        .ForMember(dest => dest.JobApplicationPositionId, opt => opt.MapFrom(src => src.PositionId))
        .ForMember(dest => dest.JobApplicationCategoryId, opt => opt.MapFrom(src => src.CategoryId))
        .ForMember(dest => dest.JASStatus, opt => opt.MapFrom(src => src.Status))
        .ForMember(dest => dest.JASColor, opt => opt.MapFrom(src => src.Color))
        .ForMember(dest => dest.JASIsModelChecked, opt => opt.MapFrom(src => src.IsModelChecked));

        CreateMap<UpdateRecruitJobApplicationStatusSettingRequest, RecruitJobApplicationStatusSetting>()
        .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.JobApplicationPositionId))
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.JobApplicationCategoryId))
        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.JASStatus))
        .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.JASColor))
        .ForMember(dest => dest.IsModelChecked, opt => opt.MapFrom(src => src.JASIsModelChecked));
        CreateMap<RecruitJobApplicationStatusSetting, UpdateRecruitJobApplicationStatusSettingRequest>()
        .ForMember(dest => dest.JobApplicationPositionId, opt => opt.MapFrom(src => src.PositionId))
        .ForMember(dest => dest.JobApplicationCategoryId, opt => opt.MapFrom(src => src.CategoryId))
        .ForMember(dest => dest.JASStatus, opt => opt.MapFrom(src => src.Status))
        .ForMember(dest => dest.JASColor, opt => opt.MapFrom(src => src.Color))
        .ForMember(dest => dest.JASIsModelChecked, opt => opt.MapFrom(src => src.IsModelChecked));

        CreateMap<GetRecruitJobApplicationStatusSetting, RecruitJobApplicationStatusSetting>()
        .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.JobApplicationPositionId))
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.JobApplicationCategoryId))
        .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.JASStatus))
        .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.JASColor))
        .ForMember(dest => dest.IsModelChecked, opt => opt.MapFrom(src => src.JASIsModelChecked));
        CreateMap<RecruitJobApplicationStatusSetting, GetRecruitJobApplicationStatusSetting>()
        .ForMember(dest => dest.JobApplicationPositionId, opt => opt.MapFrom(src => src.PositionId))
        .ForMember(dest => dest.JobApplicationCategoryId, opt => opt.MapFrom(src => src.CategoryId))
        .ForMember(dest => dest.JASStatus, opt => opt.MapFrom(src => src.Status))
        .ForMember(dest => dest.JASColor, opt => opt.MapFrom(src => src.Color))
        .ForMember(dest => dest.JASIsModelChecked, opt => opt.MapFrom(src => src.IsModelChecked));

        // RecruitCustomQuestionSetting
        CreateMap<CreateRecruitCustomQuestionSettingRequest, RecruitCustomQuestionSetting>();
        CreateMap<UpdateRecruitCustomQuestionSettingRequest, RecruitCustomQuestionSetting>();
        CreateMap<RecruitCustomQuestionSetting, GetRecruitCustomQuestionSetting>();

        CreateMap<CreateRecruitCustomQuestionSettingRequest, RecruitCustomQuestionSetting>()
        .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.CustomQuestionTypeName))
        .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.CustomQuestionTypeId))
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CustomQuestionCategoryId))
        .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.CQStatusId))
        .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.CQIsRequiredId));
        CreateMap<RecruitCustomQuestionSetting, CreateRecruitCustomQuestionSettingRequest>()
        .ForMember(dest => dest.CustomQuestionTypeName, opt => opt.MapFrom(src => src.Question))
        .ForMember(dest => dest.CustomQuestionTypeId, opt => opt.MapFrom(src => src.TypeId))
        .ForMember(dest => dest.CustomQuestionCategoryId, opt => opt.MapFrom(src => src.CategoryId))
        .ForMember(dest => dest.CQStatusId, opt => opt.MapFrom(src => src.StatusId))
        .ForMember(dest => dest.CQIsRequiredId, opt => opt.MapFrom(src => src.IsRequired));

        CreateMap<UpdateRecruitCustomQuestionSettingRequest, RecruitCustomQuestionSetting>()
        .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.CustomQuestionTypeName))
        .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.CustomQuestionTypeId))
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CustomQuestionCategoryId))
        .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.CQStatusId))
        .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.CQIsRequiredId));
        CreateMap<RecruitCustomQuestionSetting, UpdateRecruitCustomQuestionSettingRequest>()
        .ForMember(dest => dest.CustomQuestionTypeName, opt => opt.MapFrom(src => src.Question))
        .ForMember(dest => dest.CustomQuestionTypeId, opt => opt.MapFrom(src => src.TypeId))
        .ForMember(dest => dest.CustomQuestionCategoryId, opt => opt.MapFrom(src => src.CategoryId))
        .ForMember(dest => dest.CQStatusId, opt => opt.MapFrom(src => src.StatusId))
        .ForMember(dest => dest.CQIsRequiredId, opt => opt.MapFrom(src => src.IsRequired));

        CreateMap<GetRecruitCustomQuestionSetting, RecruitCustomQuestionSetting>()
        .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.CustomQuestionTypeName))
        .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.CustomQuestionTypeId))
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CustomQuestionCategoryId))
        .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.CQStatusId))
        .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.CQIsRequiredId));
        CreateMap<RecruitCustomQuestionSetting, GetRecruitCustomQuestionSetting>()
        .ForMember(dest => dest.CustomQuestionTypeName, opt => opt.MapFrom(src => src.Question))
        .ForMember(dest => dest.CustomQuestionTypeId, opt => opt.MapFrom(src => src.TypeId))
        .ForMember(dest => dest.CustomQuestionCategoryId, opt => opt.MapFrom(src => src.CategoryId))
        .ForMember(dest => dest.CQStatusId, opt => opt.MapFrom(src => src.StatusId))
        .ForMember(dest => dest.CQIsRequiredId, opt => opt.MapFrom(src => src.IsRequired));

        // TimeLog
        CreateMap<CreateTimeLogRequest, TimeLog>();
        CreateMap<UpdateTimeLogRequest, TimeLog>();
        CreateMap<TimeLog, GetTimeLog>();

        // Timesheet
        CreateMap<CreateTimesheetRequest, Timesheet>();
        CreateMap<UpdateTimesheetRequest, Timesheet>();
        CreateMap<Timesheet, GetTimesheet>();

        // Payment
        CreateMap<CreatePaymentRequest, Payment>();
        CreateMap<UpdatePaymentRequest, Payment>();
        CreateMap<Payment, GetPayment>();

        // Application
        CreateMap<CreateApplicationRequest, Applications>();
        CreateMap<UpdateApplicationRequest, Applications>();
        CreateMap<Applications, GetApplication>();

        // Currency
        CreateMap<CreateCurrencyRequest, Currency>();
        CreateMap<UpdateCurrencyRequest, Currency>();
        CreateMap<Currency, GetCurrency>();

        // Planning
        CreateMap<CreatePlanningRequest, Planning>();
        CreateMap<UpdatePlanningRequest, Planning>();
        CreateMap<Planning, GetPlanning>();

        // Tax
        CreateMap<CreateTaxRequest, Tax>();
        CreateMap<UpdateTaxRequest, Tax>();
        CreateMap<Tax, GetTax>();

        // Client
        CreateMap<CreateClientRequest, Client>();
        CreateMap<UpdateClientRequest, Client>();
        CreateMap<Client, GetClient>();

        // Employee
        CreateMap<CreateEmployeeRequest, Employee>();
        CreateMap<UpdateEmployeeRequest, Employee>();
        CreateMap<Employee, GetEmployee>();

        // AttendanceSetting
        CreateMap<CreateAttendanceSettingRequest, AttendanceSetting>();
        CreateMap<UpdateAttendanceSettingRequest, AttendanceSetting>();
        CreateMap<AttendanceSetting, GetAttendanceSetting>();

        //// BillOrder
        //CreateMap<CreateBillOrderRequest, BillOrder>();
        //CreateMap<UpdateBillOrderRequest, BillOrder>();
        //CreateMap<BillOrder, GetBillOrder>();
        //// PurchaseOrder
        //CreateMap<CreatePurchaseOrderRequest, PurchaseOrder>();
        //CreateMap<UpdatePurchaseOrderRequest, PurchaseOrder>();
        //CreateMap<PurchaseOrder, GetPurchaseOrder>();
        //// VendorCredit
        //CreateMap<CreateVendorCreditRequest, VendorCredit>();
        //CreateMap<UpdateVendorCreditRequest, VendorCredit>();
        //CreateMap<VendorCredit, GetVendorCredit>();

        // FinanceInvoiceSetting
        CreateMap<CreateFinanceInvoiceSettingRequest, FinanceInvoiceSetting>();
        CreateMap<UpdateFinanceInvoiceSettingRequest, FinanceInvoiceSetting>();
        CreateMap<FinanceInvoiceSetting, GetFinanceInvoiceSetting>();

        // Language
        CreateMap<createLanguageRequest, Language>();
        CreateMap<UpdateLanguageRequest, Language>();
        CreateMap<Language, GetLanguage>();

        CreateMap<createLanguageRequest, Language>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LanguageName))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.LanguageCode));
        CreateMap<Language, createLanguageRequest>()
            .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LanguageCode, opt => opt.MapFrom(src => src.Code));

        CreateMap<UpdateLanguageRequest, Language>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LanguageName))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.LanguageCode));
        CreateMap<Language, UpdateLanguageRequest>()
            .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LanguageCode, opt => opt.MapFrom(src => src.Code));

        CreateMap<Language, GetLanguage>()
            .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LanguageCode, opt => opt.MapFrom(src => src.Code));
        CreateMap<GetLanguage, Language>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LanguageName))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.LanguageCode));

        // PurchaseSetting
        CreateMap<CreatePurchaseSettingRequest, PurchaseSetting>();
        CreateMap<UpdatePurchaseSettingRequest, PurchaseSetting>();
        CreateMap<PurchaseSetting, GetPurchaseSetting>();

        // Tasks
        CreateMap<CreateTasksRequest, Tasks>();
        CreateMap<UpdateTasksRequest, Tasks>();
        CreateMap<Tasks, GetTasks>();

        // Message
        CreateMap<CreateMessageRequest, Message>();
        CreateMap<UpdateMessageRequest, Message>();
        CreateMap<Message, GetMessage>();

        // Notification
        CreateMap<CreateNotificationRequest, Notification>();
        CreateMap<UpdateNotificationRequest, Notification>();
        CreateMap<Notification, GetNotification>();

        // ToggleValue
        CreateMap<CreateToggleValueRequest, ToggleValue>();
        CreateMap<UpdateToggleValueRequest, ToggleValue>();
        CreateMap<ToggleValue, GetToggleValue>();

    }
}