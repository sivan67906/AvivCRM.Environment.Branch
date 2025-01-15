namespace AvivCRM.Environment.Domain.Interfaces;
public interface IUnitOfWork
{
    Task SaveChangesAsync();
}