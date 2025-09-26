using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class ConvertInputToNumber : IConvertInputToNumber
    {
        public int? Execute(string value)
        {
            if (int.TryParse(value, out int result))
                return result;

            return default;
        }
    }
}

