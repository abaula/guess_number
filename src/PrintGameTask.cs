using GuessNumber.Abstractions;

namespace GuessNumber
{
    class PrintGameTask : IPrintGameTask
    {
        private readonly IGetResourceText _getResourceText;
        private readonly IWriteToConsole _writeToConsole;

        public PrintGameTask(IGetResourceText getResourceText,
            IWriteToConsole writeToConsole)
        {
            _getResourceText = getResourceText;
            _writeToConsole = writeToConsole;
        }

        public void Execute(GameTask gameTask)
        {
            var template = _getResourceText.Execute(AppConst.Resources.GameTaskTemplate);

            if (string.IsNullOrWhiteSpace(template))
                return;

            var message = template.Replace(AppConst.Placeholders.GameTask, gameTask.Task);
            _writeToConsole.Execute(message);
        }
    }
}