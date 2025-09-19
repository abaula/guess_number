using System.Reflection;
using GuessNumber.Abstractions;

namespace GuessNumber
{
    class GetRulesText : IGetRulesText
    {
        public string? Execute()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(AppConst.Resources.Rules))
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