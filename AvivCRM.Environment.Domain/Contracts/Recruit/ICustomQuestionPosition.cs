using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts.Recruit;
public interface ICustomQuestionPosition
{
    void Add(CustomQuestionPosition customQuestionPosition);
    void Update(CustomQuestionPosition customQuestionPosition);
    void Delete(CustomQuestionPosition customQuestionPosition);
    Task<CustomQuestionPosition?> GetByIdAsync(Guid id);
    Task<IEnumerable<CustomQuestionPosition>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string customQuestionPositionName);
}









