using GuessNumber.Abstractions;

namespace GuessNumber
{
    class WriteToConsole : IWriteToConsole
    {
        public void Execute(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            Console.WriteLine(value);
        }
    }
}