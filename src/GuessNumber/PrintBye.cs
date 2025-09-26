using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class PrintBye : IPrintBye
    {
        private readonly IGetResourceText _getResourceText;
        private readonly IWriteToConsole _writeToConsole;

        public PrintBye(IGetResourceText getResourceText,
            IWriteToConsole writeToConsole)
        {
            _getResourceText = getResourceText;
            _writeToConsole = writeToConsole;
        }

        public void Execute()
        {
            var message = _getResourceText.Execute(AppConst.Resources.Bye);

            if (string.IsNullOrWhiteSpace(message))
                return;

            _writeToConsole.Execute(message);
        }
    }
}