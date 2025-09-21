using GuessNumber.Abstractions;

namespace GuessNumber
{
    class CheckUserAnswer : ICheckUserAnswer
    {
        public bool Execute(GameTask gameTask, int userAnswer)
        {
            return gameTask.Answer == userAnswer;
        }
    }
}