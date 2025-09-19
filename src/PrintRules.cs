using GuessNumber.Abstractions;

namespace GuessNumber
{
    class PrintRules(IGetRulesText getRulesText,
        IWriteToConsole writeToConsole)
        : IPrintRules
    {
        public void Execute()
        {
            var rulesText = getRulesText.Execute();

            if (string.IsNullOrWhiteSpace(rulesText))
                return;

            writeToConsole.Execute(rulesText);
        }
    }
}