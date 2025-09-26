using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class PrintAnswerIsIncorrect : IPrintAnswerIsIncorrect
    {
        private readonly IGetResourceText _getResourceText;
        private readonly IWriteToConsole _writeToConsole;

        public PrintAnswerIsIncorrect(IGetResourceText getResourceText,
            IWriteToConsole writeToConsole)
        {
            _getResourceText = getResourceText;
            _writeToConsole = writeToConsole;
        }

        public void Execute(int answer)
        {
            var template = _getResourceText.Execute(AppConst.Resources.AnswerIsIncorrectTemplate);

            if (string.IsNullOrWhiteSpace(template))
                return;

            var message = template.Replace(AppConst.Placeholders.Answer, answer.ToString());

            _writeToConsole.Execute(message);
        }
    }
}