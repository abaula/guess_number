using GuessNumber.Abstractions;

namespace GuessNumber
{
    /// <inheritdoc/>
    class GenerateTask : IGenerateTask
    {
        private readonly Lazy<IGetRandomInt> _getRandomInt;
        private readonly Lazy<IGenerateAdditionProblem> _generateAdditionProblem;
        private readonly Lazy<IGenerateSubstractionProblem> _generateSubstractionProblem;
        private readonly Lazy<IGenerateMultiplicationProblem> _generateMultiplicationProblem;
        private readonly Lazy<IGenerateDivisionProblem> _generateDivisionProblem;

        public GenerateTask(Lazy<IGetRandomInt> getRandomInt,
            Lazy<IGenerateAdditionProblem> generateAdditionProblem,
            Lazy<IGenerateSubstractionProblem> generateSubstractionProblem,
            Lazy<IGenerateMultiplicationProblem> generateMultiplicationProblem,
            Lazy<IGenerateDivisionProblem> generateDivisionProblem)
        {
            _getRandomInt = getRandomInt;
            _generateAdditionProblem = generateAdditionProblem;
            _generateSubstractionProblem = generateSubstractionProblem;
            _generateMultiplicationProblem = generateMultiplicationProblem;
            _generateDivisionProblem = generateDivisionProblem;
        }

        public GameTask Execute()
        {
            // Выбираем тип задания для генерации.
            switch (_getRandomInt.Value.Execute(1, 4))
            {
                case 1:
                    return _generateAdditionProblem.Value.Execute();
                case 2:
                    return _generateSubstractionProblem.Value.Execute();
                case 3:
                    return _generateMultiplicationProblem.Value.Execute();
                case 4:
                    return _generateDivisionProblem.Value.Execute();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}