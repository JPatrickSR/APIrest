using Microsoft.EntityFrameworkCore;

namespace DS.Share.Extensions;

public static class ModelBuilderExtensions
{
    /// <summary>
    /// Método de extensión para usar la convención de nomenclatura de snake case en el ModelBuilder.
    /// </summary>
    /// <param name="builder">El ModelBuilder.</param>
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Establece el nombre de la tabla en snake case
            entity.SetTableName(entity.GetTableName().ToSnakeCase());
            
            foreach (var property in entity.GetProperties())
            {
                // Establece el nombre de la columna en snake case
                property.SetColumnName(property.GetColumnBaseName().ToSnakeCase());
            }

            foreach (var key in entity.GetKeys())
            {
                // Establece el nombre de la clave en snake case
                key.SetName(key.GetName().ToSnakeCase());
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                // Establece el nombre de la restricción de clave externa en snake case
                foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                // Establece el nombre de la base de datos en snake case
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
            }
        }
    }
}