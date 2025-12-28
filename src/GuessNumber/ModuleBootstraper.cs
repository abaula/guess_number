using GuessNumber.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GuessNumber
{
    /// <summary>
    /// Регистрация типов в фабрике ServiceCollection.
    /// </summary>
    static class ModuleBootstraper
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddScopedWithLazy<IGuessGame, GuessGame>();
            services.AddScopedWithLazy<IConvertInputToNumber, ConvertInputToNumber>();
            services.AddScopedWithLazy<IPrintRules, PrintRules>();
            services.AddScopedWithLazy<IGetResourceText, GetResourceText>();
            services.AddScopedWithLazy<IWriteToConsole, WriteToConsole>();
            services.AddScopedWithLazy<IChooseContinueOrExit, ChooseContinueOrExit>();
            services.AddScopedWithLazy<IPrintBye, PrintBye>();
            services.AddScopedWithLazy<IPlay, Play>();
            services.AddScopedWithLazy<IPrintChooseContinueOrExit, PrintChooseContinueOrExit>();
            services.AddScopedWithLazy<IGenerateTask, GenerateTask>();
            services.AddScopedWithLazy<IPrintGameTask, PrintGameTask>();
            services.AddScopedWithLazy<IGetUserAnswer, GetUserAnswer>();
            services.AddScopedWithLazy<ICheckUserAnswer, CheckUserAnswer>();
            services.AddScopedWithLazy<IPrintAnswerIsCorrect, PrintAnswerIsCorrect>();
            services.AddScopedWithLazy<IPrintAnswerIsIncorrect, PrintAnswerIsIncorrect>();
            services.AddScopedWithLazy<IGetUserAnswerInput, GetUserAnswerInput>();
            services.AddScopedWithLazy<IPrintNumberNeeded, PrintNumberNeeded>();
            services.AddSingletonWithLazy<IGetRandomInt, GetRandomInt>();
            services.AddScopedWithLazy<IGenerateAdditionProblem, GenerateAdditionProblem>();
            services.AddScopedWithLazy<IGenerateSubstractionProblem, GenerateSubstractionProblem>();
            services.AddScopedWithLazy<IGenerateMultiplicationProblem, GenerateMultiplicationProblem>();
            services.AddScopedWithLazy<IGenerateDivisionProblem, GenerateDivisionProblem>();
            services.AddScopedWithLazy<ICreateGameTask, CreateGameTask>();
            services.AddSingletonWithLazy<IConvertNumberToStringOrQuestionSign, ConvertNumberToStringOrQuestionSign>();
        }
    }
}