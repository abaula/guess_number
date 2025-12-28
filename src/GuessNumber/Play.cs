using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class Play : IPlay
    {
        private readonly Lazy<IGenerateTask> _generateTask;
        private readonly Lazy<IPrintGameTask> _printGameTask;
        private readonly Lazy<IGetUserAnswer> _getUserAnswer;
        private readonly Lazy<ICheckUserAnswer> _checkUserAnswer;
        private readonly Lazy<IPrintAnswerIsCorrect> _printAnswerIsCorrect;
        private readonly Lazy<IPrintAnswerIsIncorrect> _printAnswerIsIncorrect;

        public Play(Lazy<IGenerateTask> generateTask,
            Lazy<IPrintGameTask> printGameTask,
            Lazy<IGetUserAnswer> getUserAnswer,
            Lazy<ICheckUserAnswer> checkUserAnswer,
            Lazy<IPrintAnswerIsCorrect> printAnswerIsCorrect,
            Lazy<IPrintAnswerIsIncorrect> printAnswerIsIncorrect)
        {
            _generateTask = generateTask;
            _printGameTask = printGameTask;
            _getUserAnswer = getUserAnswer;
            _checkUserAnswer = checkUserAnswer;
            _printAnswerIsCorrect = printAnswerIsCorrect;
            _printAnswerIsIncorrect = printAnswerIsIncorrect;
        }

        public void Execute()
        {
            // Создаём задание.
            var task = _generateTask.Value.Execute();
            // Печатаем задание для пользователя.
            _printGameTask.Value.Execute(task);

            while (true)
            {
                // Получаем ответ пользователя.
                var userAnswer = _getUserAnswer.Value.Execute();

                // Если ответа нет, то выходим из игры.
                if (userAnswer.HasValue == false)
                    return;

                // Оцениваем ответ.
                if (_checkUserAnswer.Value.Execute(task, userAnswer.Value))
                // ... Если ответ верный, то сообщаем пользователю и выходим.
                {
                    _printAnswerIsCorrect.Value.Execute(userAnswer.Value);
                    return;
                }

                // Сообщаем, что ответ неверный и продолжаем.
                _printAnswerIsIncorrect.Value.Execute(userAnswer.Value);
            }
        }
    }
}