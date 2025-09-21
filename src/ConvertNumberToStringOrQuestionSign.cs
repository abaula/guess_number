using GuessNumber.Abstractions;

namespace GuessNumber
{
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