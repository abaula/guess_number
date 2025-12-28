using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class PrintNumberNeeded : IPrintNumberNeeded
    {
        private readonly Lazy<IGetResourceText> _getResourceText;
        private readonly Lazy<IWriteToConsole> _writeToConsole;

        public PrintNumberNeeded(Lazy<IGetResourceText> getResourceText,
            Lazy<IWriteToConsole> writeToConsole)
        {
            _getResourceText = getResourceText;
            _writeToConsole = writeToConsole;
        }

        public void Execute()
        {
            var message = _getResourceText.Value.Execute(AppConst.Resources.NumberNeeded);

            if (string.IsNullOrWhiteSpace(message))
                return;

            _writeToConsole.Value.Execute(message);
        }
    }
}