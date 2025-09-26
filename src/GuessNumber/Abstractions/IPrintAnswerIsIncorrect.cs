
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Выводит сообщение, что ответ неверный.
    /// </summary>
    interface IPrintAnswerIsIncorrect
    {
        void Execute(int answer);
    }
}