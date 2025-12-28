using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class GenerateMultiplicationProblem : IGenerateMultiplicationProblem
    {
        private const string Operation = "*";
        private readonly Lazy<IGetRandomInt> _getRandomInt;
        private readonly Lazy<ICreateGameTask> _createGameTask;

        public GenerateMultiplicationProblem(Lazy<IGetRandomInt> getRandomInt,
            Lazy<ICreateGameTask> createGameTask)
        {
            _getRandomInt = getRandomInt;
            _createGameTask = createGameTask;
        }

        public GameTask Execute()
        {
            var a = _getRandomInt.Value.Execute(1, 9);
            var b = _getRandomInt.Value.Execute(1, 9);
            var c = a * b;

            switch (_getRandomInt.Value.Execute(1, 2))
            {
                case 1:
                    return _createGameTask.Value.Execute(default, b, c, a, Operation);
                case 2:
                    return _createGameTask.Value.Execute(a, default, c, b, Operation);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}