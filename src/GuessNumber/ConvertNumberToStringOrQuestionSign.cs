using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class ConvertNumberToStringOrQuestionSign : IConvertNumberToStringOrQuestionSign
    {
        public string Execute(int? number)
        {
            if (number.HasValue)
                return number.Value.ToString();

            return "?";
        }
    }
}