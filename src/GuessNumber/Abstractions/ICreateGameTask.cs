
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Создаёт экземпляр GameTask из переданных параметров.
    /// </summary>
    interface ICreateGameTask
    {
        GameTask Execute(int? a, int? b, int? c, int answer, string operation);
    }
}