using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class GuessGame : IGuessGame
    {
        private readonly Lazy<IPrintRules> _printRules;
        private readonly Lazy<IPrintBye> _printBye;
        private readonly Lazy<IChooseContinueOrExit> _chooseContinueOrExit;
        private readonly Lazy<IPlay> _play;

        public GuessGame(Lazy<IPrintRules> printRules,
            Lazy<IPrintBye> printBye,
            Lazy<IChooseContinueOrExit> chooseContinueOrExit,
            Lazy<IPlay> play)
        {
            _printRules = printRules;
            _printBye = printBye;
            _chooseContinueOrExit = chooseContinueOrExit;
            _play = play;
        }

        public void Execute()
        {
            // Печатаем правила игры.
            _printRules.Value.Execute();

            // Играем.
            var continueOrExit = ContinueOrExit.Continue;

            while (continueOrExit == ContinueOrExit.Continue)
            {
                _play.Value.Execute();
                continueOrExit = _chooseContinueOrExit.Value.Execute();
            }

            // Печатаем прощание.
            _printBye.Value.Execute();
        }
    }
}