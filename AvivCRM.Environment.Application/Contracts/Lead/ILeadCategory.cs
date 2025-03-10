﻿#region

using AvivCRM.Environment.Domain.Entities.Lead;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Lead;
public interface ILeadCategory
{
    void Add(LeadCategory leadCategory);
    void Update(LeadCategory leadCategory);
    void Delete(LeadCategory leadCategory);
    Task<LeadCategory?> GetByIdAsync(Guid id);
    Task<IEnumerable<LeadCategory>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string leadCategoryName);
}