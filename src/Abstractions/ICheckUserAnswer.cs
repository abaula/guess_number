
namespace GuessNumber.Abstractions
{
    interface ICheckUserAnswer
    {
        bool Execute(GameTask gameTask, int userAnswer);
    }
}