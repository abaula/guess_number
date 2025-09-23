
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Выводит сообщение с игровым заданием.
    /// </summary>
    interface IPrintGameTask
    {
        void Execute(GameTask gameTask);
    }
}