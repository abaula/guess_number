using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class GenerateAdditionProblem : IGenerateAdditionProblem
    {
        private const string Operation = "+";
        private readonly IGetRandomInt _getRandomInt;
        private readonly ICreateGameTask _createGameTask;

        public GenerateAdditionProblem(IGetRandomInt getRandomInt,
            ICreateGameTask createGameTask)
        {
            _getRandomInt = getRandomInt;
            _createGameTask = createGameTask;
        }

        public GameTask Execute()
        {
            var c = _getRandomInt.Execute(0, 9);
            var b = _getRandomInt.Execute(0, c);
            var a = c - b;

            switch (_getRandomInt.Execute(1, 3))
            {
                case 1:
                    return _createGameTask.Execute(default, b, c, a, Operation);
                case 2:
                    return _createGameTask.Execute(a, default, c, b, Operation);
                case 3:
                    return _createGameTask.Execute(a, b, default, c, Operation);
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}