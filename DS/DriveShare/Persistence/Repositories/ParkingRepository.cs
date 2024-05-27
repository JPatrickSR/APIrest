using DS.DriveShare.Domain.Models;
using DS.DriveShare.Domain.Repositories;
using DS.Share.Persistance.Contexts;
using DS.Share.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DS.DriveShare.Persistence.Repositories;

public class ParkingRepository:BaseRepository,IParkingRepository
{
    public ParkingRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Parking> FindByIdAsync(int parkingid) 
    {
        return await _context.parking.FindAsync(parkingid);
    }
    public async Task<IEnumerable<Parking>> ListAsync()
    {
        return await _context.parking.ToListAsync();
    }

    public void Update(Parking parking)
    {
        _context.parking.Update(parking);
    }
    
    public void Remove(Parking parking)
    {
        _context.parking.Remove(parking);
    }

    public async Task AddAsync(Parking parking)
    {
        await _context.parking.AddAsync(parking);
    }
}