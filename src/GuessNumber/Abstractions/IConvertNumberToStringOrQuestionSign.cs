
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Конвертирует переданное число в строку либо в знак ?, если передан default.
    /// </summary>
    interface IConvertNumberToStringOrQuestionSign
    {
        string Execute(int? number);
    }
}