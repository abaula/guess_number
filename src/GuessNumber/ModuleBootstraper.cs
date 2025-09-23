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
            services.AddScoped<IGuessGame, GuessGame>();
            services.AddScoped<IConvertInputToNumber, ConvertInputToNumber>();
            services.AddScoped<IPrintRules, PrintRules>();
            services.AddScoped<IGetResourceText, GetResourceText>();
            services.AddScoped<IWriteToConsole, WriteToConsole>();
            services.AddScoped<IChooseContinueOrExit, ChooseContinueOrExit>();
            services.AddScoped<IPrintBye, PrintBye>();
            services.AddScoped<IPlay, Play>();
            services.AddScoped<IPrintChooseContinueOrExit, PrintChooseContinueOrExit>();
            services.AddScoped<IGenerateTask, GenerateTask>();
            services.AddScoped<IPrintGameTask, PrintGameTask>();
            services.AddScoped<IGetUserAnswer, GetUserAnswer>();
            services.AddScoped<ICheckUserAnswer, CheckUserAnswer>();
            services.AddScoped<IPrintAnswerIsCorrect, PrintAnswerIsCorrect>();
            services.AddScoped<IPrintAnswerIsIncorrect, PrintAnswerIsIncorrect>();
            services.AddScoped<IGetUserAnswerInput, GetUserAnswerInput>();
            services.AddScoped<IPrintNumberNeeded, PrintNumberNeeded>();
            services.AddSingleton<IGetRandomInt, GetRandomInt>();
            services.AddScoped<IGenerateAdditionProblem, GenerateAdditionProblem>();
            services.AddScoped<IGenerateSubstractionProblem, GenerateSubstractionProblem>();
            services.AddScoped<IGenerateMultiplicationProblem, GenerateMultiplicationProblem>();
            services.AddScoped<IGenerateDivisionProblem, GenerateDivisionProblem>();
            services.AddScoped<ICreateGameTask, CreateGameTask>();
            services.AddSingleton<IConvertNumberToStringOrQuestionSign, ConvertNumberToStringOrQuestionSign>();
        }
    }
}