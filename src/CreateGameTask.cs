using GuessNumber.Abstractions;

namespace GuessNumber
{
    class CreateGameTask : ICreateGameTask
    {
        private readonly IConvertNumberToStringOrQuestionSign _convertNumber;

        public CreateGameTask(IConvertNumberToStringOrQuestionSign convertNumber)
        {
            _convertNumber = convertNumber;
        }

        public GameTask Execute(int? a, int? b, int? c, int answer, string operation)
        {
            return new GameTask
            {
                Task = $"{_convertNumber.Execute(a)} {operation} {_convertNumber.Execute(b)} = {_convertNumber.Execute(c)}",
                Answer = answer
            };
        }
    }
}