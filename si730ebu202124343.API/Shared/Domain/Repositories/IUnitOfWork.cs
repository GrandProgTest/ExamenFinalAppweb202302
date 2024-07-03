namespace si730ebu202124343.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}