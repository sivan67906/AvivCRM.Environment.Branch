using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts.Recruit;
public interface ICustomQuestionCategory
{
    void Add(CustomQuestionCategory customQuestionCategory);
    void Update(CustomQuestionCategory customQuestionCategory);
    void Delete(CustomQuestionCategory customQuestionCategory);
    Task<CustomQuestionCategory?> GetByIdAsync(Guid id);
    Task<IEnumerable<CustomQuestionCategory>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string customQuestionCategoryName);
}








