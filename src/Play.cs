using GuessNumber.Abstractions;

namespace GuessNumber
{
    class Play : IPlay
    {
        public void Execute()
        {
            Console.WriteLine("Игра!");
        }
    }
}