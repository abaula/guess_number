using System.Reflection;
using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class GetResourceText : IGetResourceText
    {
        public string? Execute(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == default)
                    return default;

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}