#region

using AvivCRM.Environment.Domain.Entities;

#endregion

namespace AvivCRM.Environment.Domain.Contracts.Recruit;
public interface ICustomQuestionType
{
    void Add(CustomQuestionType customQuestionType);
    void Update(CustomQuestionType customQuestionType);
    void Delete(CustomQuestionType customQuestionType);
    Task<CustomQuestionType?> GetByIdAsync(Guid id);
    Task<IEnumerable<CustomQuestionType>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string customQuestionTypeName);
}