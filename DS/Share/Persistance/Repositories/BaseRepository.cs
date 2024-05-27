using DS.Share.Persistance.Contexts;

namespace DS.Share.Persistance.Repositories;

public class BaseRepository
{
    /// <summary>
    /// El contexto de la aplicación.
    /// </summary>
    protected readonly AppDbContext _context;
    
    /// <summary>
    /// Constructor que inicializa el contexto de la aplicación.
    /// </summary>
    /// <param name="context">El contexto de la aplicación.</param>
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}