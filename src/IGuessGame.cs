using GuessNumber.Abstractions;

namespace GuessNumber
{
    class GuessGame : IGuessGame
    {
        private readonly IPrintRules _printRules;
        private readonly IPrintBye _printBye;
        private readonly IChooseContinueOrExit _chooseContinueOrExit;
        private readonly IPlay _play;

        public GuessGame(IPrintRules printRules,
            IPrintBye printBye,
            IChooseContinueOrExit chooseContinueOrExit,
            IPlay play)
        {
            _printRules = printRules;
            _printBye = printBye;
            _chooseContinueOrExit = chooseContinueOrExit;
            _play = play;
        }

        public void Execute()
        {
            // Печатаем правила игры.
            _printRules.Execute();

            // Играем.
            var continueOrExit = ContinueOrExit.Continue;

            while (continueOrExit == ContinueOrExit.Continue)
            {
                _play.Execute();
                continueOrExit = _chooseContinueOrExit.Execute();
            }

            // Печатаем прощание.
            _printBye.Execute();
        }
    }
}