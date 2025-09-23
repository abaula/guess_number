
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Формирует значения для математического выражения вида a + b = c.
    ///
    /// Неизвестные значения могут быть a, b, c.
    ///
    /// Диапазон неизвестных значений 0-9.
    /// </summary>
    interface IGenerateAdditionProblem
    {
        GameTask Execute();
    }
}