
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Создаёт игровое задание выбирая одно случайным образом из 4-х типов заданий.
    /// </summary>
    interface IGenerateTask
    {
        GameTask Execute();
    }
}