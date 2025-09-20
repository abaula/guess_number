using GuessNumber.Abstractions;

namespace GuessNumber
{
    class PrintChooseContinueOrExit(IGetResourceText getResourceText,
        IWriteToConsole writeToConsole)
        : IPrintChooseContinueOrExit
    {
        public void Execute()
        {
            var chooseContinueOrExitText = getResourceText.Execute(AppConst.Resources.ChooseContinueOrExit);

            if (string.IsNullOrWhiteSpace(chooseContinueOrExitText))
                return;

            writeToConsole.Execute(chooseContinueOrExitText);
        }
    }
}