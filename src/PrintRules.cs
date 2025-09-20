using GuessNumber.Abstractions;

namespace GuessNumber
{
    class PrintRules(IGetResourceText getResourceText,
        IWriteToConsole writeToConsole)
        : IPrintRules
    {
        public void Execute()
        {
            var rulesText = getResourceText.Execute(AppConst.Resources.Rules);

            if (string.IsNullOrWhiteSpace(rulesText))
                return;

            writeToConsole.Execute(rulesText);
        }
    }
}