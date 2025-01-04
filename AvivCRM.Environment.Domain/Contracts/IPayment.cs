using AvivCRM.Environment.Domain.Entities;

namespace AvivCRM.Environment.Domain.Contracts;
public interface IPayment
{
    void Add(Payment payment);
    void Update(Payment payment);
    void Delete(Payment payment);
    Task<Payment?> GetByIdAsync(Guid id);
    Task<IEnumerable<Payment>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string paymentName);
}
