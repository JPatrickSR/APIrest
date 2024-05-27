namespace DS.Share.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Método de extensión para convertir una cadena de texto a snake case.
    /// </summary>
    /// <param name="text">La cadena de texto a convertir.</param>
    /// <returns>La cadena de texto convertida a snake case.</returns>
    public static string ToSnakeCase(this string text)
    {
        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;
            
            // Convierte el primer carácter a minúsculas
            yield return char.ToLower(e.Current);

            while (e.MoveNext())
            {
                // Si el carácter es una letra mayúscula, añade un guion bajo y convierte la letra a minúsculas
                if (char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    // Si el carácter no es una letra mayúscula, lo devuelve tal cual
                    yield return e.Current;
                }
            }
        }
        // Convierte la secuencia de caracteres a una cadena de texto
        return new string(Convert(text.GetEnumerator()).ToArray()); }
}