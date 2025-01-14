﻿#region

using AvivCRM.Environment.Domain.Entities.Lead;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Lead;
public interface ILeadStatus
{
    void Add(LeadStatus leadStatus);
    void Update(LeadStatus leadStatus);
    void Delete(LeadStatus leadStatus);
    Task<LeadStatus?> GetByIdAsync(Guid id);
    Task<IEnumerable<LeadStatus>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string leadStatus);
}