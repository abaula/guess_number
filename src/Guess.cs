using GuessNumber.Abstractions;

namespace GuessNumber
{
    class Guess(IPrintRules printRules,
        IPrintBye printBye,
        IChooseContinueOrExit chooseContinueOrExit,
        IPlay play)
        : IGuess
    {
        public void Execute()
        {
            // Печатаем правила игры.
            printRules.Execute();

            // Играем.
            var continueOrExit = ContinueOrExit.Continue;

            while (continueOrExit == ContinueOrExit.Continue)
            {
                play.Execute();
                continueOrExit = chooseContinueOrExit.Execute();
            }

            // Печатаем прощание.
            printBye.Execute();
        }
    }
}