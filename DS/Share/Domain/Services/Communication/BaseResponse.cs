namespace DS.Share.Domain.Services.Communication;

public abstract class BaseResponse<T>
{
    /// <summary>
    /// Constructor que inicializa la respuesta con un mensaje.
    /// </summary>
    /// <param name="message">El mensaje de la respuesta.</param>
    protected BaseResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }
    
    /// <summary>
    /// Constructor que inicializa la respuesta con un recurso.
    /// </summary>
    /// <param name="resource">El recurso de la respuesta.</param>
    protected BaseResponse(T resource)
    {
        Success = true;
        Message = string.Empty;
        Resource = resource;
    }

    /// <summary>
    /// Obtiene o establece el estado de éxito de la respuesta.
    /// </summary>
    public bool Success { get; set; }
    
    /// <summary>
    /// Obtiene o establece el mensaje de la respuesta.
    /// </summary>
    public string Message { get; set; }
    
    /// <summary>
    /// Obtiene o establece el recurso de la respuesta.
    /// </summary>
    public T Resource { get; set; }
}