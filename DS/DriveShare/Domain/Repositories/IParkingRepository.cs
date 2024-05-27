using DS.DriveShare.Domain.Models;

namespace DS.DriveShare.Domain.Repositories;

public interface IParkingRepository
{
    Task<Parking> FindByIdAsync(int parkingId);
    Task<IEnumerable<Parking>> ListAsync();
    
    void Update(Parking parking);

    void Remove(Parking parking);
    
    Task AddAsync(Parking parking);
}