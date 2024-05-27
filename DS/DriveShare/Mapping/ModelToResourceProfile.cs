using AutoMapper;
using DS.DriveShare.Domain.Models;
using DS.DriveShare.Resources;

namespace DS.DriveShare.Mapping;

public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {


        CreateMap<Parking, ParkingResource>();
    


        // Mapeo de Vehiculo a VehiculoResource con inclusión de miembros.

    }
    
}