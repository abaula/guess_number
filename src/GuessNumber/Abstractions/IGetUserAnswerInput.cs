
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Получает и возвращает введённый пользователем символ.
    /// Если введён ESCAPE, то возвращает default.
    /// </summary>
    interface IGetUserAnswerInput
    {
        string? Execute();
    }
}