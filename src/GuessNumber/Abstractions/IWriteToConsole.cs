
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Выводит значение на консоль.
    /// </summary>
    interface IWriteToConsole
    {
        void Execute(string? value);
    }
}