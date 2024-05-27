using AutoMapper;
using DS.DriveShare.Domain.Models;
using DS.DriveShare.Resources;

namespace DS.DriveShare.Mapping;

public class ResourceToModelProfile : Profile
{
    /// <summary>
    /// Inicializa una nueva instancia del perfil de mapeo de recursos de guardado a modelos de dominio.
    /// </summary>
    public ResourceToModelProfile()
    {

        CreateMap<SaveParkingResource, Parking>();

    }
}