
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Получает выбор пользователя продолжать игру или выйти из игры.
    /// </summary>
    interface IChooseContinueOrExit
    {
        ContinueOrExit Execute();
    }
}