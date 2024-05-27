using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DS.Share.Extensions;

public static class ModelStateExtensions
{
    /// <summary>
    /// Método de extensión para obtener los mensajes de error del ModelStateDictionary.
    /// </summary>
    /// <param name="dictionary">El ModelStateDictionary.</param>
    /// <returns>Una lista de mensajes de error.</returns>
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary.SelectMany(m => m.Value.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}