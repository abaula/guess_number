
namespace GuessNumber.Abstractions
{
    interface IConvertNumberToStringOrQuestionSign
    {
        string Execute(int? number);
    }
}