using GuessNumber.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GuessNumber
{
    static class ModuleBootstraper
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<IGuess, Guess>();
            services.AddScoped<ICheckInput, CheckInput>();
            services.AddScoped<IConvertInputToNumber, ConvertInputToNumber>();
            services.AddScoped<IPrintRules, PrintRules>();
            services.AddScoped<IGetResourceText, GetResourceText>();
            services.AddScoped<IWriteToConsole, WriteToConsole>();
            services.AddScoped<IChooseContinueOrExit, ChooseContinueOrExit>();
            services.AddScoped<IPrintBye, PrintBye>();
            services.AddScoped<IPlay, Play>();
            services.AddScoped<IPrintChooseContinueOrExit, PrintChooseContinueOrExit>();
        }
    }
}