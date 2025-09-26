using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class GetUserAnswerInput : IGetUserAnswerInput
    {
        public string? Execute()
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
                return default;

            return key.KeyChar.ToString();
        }
    }
}