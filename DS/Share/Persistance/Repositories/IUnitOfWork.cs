namespace DS.Share.Persistance.Repositories;

public interface IUnitOfWork
{
    /// <summary>
    /// Completa la unidad de trabajo de forma asíncrona.
    /// </summary>
    Task CompleteAsync();
}