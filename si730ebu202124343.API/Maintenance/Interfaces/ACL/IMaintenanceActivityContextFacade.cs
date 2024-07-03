namespace si730ebu202124343.API.Maintenance.Interfaces.ACL;

public interface IMaintenanceActivityContextFacade
{
    Task<int> FetchMaintenanceActivityResultBySerialNumber(string serialNumber);
}