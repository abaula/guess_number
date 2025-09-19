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
            services.AddScoped<IGetRulesText, GetRulesText>();
            services.AddScoped<IWriteLineToConsole, WriteLineToConsole>();
        }
    }
}