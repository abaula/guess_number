namespace GuessNumber.Abstractions;

interface IConvertInputToNumber
{
    int? Execute(string value);
}
