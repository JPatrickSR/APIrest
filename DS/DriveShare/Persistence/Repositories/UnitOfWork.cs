using DS.Share.Persistance.Contexts;
using DS.Share.Persistance.Repositories;

namespace DS.DriveShare.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    /// <summary>
    /// Contexto de la base de datos utilizado para realizar las operaciones.
    /// </summary>
    
    private readonly AppDbContext _context;

    /// <summary>
    /// Inicializa una nueva instancia de la clase UnitOfWork con el contexto de la base de datos proporcionado.
    /// </summary>
    /// <param name="context">El contexto de la base de datos.</param>
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Completa todas las operaciones de base de datos pendientes de manera asincrónica, asegurando que se ejecuten como una única transacción.
    /// </summary>
    /// <returns>Una tarea que representa la operación asincrónica de guardar los cambios en la base de datos.</returns>
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}