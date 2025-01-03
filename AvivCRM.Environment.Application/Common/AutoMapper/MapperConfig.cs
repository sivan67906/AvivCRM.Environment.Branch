using AutoMapper;
using AvivCRM.Environment.Application.DTOs.Contracts;
using AvivCRM.Environment.Application.DTOs.LeadAgent;
using AvivCRM.Environment.Application.DTOs.LeadCategories;
using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Application.DTOs.LeadStatus;
using AvivCRM.Environment.Application.DTOs.ProjectCategories;
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



    }
}

