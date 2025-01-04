using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Application.DTOs.FinanceInvoiceTemplateSettings;
using AvivCRM.Environment.Application.DTOs.FinancePrefixSettings;
using AvivCRM.Environment.Application.DTOs.FinanceUnitSettings;
using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Application.DTOs.Payment;
using AvivCRM.Environment.Application.DTOs.ProjectCategories;
using AvivCRM.Environment.Application.DTOs.ProjectReminderPersons;
using AvivCRM.Environment.Application.DTOs.RecruitNotificationSettings;
using AvivCRM.Environment.Application.DTOs.TicketAgents;
using AvivCRM.Environment.Application.DTOs.TicketChannels;
using AvivCRM.Environment.Application.DTOs.TicketGroups;
using AvivCRM.Environment.Application.DTOs.TicketReplyTemplates;
using AvivCRM.Environment.Application.DTOs.TicketTypes;
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
        // Payment
        CreateMap<CreatePaymentRequest, Payment>();
        CreateMap<UpdatePaymentRequest, Payment>();
        CreateMap<Payment, GetPayment>();

    }
}