
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Формирует значения для математического выражения вида a * b = c.
    ///
    /// Неизвестные значения могут быть a, b.
    /// c - всегда известно.
    ///
    /// Диапазон неизвестных значений:
    /// a - 0-9,
    /// b - 0-9.
    /// </summary>
    interface IGenerateMultiplicationProblem
    {
        GameTask Execute();
    }
}