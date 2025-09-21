using GuessNumber.Abstractions;

namespace GuessNumber
{
    class PrintAnswerIsCorrect : IPrintAnswerIsCorrect
    {
        private readonly IGetResourceText _getResourceText;
        private readonly IWriteToConsole _writeToConsole;

        public PrintAnswerIsCorrect(IGetResourceText getResourceText,
            IWriteToConsole writeToConsole)
        {
            _getResourceText = getResourceText;
            _writeToConsole = writeToConsole;
        }

        public void Execute(int answer)
        {
            var template = _getResourceText.Execute(AppConst.Resources.AnswerIsCorrectTemplate);

            if (string.IsNullOrWhiteSpace(template))
                return;

            var message = template.Replace(AppConst.Placeholders.Answer, answer.ToString());

            _writeToConsole.Execute(message);
        }
    }
}