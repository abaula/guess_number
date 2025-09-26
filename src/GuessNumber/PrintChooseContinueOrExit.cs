using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class PrintChooseContinueOrExit : IPrintChooseContinueOrExit
    {
        private readonly IGetResourceText _getResourceText;
        private readonly IWriteToConsole _writeToConsole;

        public PrintChooseContinueOrExit(IGetResourceText getResourceText,
            IWriteToConsole writeToConsole)
        {
            _getResourceText = getResourceText;
            _writeToConsole = writeToConsole;
        }

        public void Execute()
        {
            var message = _getResourceText.Execute(AppConst.Resources.ChooseContinueOrExit);

            if (string.IsNullOrWhiteSpace(message))
                return;

            _writeToConsole.Execute(message);
        }
    }
}