using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class PrintChooseContinueOrExit : IPrintChooseContinueOrExit
    {
        private readonly Lazy<IGetResourceText> _getResourceText;
        private readonly Lazy<IWriteToConsole> _writeToConsole;

        public PrintChooseContinueOrExit(Lazy<IGetResourceText> getResourceText,
            Lazy<IWriteToConsole> writeToConsole)
        {
            _getResourceText = getResourceText;
            _writeToConsole = writeToConsole;
        }

        public void Execute()
        {
            var message = _getResourceText.Value.Execute(AppConst.Resources.ChooseContinueOrExit);

            if (string.IsNullOrWhiteSpace(message))
                return;

            _writeToConsole.Value.Execute(message);
        }
    }
}