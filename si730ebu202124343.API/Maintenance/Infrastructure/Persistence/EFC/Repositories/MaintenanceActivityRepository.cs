using Microsoft.EntityFrameworkCore;
using si730ebu202124343.API.Maintenance.Domain.Model.Aggregates;
using si730ebu202124343.API.Maintenance.Domain.Repositories;
using si730ebu202124343.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202124343.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202124343.API.Maintenance.Infrastructure.Persistence.EFC.Repositories;

public class MaintenanceActivityRepository(AppDbContext context) : BaseRepository<MaintenanceActivity>(context),
    IMaintenanceActivityRepository
{
    public async Task<int> GetMaintenanceActivityResultBySerialNumber(string serialNumber)
    {
        var activity = await context.Set<MaintenanceActivity>().FirstOrDefaultAsync(p => p.ProductSerialNumber.Equals(serialNumber));
        return (int)(activity?.Result ?? default);
    }
}