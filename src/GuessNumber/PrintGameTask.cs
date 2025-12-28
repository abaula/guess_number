using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class PrintGameTask : IPrintGameTask
    {
        private readonly Lazy<IGetResourceText> _getResourceText;
        private readonly Lazy<IWriteToConsole> _writeToConsole;

        public PrintGameTask(Lazy<IGetResourceText> getResourceText,
            Lazy<IWriteToConsole> writeToConsole)
        {
            _getResourceText = getResourceText;
            _writeToConsole = writeToConsole;
        }

        public void Execute(GameTask gameTask)
        {
            var template = _getResourceText.Value.Execute(AppConst.Resources.GameTaskTemplate);

            if (string.IsNullOrWhiteSpace(template))
                return;

            var message = template.Replace(AppConst.Placeholders.GameTask, gameTask.Task);
            _writeToConsole.Value.Execute(message);
        }
    }
}