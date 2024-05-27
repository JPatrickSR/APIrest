using DS.DriveShare.Domain.Models;
using DS.DriveShare.Domain.Repositories;
using DS.DriveShare.Domain.Services;
using DS.DriveShare.Domain.Services.Communication;
using DS.Share.Persistance.Repositories;

namespace DS.DriveShare.Services;

public class ParkingServices:IParkingService
{
     private readonly IParkingRepository _parkingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ParkingServices(IParkingRepository parkingRepository, IUnitOfWork unitOfWork)
    {
        _parkingRepository = parkingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Parking>> ListAsync()
    {
        return await _parkingRepository.ListAsync();
    }

    public async Task<ParkingResponse> SaveAsync(Parking parking)
    {
        try
        {
            if (parking == null)
            {
                return new ParkingResponse("The parking is null.");
            }
            
            // Puedes realizar validaciones adicionales antes de guardar si es necesario

            // Asigna la fecha de creación si aún no está establecida
            if (parking.DateCreate == default(DateTime))
            {
                parking.DateCreate = DateTime.UtcNow;
            }

            // Asigna la fecha de actualización
            parking.DateUpdate = DateTime.UtcNow;

            // Asigna Name y urlLogo desde los parámetros
            string description = parking.Description;
            float stars = parking.Stars;
            string phone = parking.Phone;
            int maxCapacity = parking.MaxCapacity;
            int availableCapacity = parking.AvailableCapacity;
            int locationId = parking.LocationId;
            int scheduleId = parking.ScheduleId;
            int guestId = parking.GuestId;
            
            int parkingId = parking.ParkingId;
           
            if (parkingId > 0)
            {
                _parkingRepository.Update(parking); // Actualizar si ya existe
            }
            else
            {
                await _parkingRepository.AddAsync(parking); // Agregar si es nuevo
            }
            
            await _unitOfWork.CompleteAsync(); // Asegúrate de tener _unitOfWork configurado en tu clase

            // Puedes devolver la respuesta con el proveedor guardado
            return new ParkingResponse(parking);
        }
        catch (Exception e)
        {
            // Maneja cualquier error que pueda ocurrir durante el proceso de guardado
            return new ParkingResponse($"An error occurred while saving the provider: {e.Message}");
        }
    }
    public async Task<Parking> FindByIdAsync(int parkingid)
    {
        return await _parkingRepository.FindByIdAsync(parkingid);
    }
    private T UpdateIfValid<T>(T existingValue, T newValue)
    {
        if (IsValidForUpdate(newValue))
        {
            return newValue;
        }

        return existingValue;
    }
    // Método de utilidad para validar si un valor es válido para la actualización
    private bool IsValidForUpdate<T>(T value)
    {
        // Si el tipo es una cadena, verifica que no sea igual a "string"
        if (typeof(T) == typeof(string))
        {
            return value != null && !value.Equals("string");
        }
        // Si el tipo es numérico (en este caso, solo int), verifica que no sea igual a 0
        else if (typeof(T) == typeof(int))
        {
            return !EqualityComparer<T>.Default.Equals(value, default(T));
        }
        // Otros tipos
        else
        {
            return value != null && !value.Equals(default(T));
        }
    }
    public async Task<ParkingResponse> UpdateAsync(int parkingId, Parking parking)
    {
        var existingParking = await _parkingRepository.FindByIdAsync(parkingId);
        if (existingParking == null)
            return new ParkingResponse("Parking not found.");

        existingParking.Description = UpdateIfValid(existingParking.Description, parking.Description);
        // Actualiza otras propiedades según sea necesario

        try
        {
            _parkingRepository.Update(existingParking);
            await _unitOfWork.CompleteAsync();
            return new ParkingResponse(existingParking);
        }
        catch (Exception e)
        {
            return new ParkingResponse($"An error occurred while updating the product: {e.Message}");
        }
    }
    public async Task<ParkingResponse> DeleteAsync(int parkingId)
    {
        var existingParking = await _parkingRepository.FindByIdAsync(parkingId);
        if (existingParking == null)
            return new ParkingResponse("Parking not found.");

        try
        {
            _parkingRepository.Remove(existingParking);
            await _unitOfWork.CompleteAsync();
            return new ParkingResponse(existingParking);
        }
        catch (Exception e)
        {
            return new ParkingResponse($"An error occurred while deleting the product: {e.Message}");
        }
    }
}