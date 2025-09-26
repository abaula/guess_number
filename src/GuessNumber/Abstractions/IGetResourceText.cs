
namespace GuessNumber.Abstractions
{
    /// <summary>
    /// Возвращает содержимое из указанного ресурса в виде строки.
    /// </summary>
    interface IGetResourceText
    {
        string? Execute(string resourceName);
    }
}