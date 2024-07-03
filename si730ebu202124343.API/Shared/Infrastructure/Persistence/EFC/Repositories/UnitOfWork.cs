using si730ebu202124343.API.Shared.Domain.Repositories;
using si730ebu202124343.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace si730ebu202124343.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}