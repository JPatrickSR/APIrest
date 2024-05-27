using DS.DriveShare.Domain.Models;
using DS.DriveShare.Domain.Services.Communication;

namespace DS.DriveShare.Domain.Services;

public interface IParkingService
{
    Task<IEnumerable<Parking>> ListAsync();
    Task<ParkingResponse> SaveAsync(Parking parking);
    Task<Parking> FindByIdAsync(int parkingid);
    Task<ParkingResponse> DeleteAsync(int parkingId);
    Task<ParkingResponse> UpdateAsync(int parkingId, Parking parking);
}