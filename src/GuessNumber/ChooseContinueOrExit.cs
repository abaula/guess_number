using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class ChooseContinueOrExit : IChooseContinueOrExit
    {
        private readonly IPrintChooseContinueOrExit _printChooseContinueOrExit;

        public ChooseContinueOrExit(IPrintChooseContinueOrExit printChooseContinueOrExit)
        {
            _printChooseContinueOrExit = printChooseContinueOrExit;
        }

        public ContinueOrExit Execute()
        {
            // Печатаем правила выбора решения продолжить или выйти.
            _printChooseContinueOrExit.Execute();

            // Получаем и обрабатываем решение пользователя.
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
                return ContinueOrExit.Exit;

            return ContinueOrExit.Continue;
        }
    }
}