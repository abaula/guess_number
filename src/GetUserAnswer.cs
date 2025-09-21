using GuessNumber.Abstractions;

namespace GuessNumber
{
    class GetUserAnswer : IGetUserAnswer
    {
        private readonly IGetUserAnswerInput _getUserAnswerInput;
        private readonly IConvertInputToNumber _convertInputToNumber;
        private readonly IPrintNumberNeeded _printNumberNeeded;

        public GetUserAnswer(IGetUserAnswerInput getUserAnswerInput,
            IConvertInputToNumber convertInputToNumber,
            IPrintNumberNeeded printNumberNeeded)
        {
            _getUserAnswerInput = getUserAnswerInput;
            _convertInputToNumber = convertInputToNumber;
            _printNumberNeeded = printNumberNeeded;
        }

        public int? Execute()
        {
            while (true)
            {
                // Получаем и обрабатываем решение пользователя.
                var inputStr = _getUserAnswerInput.Execute();

                if (string.IsNullOrWhiteSpace(inputStr))
                    return default;

                var number = _convertInputToNumber.Execute(inputStr);

                if (number.HasValue)
                    return number;

                // Печатаем предупреждение, что нужно вводить только число.
                _printNumberNeeded.Execute();
            }
        }
    }
}