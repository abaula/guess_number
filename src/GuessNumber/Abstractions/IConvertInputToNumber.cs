namespace GuessNumber.Abstractions;

/// <summary>
/// Конвертирует ввод пользователя в число.
/// Если пользователь ввёл не число то возвращает default.
/// </summary>
interface IConvertInputToNumber
{
    int? Execute(string value);
}
