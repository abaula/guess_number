using GuessNumber.Abstractions;

namespace GuessNumber
{
    class PrintBye(IGetResourceText getResourceText,
        IWriteToConsole writeToConsole)
        : IPrintBye
    {
        public void Execute()
        {
            var byeText = getResourceText.Execute(AppConst.Resources.Bye);

            if (string.IsNullOrWhiteSpace(byeText))
                return;

            writeToConsole.Execute(byeText);
        }
    }
}