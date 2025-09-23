
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Возвращает случайное целое число в указанном диапазоне.
    /// </summary>
    interface IGetRandomInt
    {
        int Execute(int minValue, int maxValue);
    }
}