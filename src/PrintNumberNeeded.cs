using GuessNumber.Abstractions;

namespace GuessNumber
{
    class PrintNumberNeeded : IPrintNumberNeeded
    {
        private readonly IGetResourceText _getResourceText;
        private readonly IWriteToConsole _writeToConsole;

        public PrintNumberNeeded(IGetResourceText getResourceText,
            IWriteToConsole writeToConsole)
        {
            _getResourceText = getResourceText;
            _writeToConsole = writeToConsole;
        }

        public void Execute()
        {
            var message = _getResourceText.Execute(AppConst.Resources.NumberNeeded);

            if (string.IsNullOrWhiteSpace(message))
                return;

            _writeToConsole.Execute(message);
        }
    }
}