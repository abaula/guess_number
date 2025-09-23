
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Формирует значения для математического выражения вида a - b = c.
    ///
    /// Неизвестные значения могут быть b, c.
    /// a - всегда известно.
    ///
    /// Диапазон неизвестных значений:
    /// b - 0-9,
    /// c - 0-9.
    /// </summary>
    interface IGenerateSubstractionProblem
    {
        GameTask Execute();
    }
}