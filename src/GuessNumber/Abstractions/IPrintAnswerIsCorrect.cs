
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Выводит сообщение, что ответ верный.
    /// </summary>
    interface IPrintAnswerIsCorrect
    {
        void Execute(int answer);
    }
}