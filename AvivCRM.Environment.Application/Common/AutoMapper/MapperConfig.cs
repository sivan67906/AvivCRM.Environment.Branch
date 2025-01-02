using AutoMapper;
using AvivCRM.Environment.Application.DTOs.LeadSources;
using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Application.Common.AutoMapper;
public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<CreateLeadSourceRequest, LeadSource>();
        CreateMap<CreateLeadSourceRequest, LeadSource>();
        CreateMap<LeadSource, GetLeadSource>();
    }
}

