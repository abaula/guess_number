using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class ChooseContinueOrExit : IChooseContinueOrExit
    {
        private readonly Lazy<IPrintChooseContinueOrExit> _printChooseContinueOrExit;

        public ChooseContinueOrExit(Lazy<IPrintChooseContinueOrExit> printChooseContinueOrExit)
        {
            _printChooseContinueOrExit = printChooseContinueOrExit;
        }

        public ContinueOrExit Execute()
        {
            // Печатаем правила выбора решения продолжить или выйти.
            _printChooseContinueOrExit.Value.Execute();

            // Получаем и обрабатываем решение пользователя.
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
                return ContinueOrExit.Exit;

            return ContinueOrExit.Continue;
        }
    }
}