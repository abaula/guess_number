using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class GenerateAdditionProblem : IGenerateAdditionProblem
    {
        private const string Operation = "+";
        private readonly Lazy<IGetRandomInt> _getRandomInt;
        private readonly Lazy<ICreateGameTask> _createGameTask;

        public GenerateAdditionProblem(Lazy<IGetRandomInt> getRandomInt,
            Lazy<ICreateGameTask> createGameTask)
        {
            _getRandomInt = getRandomInt;
            _createGameTask = createGameTask;
        }

        public GameTask Execute()
        {
            var c = _getRandomInt.Value.Execute(0, 9);
            var b = _getRandomInt.Value.Execute(0, c);
            var a = c - b;

            switch (_getRandomInt.Value.Execute(1, 3))
            {
                case 1:
                    return _createGameTask.Value.Execute(default, b, c, a, Operation);
                case 2:
                    return _createGameTask.Value.Execute(a, default, c, b, Operation);
                case 3:
                    return _createGameTask.Value.Execute(a, b, default, c, Operation);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}