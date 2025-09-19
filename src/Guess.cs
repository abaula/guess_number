using GuessNumber.Abstractions;

namespace GuessNumber
{
    class Guess(IPrintRules printRules) : IGuess
    {
        public void Execute()
        {
            printRules.Execute();

            Console.WriteLine("Hello");
        }
    }
}