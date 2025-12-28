using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class PrintAnswerIsIncorrect : IPrintAnswerIsIncorrect
    {
        private readonly Lazy<IGetResourceText> _getResourceText;
        private readonly Lazy<IWriteToConsole> _writeToConsole;

        public PrintAnswerIsIncorrect(Lazy<IGetResourceText> getResourceText,
            Lazy<IWriteToConsole> writeToConsole)
        {
            _getResourceText = getResourceText;
            _writeToConsole = writeToConsole;
        }

        public void Execute(int answer)
        {
            var template = _getResourceText.Value.Execute(AppConst.Resources.AnswerIsIncorrectTemplate);

            if (string.IsNullOrWhiteSpace(template))
                return;

            var message = template.Replace(AppConst.Placeholders.Answer, answer.ToString());

            _writeToConsole.Value.Execute(message);
        }
    }
}