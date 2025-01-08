namespace AvivCRM.Environment.Domain.Contracts;
public interface IUnitOfWork
{
    Task SaveChangesAsync();
}