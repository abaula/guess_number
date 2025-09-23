using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class GenerateMultiplicationProblem : IGenerateMultiplicationProblem
    {
        private const string Operation = "*";
        private readonly IGetRandomInt _getRandomInt;
        private readonly ICreateGameTask _createGameTask;

        public GenerateMultiplicationProblem(IGetRandomInt getRandomInt,
            ICreateGameTask createGameTask)
        {
            _getRandomInt = getRandomInt;
            _createGameTask = createGameTask;
        }

        public GameTask Execute()
        {
            var a = _getRandomInt.Execute(0, 9);
            var b = _getRandomInt.Execute(0, 9);
            var c = a * b;

            switch (_getRandomInt.Execute(1, 2))
            {
                case 1:
                    return _createGameTask.Execute(default, b, c, a, Operation);
                case 2:
                    return _createGameTask.Execute(a, default, c, b, Operation);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}