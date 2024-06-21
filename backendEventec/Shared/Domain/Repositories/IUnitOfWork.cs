namespace pcWeb2.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}