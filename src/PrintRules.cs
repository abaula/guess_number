using GuessNumber.Abstractions;

namespace GuessNumber
{
    class PrintRules(IGetRulesText getRulesText,
        IWriteLineToConsole writeLineToConsole)
        : IPrintRules
    {
        public void Execute()
        {
            var rulesText = getRulesText.Execute();

            if (string.IsNullOrWhiteSpace(rulesText))
                return;

            writeLineToConsole.Execute(rulesText);
        }
    }
}