#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts.Lead;
public interface ILeadAgent
{
    void Add(LeadAgent leadAgent);
    void Update(LeadAgent leadAgent);
    void Delete(LeadAgent leadAgent);
    Task<LeadAgent?> GetByIdAsync(Guid id);
    Task<IEnumerable<LeadAgent>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string leadAgentName);
}