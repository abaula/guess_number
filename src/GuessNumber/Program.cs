using GuessNumber.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GuessNumber
{
    /// <summary>
    /// Инициализация и запуск приложения.
    /// </summary>
    class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();
            ModuleBootstraper.Setup(services);
            var serviceProvider = services.BuildServiceProvider();
            var guessGame = serviceProvider.GetRequiredService<IGuessGame>();
            guessGame.Execute();
        }
    }
}
