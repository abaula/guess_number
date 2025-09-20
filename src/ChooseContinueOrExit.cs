using GuessNumber.Abstractions;

namespace GuessNumber
{
    class ChooseContinueOrExit(IPrintChooseContinueOrExit printChooseContinueOrExit)
        : IChooseContinueOrExit
    {
        public ContinueOrExit Execute()
        {
            // Печатаем правила выбора решения продолжить или выйти.
            printChooseContinueOrExit.Execute();

            // Получаем и обрабатываем решение пользователя.
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
                return ContinueOrExit.Exit;

            return ContinueOrExit.Continue;
        }
    }
}