using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class GetUserAnswer : IGetUserAnswer
    {
        private readonly Lazy<IGetUserAnswerInput> _getUserAnswerInput;
        private readonly Lazy<IConvertInputToNumber> _convertInputToNumber;
        private readonly Lazy<IPrintNumberNeeded> _printNumberNeeded;

        public GetUserAnswer(Lazy<IGetUserAnswerInput> getUserAnswerInput,
            Lazy<IConvertInputToNumber> convertInputToNumber,
            Lazy<IPrintNumberNeeded> printNumberNeeded)
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
                var inputStr = _getUserAnswerInput.Value.Execute();

                if (string.IsNullOrWhiteSpace(inputStr))
                    return default;

                var number = _convertInputToNumber.Value.Execute(inputStr);

                if (number.HasValue)
                    return number;

                // Печатаем предупреждение, что нужно вводить только число.
                _printNumberNeeded.Value.Execute();
            }
        }
    }
}