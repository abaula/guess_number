
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Проверка ответа пользователя на корректность.
    /// </summary>
    interface ICheckUserAnswer
    {
        bool Execute(GameTask gameTask, int userAnswer);
    }
}