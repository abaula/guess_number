using GuessNumber.Abstractions;

namespace GuessNumber
{
    class Play : IPlay
    {
        private readonly IGenerateTask _generateTask;
        private readonly IPrintGameTask _printGameTask;
        private readonly IGetUserAnswer _getUserAnswer;
        private readonly ICheckUserAnswer _checkUserAnswer;
        private readonly IPrintAnswerIsCorrect _printAnswerIsCorrect;
        private readonly IPrintAnswerIsIncorrect _printAnswerIsIncorrect;

        public Play(IGenerateTask generateTask,
            IPrintGameTask printGameTask,
            IGetUserAnswer getUserAnswer,
            ICheckUserAnswer checkUserAnswer,
            IPrintAnswerIsCorrect printAnswerIsCorrect,
            IPrintAnswerIsIncorrect printAnswerIsIncorrect)
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
            var task = _generateTask.Execute();
            // Печатаем задание для пользователя.
            _printGameTask.Execute(task);

            while (true)
            {
                // Получаем ответ пользователя.
                var userAnswer = _getUserAnswer.Execute();

                // Если ответа нет, то выходим из игры.
                if (userAnswer.HasValue == false)
                    return;

                // Оцениваем ответ.
                if (_checkUserAnswer.Execute(task, userAnswer.Value))
                // ... Если ответ верный, то сообщаем пользователю и выходим.
                {
                    _printAnswerIsCorrect.Execute(userAnswer.Value);
                    return;
                }

                // Сообщаем, что ответ неверный и продолжаем.
                _printAnswerIsIncorrect.Execute(userAnswer.Value);
            }
        }
    }
}