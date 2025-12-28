
namespace GuessNumberTests
{
    static class LazyHelper
    {
        public static Lazy<T> ToLazy<T>(T value) => new Lazy<T>(value);
    }
}