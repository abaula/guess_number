using GuessNumber.Abstractions;

namespace GuessNumber
{
    class WriteLineToConsole : IWriteLineToConsole
    {
        public void Execute(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            Console.WriteLine(value);
        }
    }
}