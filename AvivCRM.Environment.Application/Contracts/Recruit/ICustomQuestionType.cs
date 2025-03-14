#region

using AvivCRM.Environment.Domain.Entities.Recruit;

#endregion

namespace AvivCRM.Environment.Application.Contracts.Recruit;
public interface ICustomQuestionType
{
    void Add(CustomQuestionType customQuestionType);
    void Update(CustomQuestionType customQuestionType);
    void Delete(CustomQuestionType customQuestionType);
    Task<CustomQuestionType?> GetByIdAsync(Guid id);
    Task<IEnumerable<CustomQuestionType>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string customQuestionTypeName);
}