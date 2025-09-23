
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Получает и возвращает ответ пользователя для игрового задания.
    /// </summary>
    interface IGetUserAnswer
    {
        int? Execute();
    }
}