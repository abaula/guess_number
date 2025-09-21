using GuessNumber.Abstractions;

namespace GuessNumber
{
    class GenerateTask : IGenerateTask
    {
        private readonly IGetRandomInt _getRandomInt;
        private readonly IGenerateAdditionProblem _generateAdditionProblem;
        private readonly IGenerateSubstractionProblem _generateSubstractionProblem;
        private readonly IGenerateMultiplicationProblem _generateMultiplicationProblem;
        private readonly IGenerateDivisionProblem _generateDivisionProblem;

        public GenerateTask(IGetRandomInt getRandomInt,
            IGenerateAdditionProblem generateAdditionProblem,
            IGenerateSubstractionProblem generateSubstractionProblem,
            IGenerateMultiplicationProblem generateMultiplicationProblem,
            IGenerateDivisionProblem generateDivisionProblem)
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
            switch (_getRandomInt.Execute(1, 4))
            {
                case 1:
                    return _generateAdditionProblem.Execute();
                case 2:
                    return _generateSubstractionProblem.Execute();
                case 3:
                    return _generateMultiplicationProblem.Execute();
                case 4:
                    return _generateDivisionProblem.Execute();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}