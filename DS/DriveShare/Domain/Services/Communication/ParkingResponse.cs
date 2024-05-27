using DS.DriveShare.Domain.Models;
using DS.Share.Domain.Services.Communication;

namespace DS.DriveShare.Domain.Services.Communication;

public class ParkingResponse:BaseResponse<Parking>
{   /// <summary>
    /// Constructor para una respuesta que indica un error.
    /// </summary>
    /// <param name="message">Mensaje de error.</param>
    public ParkingResponse(string message) : base(message)
    {
        
    }
    /// <summary>
    /// Constructor para una respuesta exitosa.
    /// </summary>
    /// <param name="resource">Recursos relacionados con la respuesta.</param>
    public ParkingResponse(Parking resource) : base(resource)
    {
    }
}