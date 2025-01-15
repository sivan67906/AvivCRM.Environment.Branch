namespace AvivCRM.Environment.Application.Contracts;
public interface IUnitOfWork
{
    Task SaveChangesAsync();
}