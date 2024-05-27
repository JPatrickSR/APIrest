using DS.Share.Extensions;
using DS.DriveShare.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DS.Share.Persistance.Contexts;

public class AppDbContext : DbContext
{
    /// <summary>
    /// Constructor que inicializa una nueva instancia de la clase AppDbContext.
    /// </summary>
    /// <param name="options">Opciones para configurar el contexto de la base de datos.</param>
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Obtiene o establece el conjunto de datos de alquileres.
    /// </summary>
    
    /// <summary>
    /// Obtiene o establece el conjunto de datos de arrendatarios.
    /// </summary>

    
    public DbSet<Parking> parking { get; set; }
    /// <summary>
    /// Configuración del modelo de base de datos al crear el contexto.
    /// </summary>
    /// <param name="builder">Constructor de modelos para configurar entidades y relaciones.</param>
    //public DbSet<User> Usuarios { get; set; }
    
    /// <summary>
    /// Configuración del modelo de base de datos al crear el contexto.
    /// </summary>
    /// <param name="builder">Constructor de modelos para configurar entidades y relaciones.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
      
        


        //Configurar la tabla Oferts
        builder.Entity<Parking>().ToTable("Oferts");
        builder.Entity<Parking>().HasKey(p => p.ParkingId); 
        builder.Entity<Parking>().Property(p => p.Description).IsRequired().HasMaxLength(100);
        builder.Entity<Parking>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
        builder.Entity<Parking>().Property(p => p.Stars).IsRequired().HasMaxLength(1);
        builder.Entity<Parking>().Property(p => p.MaxCapacity).IsRequired().HasMaxLength(3);
        builder.Entity<Parking>().Property(p => p.AvailableCapacity).IsRequired().HasMaxLength(3);
        builder.Entity<Parking>().Property(p => p.LocationId).IsRequired();
        builder.Entity<Parking>().Property(p => p.ScheduleId).IsRequired();
        builder.Entity<Parking>().Property(p => p.GuestId).IsRequired();
        builder.Entity<Parking>().Property(p => p.DateCreate).HasDefaultValue(DateTime.Now);
        
     
        
        // Utiliza la convención de nomenclatura SnakeCase para el modelo de datos.    
    builder.UseSnakeCaseNamingConvention();
    }
}