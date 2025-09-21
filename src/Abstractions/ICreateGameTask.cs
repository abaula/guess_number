
namespace GuessNumber.Abstractions
{
    interface ICreateGameTask
    {
        GameTask Execute(int? a, int? b, int? c, int answer, string operation);
    }
}