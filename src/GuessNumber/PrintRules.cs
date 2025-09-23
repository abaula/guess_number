using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class PrintRules : IPrintRules
    {
        private readonly IGetResourceText _getResourceText;
        private readonly IWriteToConsole _writeToConsole;

        public PrintRules(IGetResourceText getResourceText,
            IWriteToConsole writeToConsole)
        {
            _getResourceText = getResourceText;
            _writeToConsole = writeToConsole;
        }

        public void Execute()
        {
            var message = _getResourceText.Execute(AppConst.Resources.Rules);

            if (string.IsNullOrWhiteSpace(message))
                return;

            _writeToConsole.Execute(message);
        }
    }
}