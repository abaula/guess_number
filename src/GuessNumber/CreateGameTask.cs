using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class CreateGameTask : ICreateGameTask
    {
        private readonly Lazy<IConvertNumberToStringOrQuestionSign> _convertNumber;

        public CreateGameTask(Lazy<IConvertNumberToStringOrQuestionSign> convertNumber)
        {
            _convertNumber = convertNumber;
        }

        public GameTask Execute(int? a, int? b, int? c, int answer, string operation)
        {
            return new GameTask
            {
                Task = $"{_convertNumber.Value.Execute(a)} {operation} {_convertNumber.Value.Execute(b)} = {_convertNumber.Value.Execute(c)}",
                Answer = answer
            };
        }
    }
}