
namespace GuessNumber.Abstractions
{
    interface IGetRandomInt
    {
        int Execute(int minValue, int maxValue);
    }
}